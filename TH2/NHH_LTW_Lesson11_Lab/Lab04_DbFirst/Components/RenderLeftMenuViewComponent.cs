using Lab04_DbFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04_DbFirst.Components
{
    public class RenderLeftMenuViewComponent : ViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();

        public RenderLeftMenuViewComponent()
        {
            MenuItems = new List<MenuItem>()
            {
                new MenuItem() { Id = 1, Name = "Learners", Link = "/Learners" },
            };
        }

        public IViewComponentResult Invoke()
        {
            return View(MenuItems);
        }
    }
}
