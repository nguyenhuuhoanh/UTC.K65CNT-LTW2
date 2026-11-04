using Lab06.Data;
using Lab06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Lab06.Controllers
{
    public class LearnerController : Controller
    {
        private SchoolContext db;
        public LearnerController(SchoolContext context)
        {
            db = context;
        }
        // So phan tu tren 1 trang
        private int pageSize = 3;

        public IActionResult Index(int? mid)
        {
            var learners = (IQueryable<Learner>)db.Learners
                .Include(m => m.Major);
            if (mid != null)
            {
                learners = learners.Where(l => l.MajorID == mid);
                ViewBag.mid = mid;
            }
            // tinh so trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            // tra so trang ve view de hien thi nav-trang
            ViewBag.pageNum = pageNum;
            // lay du lieu trang dau
            var result = learners.OrderBy(l => l.LearnerID).Take(pageSize).ToList();
            return View(result);
        }

        public IActionResult LearnerFilter(int? mid, string? keyword, int? pageIndex)
        {
            // lay toan bo learners chuyen sang IQueryable<Learner> de query
            var learners = (IQueryable<Learner>)db.Learners;
            // chi so trang, neu null hoac <= 0 thi mac dinh 1
            int page = (int)(pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            // loc theo chuyen nganh
            if (mid != null)
            {
                learners = learners.Where(l => l.MajorID == mid);
                ViewBag.mid = mid;
            }
            // tim kiem theo ten
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var kw = keyword.ToLower();
                learners = learners.Where(l => l.FirstMidName.ToLower().Contains(kw));
                ViewBag.keyword = keyword;
            }
            // tinh so trang
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
            ViewBag.pageNum = pageNum;
            // chon du lieu trang hien tai
            var result = learners.OrderBy(l => l.LearnerID)
                                 .Skip(pageSize * (page - 1))
                                 .Take(pageSize)
                                 .Include(m => m.Major)
                                 .ToList();
            return PartialView("LearnerTable", result);
        }

        public IActionResult Create()
        {
            var majors = new List<SelectListItem>();
            foreach (var item in db.Majors)
            {
                majors.Add(new SelectListItem
                {
                    Text = item.MajorName,
                    Value = item.MajorID.ToString()
                });
            }

            ViewBag.MajorID = majors;
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName"); //cách 2
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        public IActionResult Edit(int id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }

            ViewBag.MajorId = new SelectList(
                db.Majors, "MajorID", "MajorName", learner.MajorID);

            return View(learner);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            int id,
            [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")]
            Learner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.MajorId = new SelectList(
                db.Majors, "MajorID", "MajorName", learner.MajorID);

            return View(learner);
        }

        private bool LearnerExists(int id)
        {
            return (db.Learners?.Any(e => e.LearnerID == id))
                .GetValueOrDefault();
        }

        public IActionResult Delete(int id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Include(l => l.Major)
                .Include(e => e.Enrollments)
                .FirstOrDefault(m => m.LearnerID == id);

            if (learner == null)
            {
                return NotFound();
            }

            if (learner.Enrollments.Count() > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }

            return View(learner);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null)
            {
                return Problem("Entity set 'Learners' is null.");
            }

            var learner = db.Learners.Find(id);

            if (learner != null)
            {
                db.Learners.Remove(learner);
            }

            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
