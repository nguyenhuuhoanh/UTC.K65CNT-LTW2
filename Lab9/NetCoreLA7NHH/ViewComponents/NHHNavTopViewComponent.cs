// Author: NHH

using Microsoft.AspNetCore.Mvc;

namespace NetCoreLA7NHH.ViewComponents
{
    public class NHHNavTopViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
