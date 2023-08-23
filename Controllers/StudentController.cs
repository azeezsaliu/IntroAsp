using Intro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
            //ViewBag.Header = "Elev8 Training Institution";
            //ViewData["Motor"] = "A Training Instute Like No Other";
            return View();
        }

        public IActionResult Detail([FromRoute]  int id)
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
            Student student = new Student();
            return View(student);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Student student)
        {

            if (ModelState.IsValid)
            {
                /*
                ModelState.AddModelError(nameof(Student.FirstName), "First name is Compulsory");
                if (ModelState.GetValidationState(nameof(Student.FirstName)) != ModelValidationState.Valid)
                {
                    ModelState.AddModelError(nameof(Student.FirstName), "First name is Compulsory");
                }
                if (ModelState.GetValidationState("LastName") != ModelValidationState.Valid)
                {
                    ModelState.AddModelError("LastName", "Last name is Compulsory");
                }
                */
                //Student student = new Student() { Id = ++studentNo, FirstName = firstName, LastName = lastName, Email = email, Age = age};
                studentList.Add(student);
                TempData["Message"] = student.FirstName + " is successfully created";
                //return View("Display", studentList);

                return RedirectToAction("Display");
            }
            else
            {
                return View(student);
            }
            
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
        public IActionResult Edit(Student studentObj)
        {
            var student = from st in studentList
                          where st.Id == studentObj.Id
                          select st;

            Student stu = student.ToList()[0];

            int index = studentList.IndexOf(stu);

            

            studentList.RemoveAt(index);
            studentList.Insert(index, studentObj);

            return View("Detail", studentObj);
        }
    }
}
