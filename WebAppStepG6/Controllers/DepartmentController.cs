using Microsoft.AspNetCore.Mvc;
using WebAppStepG6.Models;
using WebAppStepG6.Repository;

namespace WebAppStepG6.Controllers
{
    public class DepartmentController : Controller
    {
        // StepsContext context = new StepsContext();
        IDepartmentRepository deptRepo;
        public DepartmentController(IDepartmentRepository _deprepo)
        {
            deptRepo = _deprepo;//new DepartmentRepository();
           
        }
        public IActionResult Index()
        {
            List<Department> deptlist=deptRepo.GetAll();
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
                deptRepo.Add(deptFromRequest);
                deptRepo.Save();
                // List<Department> deptlist = context.Departments.ToList();

                return RedirectToAction(actionName: "Index", controllerName: "Department");
            }
            return View("New", deptFromRequest);

        }
        #endregion
    }
}
