using Microsoft.AspNetCore.Mvc;
using NguyenHuuHoanh_241224468.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NguyenHuuHoanh_241224468.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext _context;

        public HomeController(QLNhaSachContext context)
        {
            _context = context;
        }

        private void taoDSTheLoai(int? maTl = null)
        {
            ViewData["MaTl"] = new SelectList(_context.TheLoais, "MaTl", "TenTl", maTl);
        }
        public IActionResult Index()
        {
            ViewBag.TieuDe = "Nguyễn Hữu Hoanh";
            var sachs = _context.Saches.Where(a => a.Gia >= 100).ToList();
            return View(sachs);
        }

        public IActionResult LocSach(int id)
        {
            var theLoai = _context.TheLoais.Find(id);
            ViewBag.TieuDe = theLoai?.TenTl;
            var sachs = _context.Saches.Where(s => s.MaTl == id && s.Gia != null).ToList();
            return PartialView("NguyenHuuHoanh_MainContent", sachs);
        }

        public IActionResult Create()
        {
            taoDSTheLoai();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaTl, TenSach, Gia, Anh")] Sach sach)
        {
            ModelState.Remove("MaTlNavigation");
            if (ModelState.IsValid)
            {
                _context.Saches.Add(sach);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            taoDSTheLoai();
            return View(sach);
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
