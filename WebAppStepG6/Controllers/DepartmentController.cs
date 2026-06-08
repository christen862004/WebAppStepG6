using Microsoft.AspNetCore.Mvc;
using WebAppStepG6.Models;

namespace WebAppStepG6.Controllers
{
    public class DepartmentController : Controller
    {
        StepsContext context = new StepsContext();
        public DepartmentController()
        {
            
        }
        public IActionResult Index()
        {
            List<Department> deptlist= context.Departments.ToList();
            return View("Index",deptlist);
        }
    }
}
