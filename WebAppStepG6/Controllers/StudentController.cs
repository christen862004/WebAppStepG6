using Microsoft.AspNetCore.Mvc;
using WebAppStepG6.Models;

namespace WebAppStepG6.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studntBl=new StudentBL();

        //Studet/all
        public IActionResult All()
        {
            List<Student> students= studntBl.GetAll();
            return View("ShowAll",students);//goto viwq ,List<student>
        }
        //Views/Student/ShowAll.cshtml
        //Views/Shared/ShowAll.cshtml
        public IActionResult Details(int id)
        {
            Student std=studntBl.GetById(id);
            if (std == null)
                return NotFound();
            return View("Details",std);//go to view Details =Model Student
        }
    }
}
