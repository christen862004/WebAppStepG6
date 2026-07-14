using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppStepG6.Models;

namespace WebAppStepG6.Controllers
{
    /*
     * deal with class as contoller
     1) class name suffix  (endwith ) Controller
     2) class inherit from Controller class
     */
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       
        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }
        /* MEthod call Action
         * 1) Method must public
         * 2) Method Cant Static
         * 3) Method cant overload (only in one case)
         */
        //url :/Home/ShowMsg  "endpoint"
        
        public ContentResult ShowMsg()
        {
            //Logic
            //Decalre
            ContentResult result = new ContentResult();
            //Fill
            result.Content = "Hello World :)";
            //return
            return result;
        }
        //Home/ShowView
        public ViewResult ShowView()
        {
            //logic
            //declare
            ViewResult result = new ViewResult();
            //fill data
            result.ViewName = "View1";//
            //return
            return result;
        }
        //endpoint ==>no ==13 string ,!=13 view
        //home/ShowMix?no=12&id=11&name=ahme
        //home/ShowMix [Route Value]
        //?no=12&id=11&name=ahme [Query String]
        //-----------------------------
        //home/ShowMix/99?no=12&name=ahme
        //home/ShowMix/99 [Route Value]
        //?no=12&name=ahme [Query String]
        public IActionResult ShowMix(int no,int id,string name)
        {
            if(no==13)
            {
                //NotFoundResult resul = new NotFoundResult;
                //Decalre
                return Content("hello");
            }
            else
            {
                //declare
                return View("View1");
            }
        }

        //public ViewResult View(string viewName)
        //{
        //    //declare
        //    ViewResult result = new ViewResult();
        //    //fill data
        //    result.ViewName = viewName;//
        //                              //return
        //    return result;
        //}


        /*
         * what action can return actionResult
         * 1) Content   => ContentResult
         * 2) View      => ViewResult
         * 3) Json      => JsonReuslt
         * 4) NotFound  => NotFoundReuslt
         * 5) Unauthorize =>authorizeResult
         * ......
         
         */



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
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
