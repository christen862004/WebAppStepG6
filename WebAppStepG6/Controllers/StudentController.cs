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
    }
}
