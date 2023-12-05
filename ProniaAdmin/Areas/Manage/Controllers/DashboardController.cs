using Microsoft.AspNetCore.Mvc;

namespace ProniaAdmin.Areas.Manage.Controllers
{

    [Area("Manage")]
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
