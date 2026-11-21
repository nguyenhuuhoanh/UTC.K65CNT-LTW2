using Microsoft.AspNetCore.Mvc;
using NguyenHuuHoanh_241230736.Models;

namespace NguyenHuuHoanh_241230736.Controllers
{
    public class HomeController : Controller
    {
        private readonly DeThiContext _db;
        public HomeController(DeThiContext db) { _db = db; }

        public IActionResult Index(int? maLoai)
        {
            var ds = _db.HangHoas.AsQueryable();
            if (maLoai.HasValue) ds = ds.Where(h => h.MaLoai == maLoai.Value);
            else ds = ds.Where(h => h.Gia >= 100);
            return View(ds.ToList());
        }

        public IActionResult LocTheoLoai(int id)
        {
            var ds = _db.HangHoas.Where(h => h.MaLoai == id).ToList();
            return PartialView("DanhSachHang", ds);
        }
    }
}
