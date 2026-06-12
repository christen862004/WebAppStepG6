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
        #region New
        [HttpGet]
        public IActionResult New()
        {
            return View("New");//Model null
        }
        //Department/SaveNew? Name = &ManagerName =
        [HttpPost]//requet method type
        public IActionResult SaveNew(Department deptFromRequest)
        {
            //if(Request.Method == "POST") { }
            //Department dept = new Department();
            //dept.Name = name;
            //dept.ManagerName = ManagerName1;
            //valiadte data come user
            if(deptFromRequest.Name != null)
            {
                //saev
                context.Departments.Add(deptFromRequest);
                context.SaveChanges();
                // List<Department> deptlist = context.Departments.ToList();

                return RedirectToAction(actionName: "Index", controllerName: "Department");
            }
            return View("New", deptFromRequest);

        }
        #endregion
    }
}
