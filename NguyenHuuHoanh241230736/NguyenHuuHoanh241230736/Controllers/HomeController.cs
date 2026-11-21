using Microsoft.AspNetCore.Mvc;
using NguyenHuuHoanh241230736.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NguyenHuuHoanh241230736.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLTaiSanContext _db;
        public HomeController(QLTaiSanContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var ds = _db.TaiSans.Where(t => t.NguyenGia != null && t.NguyenGia >=20).ToList();
            return View(ds);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult TheoLoai(int id)
        {
            var ds = _db.TaiSans.Where(t => t.MaLoai == id && t.NguyenGia !=null).ToList();
            return PartialView("DanhSachTaiSan", ds);
        }
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_db.LoaiTaiSans, "MaLoai", "TenLoai");
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("MaLoai,TenTs,NguyenGia,Anh")] TaiSan ts)
        {
            ModelState.Remove("MaLoaiNavigation");
            if(ModelState.IsValid)
            {
                _db.TaiSans.Add(ts);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(_db.LoaiTaiSans, "MaLoai", "TenLoai", ts.MaLoai);
            return View(ts);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
