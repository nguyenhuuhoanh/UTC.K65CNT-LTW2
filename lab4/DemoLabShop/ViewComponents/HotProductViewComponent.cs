using Microsoft.AspNetCore.Mvc;
using DemoLabShop.Models;

namespace DemoLabShop.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var products = Product.GetHotProducts();
            return View(products);
        }
    }
}
