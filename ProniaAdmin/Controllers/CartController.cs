using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProniaAdmin.ViewModels;
using System;

namespace ProniaAdmin.Controllers
{
	public class CartController : Controller
	{

		private const string CartCookieKey = "Cart";
		AppDBC _db;

        public CartController(AppDBC db)
        {
            _db = db;
        }

        public IActionResult Index()
		{

			var jsonCookie = Request.Cookies["Basket"];
			List<BasketItemVM> basketItems = new List<BasketItemVM>();
			if (jsonCookie != null)
			{
				var cookieItems = JsonConvert.DeserializeObject<List<BasketVM>>(jsonCookie);

				bool countCheck = false;
				List<BasketVM> deletedCookie = new List<BasketVM>();
				foreach (var item in cookieItems)
				{
					Product product = _db.Products.Include(p => p.ProductImages.Where(p => p.IsPrime == true)).FirstOrDefault(p => p.Id == item.ProductId);
					if (product == null)
					{
						deletedCookie.Add(item);
						continue;
					}
					basketItems.Add(new BasketItemVM()
					{
						Id = item.ProductId,
						Name = product.Name,
						Price = (double)product.Price,
						Count = item.Quantity,
						ImgUrl = product.ProductImages.FirstOrDefault(p=>p.IsPrime==true).ImgUrl
					});
				}
				if (deletedCookie.Count > 0)
				{
					foreach (var delete in deletedCookie)
					{
						cookieItems.Remove(delete);
					}
					Response.Cookies.Append("Basket", JsonConvert.SerializeObject(cookieItems));
				}

			}
			return View(basketItems);
		}

		public IActionResult AddBasket(int Id)
		{
			if (Id <= 0) return BadRequest();
            Product product = _db.Products.FirstOrDefault(p => p.Id == Id);

            if (product == null) return NotFound();
			List<BasketVM> basket;
			var json = Request.Cookies["Basket"];

			if (json != null)
			{
				basket = JsonConvert.DeserializeObject<List<BasketVM>>(json);
				var existProduct = basket.FirstOrDefault(p => p.ProductId == Id);
				if (existProduct != null)
				{
					existProduct.Quantity += 1;
				}
				else
				{
					basket.Add(new BasketVM()
					{
						ProductId = Id,
						Quantity = 1
					});
				}

			}
			else
			{
				basket = new List<BasketVM>();
				basket.Add(new BasketVM()
				{
					ProductId = Id,
					Quantity = 1
				});
			}


			var cookieBasket = JsonConvert.SerializeObject(basket);
			Response.Cookies.Append("Basket", cookieBasket);






			return RedirectToAction(nameof(Index), "Home");
		}
		   public IActionResult RemoveBasketItem(int Id)
        {
            var cookieBasket=Request.Cookies["Basket"];
            if(cookieBasket!=null)
            {
                List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(cookieBasket);

                var deleteElement=basket.FirstOrDefault(p => p.ProductId == Id);
                if(deleteElement!=null)
                {
                    basket.Remove(deleteElement);
                }


                Response.Cookies.Append("Basket", JsonConvert.SerializeObject(basket));
                return Ok();
            }
            return NotFound();
        }
        public IActionResult GetBasket()
        {
            var basketCookieJson = Request.Cookies["Basket"];

            return Content(basketCookieJson);
        }


        #region Functions
        private List<BasketVM> GetCartItemsFromCookie()
		{
			string cartJson = Request.Cookies[CartCookieKey];

			if (string.IsNullOrEmpty(cartJson))
			{
				return new List<BasketVM>();
			}

			return JsonConvert.DeserializeObject<List<BasketVM>>(cartJson);
		}

		private void UpdateCartItemsInCookie(List<BasketVM> cartItems)
		{
			string cartJson = JsonConvert.SerializeObject(cartItems);

			Response.Cookies.Append(CartCookieKey, cartJson);
		}
		#endregion



	}



}
