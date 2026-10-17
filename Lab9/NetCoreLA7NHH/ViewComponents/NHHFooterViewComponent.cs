// Author: NHH

using Microsoft.AspNetCore.Mvc;

namespace NetCoreLA7NHH.ViewComponents
{
    public class NHHFooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
