using Microsoft.AspNetCore.Mvc;
using NHHoanh241230726.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace NHHoanh241230726.Controllers
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
            var ds = _db.TaiSans.Where(t => t.NguyenGia != null && t.NguyenGia >= 20).ToList();
            return View(ds);
        }
        public IActionResult TheoLoai(int id)
        {
            var ds = _db.TaiSans.Where(t => t.MaLoai == id && t.NguyenGia !=null).ToList();
            return PartialView("_DanhSachTaiSanPartial", ds);
        }
        public IActionResult Edit(int id)
        {
            var ts = _db.TaiSans.Find(id);
            if (ts == null)
            {
                return NotFound();
            }
            ViewBag.MaLoai = new SelectList(_db.LoaiTaiSans, "MaLoai", "TenLoai", ts.MaLoai);
            return View(ts);
        }
        [HttpPost]
        public IActionResult Edit([Bind("MaTS,TenTS,MaLoai,NguyenGia,Anh")] TaiSan ts)
        {
            ModelState.Remove("MaLoaiNagation");
            if (ModelState.IsValid)
            {
                _db.TaiSans.Update(ts);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoai = new SelectList(_db.LoaiTaiSans, "MaLoai", "TenLoai", ts.MaLoai);
            return View(ts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
