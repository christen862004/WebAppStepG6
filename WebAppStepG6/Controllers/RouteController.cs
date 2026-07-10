using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAppStepG6.Filtters;

namespace WebAppStepG6.Controllers
{
    // [Route("r")]
   // [HandelError]//action scope

    public class RouteController : Controller
    {

        //Route/Method1/1
        //r1?age=12&name=ahmed&id=1
        //r1/12/ahmed
        //r1/22/mohamed
        //r1/10/basma
        //r1/10
        //[Route("/m1/{age:int:range(20,60)}/{name?}")] //ignor defualt route  r/m1/22/ahm,ed
        //[HttpGet("/m1/{age}/{name}")]
        [HandelError]
        public IActionResult Method1(int age,string name,int id)
        {
            throw new Exception("Some exception happen");  
            return Content("M1  ");
        }
        //r2
        //[Route("m2")] //ignor defualt route
        public IActionResult Method2()
        {
            throw new Exception("Some exception happen");

            return Content("M2  ");
        }
    }
}
