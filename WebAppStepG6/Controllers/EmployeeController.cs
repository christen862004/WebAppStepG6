using Microsoft.AspNetCore.Mvc;
using WebAppStepG6.Models;
using WebAppStepG6.ViewModels;

namespace WebAppStepG6.Controllers
{
    public class EmployeeController : Controller
    {
        StepsContext context=new StepsContext();
        public IActionResult Details(int id)
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
    }
}
