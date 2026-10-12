using Microsoft.AspNetCore.Mvc;
using DemoLabShop.Models;

namespace DemoLabShop.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var products = Product.GetNewProducts().Concat(Product.GetHotProducts()).ToList();
            return View(products);
        }
    }
}
