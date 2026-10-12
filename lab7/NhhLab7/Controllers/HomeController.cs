using Microsoft.AspNetCore.Mvc;
using NhhLab7.Models;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NhhLab7.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<nhhLab7> nhhLab7s = new List<nhhLab7>();
            return View(nhhLab7s);
        }

        public IActionResult Create()
        {
            nhhLab7 model = new nhhLab7();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AcceptVerbs("GET","POST")]
        public IActionResult verifyPhone(string Phone)
        {
            Regex _isPhone = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
            if (!_isPhone.IsMatch(Phone))
            {
                return Json("Phone is not valid");
            }
            return Json(true);
        }
    }
}
