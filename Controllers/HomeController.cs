using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Practical_Exam.Models;

namespace Practical_Exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //Task 1: The Variables and Data Types

            string studentName = "Valencia, Lorene Mikyle A.";
            int score = 87;
            bool isPassed = (score >= 75);
            DateTime examDate = DateTime.Now;
            decimal tuitionFee = 15500.75m;

            ViewBag.studentName = studentName;
            ViewBag.score = score;
            ViewBag.isPassed = isPassed;
            ViewBag.examDate = examDate;
            ViewBag.tuitionFee = tuitionFee;

            //Task 2: Operators and Control Structures

            string grade;
            if (score >= 90)
                grade = "A";
            else if (score >= 80)
                grade = "B";
            else if (score >= 75)
                grade = "C";
            else
                grade = "F";


            string message;
            if (isPassed == true)
                message = "Congratulations, You Have Passed!✅✨";
            else message = "You Failed!❌😭☠️";

            ViewBag.grade = grade;
            ViewBag.isPassed = isPassed;
            ViewBag.message = message;

            //Task 3: Loops and Collections 
            string[] courses = {"Web Systems", "OOP", "DBMS", "UI/UX", "Networking"};
            string courseContatenated = string.Join(", ", courses);
            int courseCount = courses.Length;

            ViewBag.courses = courseContatenated;
            ViewBag.courseCount = courseCount;

            //Task 4: Calling Method
            decimal netFee = ComputeNetFee(tuitionFee, 10);

            ViewBag.netFee = netFee;

            //Date Formatting {Bonus✅}
            ViewBag.Today = new DateTime(2025, 7, 18).ToString("MMMM dd, yyyy");
            //ViewBag.Today = DateTime.Now.ToString("MMMM dd, yyyy");



            //Part 2: Objects and Lists (Task 5)
            Student student = new Student
            {
                Name = "Maria Santos",
                Age = 20,
                Course = "Web Systems"
            };

            ViewBag.Student = student;

            //Task 6: List of Students
            List<Student> students = new List<Student>
            {
                new Student {Name = "Maria Santos", Age = 20, Course = "Web Systems"},
                new Student {Name = "Pedro Ramirez", Age = 21, Course = "OOP"},
                new Student {Name = "Angelica Reyes", Age = 22, Course = "DBMS"}
            };

            ViewBag.students = students;







            return View();
        }


        //Task 4: Method
        private decimal ComputeNetFee (decimal tuition, decimal discountPercent)
        {
            return tuition - (tuition * discountPercent / 100);
        }

        public IActionResult AboutMe()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
