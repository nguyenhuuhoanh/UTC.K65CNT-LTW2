using NguyenHuuHoanh_241230736.Models;
using Microsoft.AspNetCore.Mvc;

namespace NguyenHuuHoanh_241230736.ViewComponents
{
    public class MenuLoaiHangViewComponent : ViewComponent
    {
        private readonly DeThiContext _db;
        public MenuLoaiHangViewComponent(DeThiContext db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            var loaiHangs = _db.LoaiHangs.ToList();
            return View(loaiHangs);
        }
    }
}
