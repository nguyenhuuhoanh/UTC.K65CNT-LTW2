using Lab04.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab04.Components
{
    public class RenderLeftMenuViewComponent : ViewComponent
    {
        private List<MenuItem> MenuItems = new List<MenuItem>();

        public RenderLeftMenuViewComponent()
        {
            MenuItems = new List<MenuItem>()
            {
                new MenuItem() { Id = 1, Name = "Branches", Link = "/Branches/List" },
                new MenuItem() { Id = 2, Name = "Students", Link = "/Students/List" },
                new MenuItem() { Id = 3, Name = "Subjects", Link = "/Subjects/List" },
                new MenuItem() { Id = 4, Name = "Courses", Link = "/Courses/List" },
            };
        }

        public IViewComponentResult Invoke()
        {
            return View(MenuItems);
        }
    }
}
