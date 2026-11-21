using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenHuuHoanh_241230736.Models;

namespace NguyenHuuHoanh_241230736.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly DeThiContext _db;
        public HangHoaController(DeThiContext db) { _db = db; }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(HangHoa model)
        {
            ModelState.Remove("MaLoaiNavigation");
            if (ModelState.IsValid)
            {
                _db.HangHoas.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.MaLoai = new SelectList(_db.LoaiHangs, "MaLoai", "TenLoai", model.MaLoai);
            return View(model);
        }
    }
}
