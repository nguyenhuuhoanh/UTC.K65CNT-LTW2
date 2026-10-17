// Author: NHH

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreLA7NHH.Data;

namespace NetCoreLA7NHH.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NHHDashboardController : Controller
    {
        private readonly NHHAppDbContext _context;

        public NHHDashboardController(NHHAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> NHHIndex()
        {
            ViewBag.CategoryCount = await _context.NHHCategories.CountAsync();
            ViewBag.ProductCount = await _context.NHHProducts.CountAsync();
            ViewBag.BlogCount = await _context.NHHBlogs.CountAsync();
            ViewBag.BannerCount = await _context.NHHBanners.CountAsync();
            return View();
        }
    }
}
