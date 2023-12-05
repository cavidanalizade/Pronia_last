using ProniaAdmin.DAL;
using ProniaAdmin.ViewModels;

namespace ProniaAdmin.Controllers
{
    public class HomeController : Controller
    {

        AppDBC _db;
        public HomeController(AppDBC db)
        {
            _db = db;
        }


        public IActionResult Index()
        {

            HomeVm vm = new HomeVm()
            {
                slidersData = _db.sliders.ToList() ,
                productsData = _db.products.ToList() ,  
                
                
                
                
            };

            return View(vm);
        }


    }
}