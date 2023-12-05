using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProniaAdmin.DAL;
using System;

namespace ProniaAdmin.Controllers
{
    public class ShopController : Controller
    {
        AppDBC _db;

        public ShopController(AppDBC db)
        {
            _db = db;
        }

        public IActionResult Detail(int? id)
        {
            Product product = _db.Products
              .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .FirstOrDefault(product => product.Id == id);


            return View(product);
        }
    }
}
