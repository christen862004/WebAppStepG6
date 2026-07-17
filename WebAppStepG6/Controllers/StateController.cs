using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WebAppStepG6.Controllers
{
    public class StateController : Controller
    {
        //[Authorize]
        public IActionResult Welcome()
        {
            
            if(User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                {
                    return Content($"Welcome {User.Identity.Name} \tAdmin");

                }
                Claim idClaim = User.Claims.FirstOrDefault(c=>c.Type==ClaimTypes.NameIdentifier);
                string id = idClaim.Value;


                Claim addressClaim = User.Claims.FirstOrDefault(c => c.Type == "Address");

                return Content($"Welcome {User.Identity.Name} \t id={id}\t address={addressClaim.Value}");


            }
            //Gust

            return Content("Welcome Gust");
        }


        //State/Setsession?name=ahmed&age=12
        public IActionResult SetSession(string name,int age)
        {
            //serializ eot json ==>string
            //logic
            //In session per user "server"
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", age);
            return Content("session save success");
        }

        public IActionResult GetSession()
        {
            string n= HttpContext.Session.GetString("Name");
            int? a = HttpContext.Session.GetInt32("Age");

            return Content($"Name={n}\t Age={a}");
        }

        public IActionResult SetCookie(string  name,int age)
        {
            //session cookie
            HttpContext.Response.Cookies.Append("Name", name);
            //Persistent cookie
            CookieOptions options = new CookieOptions();
            options.Expires = DateTimeOffset.Now.AddHours(1);

            HttpContext.Response.Cookies.Append("Age", age.ToString(),options);

            return Content("Cookie Success");
        }
        public IActionResult GetCookie() {
            string n = HttpContext.Request.Cookies["Name"];
            string a = HttpContext.Request.Cookies["Age"];
            return Content($"name={n}\tage={a}");
        }
    }
}
