using Microsoft.AspNetCore.Mvc;
using DemoLabShop.Models;

namespace DemoLabShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var products = Product.GetNewProducts();
            return View(products);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
