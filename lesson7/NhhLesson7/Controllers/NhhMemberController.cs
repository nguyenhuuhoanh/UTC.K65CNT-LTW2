using Microsoft.AspNetCore.Mvc;
using NhhLesson7.Models;
using System.Collections.Immutable;

namespace NhhLesson7.Controllers
{
    public class NhhMemberController : Controller
    {
        private static List<NhhMember> nhhMembers = new List<NhhMember>();

        public IActionResult Index()
        {
            return View(nhhMembers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(NhhMember member)
        {
            if (!ModelState.IsValid)
            {
               return View(member);
            }
            member.Id = nhhMembers.Count + 1;
            nhhMembers.Add(member); 
            return RedirectToAction(nameof(Index));
           
        }
    }
}