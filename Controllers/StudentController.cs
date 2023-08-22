using Intro.Models;
using Microsoft.AspNetCore.Mvc;

namespace Intro.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> studentList = new List<Student>()
        {
            new Student(){Id = 1,FirstName = "John",LastName = "Emma",Email = "joe@yahoo.com",Age = 12},
            new Student(){Id = 2,FirstName = "Akin",LastName = "Berk",Email = "ak@yahoo.com",Age = 43},
            new Student(){Id = 3,FirstName = "Femi",LastName = "Azeez",Email = "az@yahoo.com",Age = 25}
        };
        private int studentNo = 3;
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Header = "Elev8 Training Institution";
            ViewData["Motor"] = "A Training Instute Like No Other";
            return View();
        }

        public IActionResult Detail(int id)
        {
            var stu = from student in studentList
                      where student.Id == id
                      select student;
            Student st =  stu.ToList()[0];
            return View(st);
        }

        [HttpGet]
        [ActionName("Display")]
        public IActionResult List()
        {
            return View(studentList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string firstName, string lastName, string email, int age)
        {
            Student student = new Student() { Id = ++studentNo, FirstName = firstName, LastName = lastName, Email = email, Age = age};
            studentList.Add(student);
            return View("Display", studentList);
            
        }
        [NonAction]
        public String GetFirstName()
        {
            return studentList[0].FirstName;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var student = from st in studentList
                          where st.Id == id
                          select st;

            Student stu = student.ToList()[0];

            return View(stu);
        }

        [HttpPost]
        public IActionResult Edit(int id, string firstName, string lastName, string email, int age)
        {
            var student = from st in studentList
                          where st.Id == id
                          select st;

            Student stu = student.ToList()[0];

            stu.FirstName = firstName;
            stu.LastName = lastName;
            stu.Email = email;
            stu.Age = age;



            return View("Detail", stu);
        }
    }
}
