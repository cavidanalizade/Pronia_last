using Microsoft.AspNetCore.Mvc;
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
/*			List<BasketVM> cartItems = GetCartItemsFromCookie();
			List<Product> cartProducts = new List< Product >
			foreach (var item in cartItems)
			{

				foreach (var p in _db.products)
				{

				}

			}*/

			return View(/*cartItems*/);
		}

		public IActionResult AddToCart(int productId)
		{
			List<BasketVM> cartItems = GetCartItemsFromCookie();

			BasketVM existingItem = cartItems.FirstOrDefault(item => item.ProductId == productId);

			if (existingItem != null)
			{
				existingItem.Quantity++;
			}
			else
			{
				BasketVM newItem = new BasketVM
				{
					ProductId = productId,
					Quantity = 1
				};

				cartItems.Add(newItem);
			}

			UpdateCartItemsInCookie(cartItems);

			return RedirectToAction("Index");
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
