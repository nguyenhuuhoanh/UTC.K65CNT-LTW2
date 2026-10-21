using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Lab1.Models;
using System.IO; //cai nay de upload avt

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        private List<Student> listStudents = new List<Student>();
        public StudentController()
        {
            listStudents = new List<Student>()
            {
                new Student()
                {
                    Id = 101,
                    Name = "Hải Nam",
                    Branch = Branch.IT,
                    Gender = Gender.Male,
                    IsRegular = true,
                    Address = "A1-2018",
                    Email = "nam@g.com"
                },
                new Student()
                {
                    Id = 102,
                    Name = "Minh Tú",
                    Branch = Branch.BE,
                    Gender = Gender.Female,
                    IsRegular = true,
                    Address = "A1-2019",
                    Email = "tu@g.com"
                },
                new Student()
                {
                    Id = 103,
                    Name = "Hoàng Phong",
                    Branch = Branch.CE,
                    Gender = Gender.Male,
                    IsRegular = false,
                    Address = "A1-2020",
                    Email = "phong@g.com"
                },
                new Student()
                {
                    Id = 104,
                    Name = "Xuân Mai",
                    Branch = Branch.EE,
                    Gender = Gender.Female,
                    IsRegular = false,
                    Address = "A1-2021",
                    Email = "mai@g.com"
                },
             };
        }
        //cau hinh route
        [Route("Admin/Student/List", Name = "StudentList")]
        public IActionResult Index()
        {
            return View(listStudents);
        }

        //create
        [Route("Admin/Student/Add", Name = "StudentAdd")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Admin/Student/Add", Name = "Add")]
        [HttpPost]
        public IActionResult Create(Student s, IFormFile AvatarFile)
        {
            if (AvatarFile != null && AvatarFile.Length > 0)
            {
                
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", AvatarFile.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    AvatarFile.CopyTo(stream);
                }
            }
            if (AvatarFile != null && AvatarFile.Length > 0)
            {
                s.AvatarUrl = "/images/" + AvatarFile.FileName;
            }


            s.Id = listStudents.Last<Student>().Id + 1;
            listStudents.Add(s);
            return View("Index", listStudents);
        }
            
    }
}
