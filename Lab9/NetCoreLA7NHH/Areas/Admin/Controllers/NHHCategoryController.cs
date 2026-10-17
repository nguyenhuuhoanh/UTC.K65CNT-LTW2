// Author: NHH

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreLA7NHH.Data;
using NetCoreLA7NHH.Helpers;
using NetCoreLA7NHH.Models;

namespace NetCoreLA7NHH.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NHHCategoryController : Controller
    {
        private readonly NHHAppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public NHHCategoryController(NHHAppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> NHHIndex()
        {
            var list = await _context.NHHCategories.OrderByDescending(x => x.Id).ToListAsync();
            return View(list);
        }

        public async Task<IActionResult> NHHDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _context.NHHCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        public async Task<IActionResult> NHHCreate()
        {
            
            return View(new NHHCategory());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NHHCreate(NHHCategory model)
        {
            await NHHValidate(model);
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }
            model.Image = await NHHFileHelper.SaveImageAsync(model.ImageFile, _env, "categories");
            _context.Add(model);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Thêm mới thành công";
            return RedirectToAction(nameof(NHHIndex));
        }

        public async Task<IActionResult> NHHEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _context.NHHCategories.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NHHEdit(int id, NHHCategory model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            var item = await _context.NHHCategories.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            await NHHValidate(model);
            if (!ModelState.IsValid)
            {
                model.Image = item.Image;
                
                return View(model);
            }
            item.Name = model.Name;
            item.Status = model.Status;
            item.CreatedDate = model.CreatedDate;
            item.Description = model.Description;
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                NHHFileHelper.DeleteFile(item.Image, _env);
                item.Image = await NHHFileHelper.SaveImageAsync(model.ImageFile, _env, "categories");
            }
            await _context.SaveChangesAsync();
            TempData["Success"] = "Cập nhật thành công";
            return RedirectToAction(nameof(NHHIndex));
        }

        public async Task<IActionResult> NHHDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await _context.NHHCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        [HttpPost, ActionName("NHHDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NHHDeleteConfirmed(int id)
        {
            var item = await _context.NHHCategories.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            try
            {
                _context.NHHCategories.Remove(item);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                TempData["Error"] = "Không thể xóa vì dữ liệu đang được sử dụng";
                return RedirectToAction(nameof(NHHIndex));
            }
            NHHFileHelper.DeleteFile(item.Image, _env);
            TempData["Success"] = "Xóa thành công";
            return RedirectToAction(nameof(NHHIndex));
        }

        private async Task NHHValidate(NHHCategory model)
        {
            if (!string.IsNullOrWhiteSpace(model.Name)
                && await _context.NHHCategories.AnyAsync(x => x.Name == model.Name && x.Id != model.Id))
            {
                ModelState.AddModelError("Name", "Tên đã tồn tại");
            }
            if (!NHHFileHelper.IsValidImage(model.ImageFile))
            {
                ModelState.AddModelError("ImageFile", "Chỉ chấp nhận ảnh jpg, png, gif, webp tối đa 2MB");
            }
        }
    }
}
