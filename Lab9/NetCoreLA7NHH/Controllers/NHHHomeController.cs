// Author: NHH

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreLA7NHH.Data;
using NetCoreLA7NHH.Models;

namespace NetCoreLA7NHH.Controllers
{
    public class NHHHomeController : Controller
    {
        private readonly NHHAppDbContext _context;

        public NHHHomeController(NHHAppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> NHHIndex()
        {
            var model = new NHHHomeViewModel
            {
                Banners = await _context.NHHBanners
                    .Where(x => x.Status == 1)
                    .OrderByDescending(x => x.Priority)
                    .ToListAsync(),
                Products = await _context.NHHProducts
                    .Include(x => x.Category)
                    .Where(x => x.Status == 1)
                    .OrderByDescending(x => x.Id)
                    .Take(9)
                    .ToListAsync()
            };
            return View(model);
        }

        public IActionResult NHHAbout()
        {
            return View();
        }

        public IActionResult NHHContact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult NHHError()
        {
            return View(new NHHErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
