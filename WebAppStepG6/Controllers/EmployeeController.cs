using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAppStepG6.Models;
using WebAppStepG6.ViewModels;

namespace WebAppStepG6.Controllers
{
    public class EmployeeController : Controller
    {
        StepsContext context=new StepsContext();

        public IActionResult Index()
        {
            return View("Index", context.Employees.ToList());//view =Index,Model List<employee>
        }
       // http://localhost:27103/Employee/CheckSalary?Salary=1000
        public IActionResult CheckSalary(int Salary,int DepartmentId)
        {
            if (Salary > 7000)
                return Json(true);
            else
                return Json("Saalry Must Be More Than 7000");//
        }

        #region NEw
        public IActionResult New()
        {
            ViewBag.DeptList = context.Departments.ToList();
            return View("New");
        }
        [HttpPost]
        public IActionResult SaveNew(Employee empFromReq) {
            if(ModelState.IsValid==true)
            {
                try
                {
                    context.Employees.Add(empFromReq);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Employee");
                }catch (Exception ex)
                {
                    //send exception front add cusotm error in modelstate
                    ModelState.AddModelError("ExKey", ex.InnerException.Message);

                }
            }
            ViewBag.DeptList = context.Departments.ToList();
            return View("New",empFromReq);
        
        }
        #endregion
        #region Edit
        //Employee/edit/177
        public IActionResult Edit(int id)
        {
            //get org emp from db
            Employee empFromDb = context.Employees.FirstOrDefault(e => e.Id == id);
            List<Department> departmentList = context.Departments.ToList();
            //IEnumerable<SelectListItem> items = departmentList;
            if (empFromDb!=null)
            {
                EmpWithDeptListViewModel empVM = new EmpWithDeptListViewModel()
                {
                    EmpId = empFromDb.Id,
                    DepartmentId = empFromDb.DepartmentId,
                    EmpName=empFromDb.Name,
                    Salary=empFromDb.Salary,
                    ImageUrl=empFromDb.ImageUrl,
                    DeptList=departmentList
                };
                return View("Edit", empVM);
            }
            //send view display
            return NotFound();
        }
        //Post
        [HttpPost]
        public IActionResult SaveEdit(EmpWithDeptListViewModel empFromReq,int id)
        {
            //valiadtion
            if(empFromReq.EmpName!=null) { 
                //org obj
                Employee empFromDb=context.Employees.FirstOrDefault(e=>e.Id==id);
                //chage
                empFromDb.Name=empFromReq.EmpName;
                empFromDb.Salary=empFromReq.Salary;
                empFromDb.ImageUrl=empFromReq.ImageUrl;
                empFromDb.DepartmentId=empFromReq.DepartmentId;
                //save
                context.SaveChanges();
                return RedirectToAction("Index", "Employee");
            }
            empFromReq.EmpId = id;
            empFromReq.DeptList = context.Departments.ToList();
            return View("Edit", empFromReq);
        }
        #endregion
        
        #region Details


        public IActionResult Details(int id,string name)
        {
            string msg = "hello";
            int temp = 10;
            List<string> DeptList=context.Departments.Select(x => x.Name).ToList();
            ViewData["Msg"] = msg;
            ViewData["Temp"] = temp;
            ViewData["DeptList"] = DeptList;
            ViewData["Color"] = "Blue";//override , throe exception ,separate
            ViewBag.Color = "red";

            Employee empModel= context.Employees.FirstOrDefault(e => e.Id == id);
            return View("Details",empModel);
        }
        public IActionResult DetailsVM(int id)
        {
            //Collect data from differnt souce
            string msg = "hello";
            int temp = 10;
            List<string> DeptList = context.Departments.Select(x => x.Name).ToList();
         
            Employee empModel = context.Employees.FirstOrDefault(e => e.Id == id);
            //declare ViewModel object - Mapping
            EmpWithMsgTempColorDeptListViewModel EmpVM = new() { 
                EmpId=empModel.Id,
                EmpName=empModel.Name,
                Temp=temp,
                Message=msg,
                Color="red",
                DeptList=DeptList
            };
            return View("DetailsVM", EmpVM);//go view DetailsVM , Model EmpWithMsgTempColorDeptListViewModel
        }
        #endregion
    }
}
