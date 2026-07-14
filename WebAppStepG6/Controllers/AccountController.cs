using Microsoft.AspNetCore.Mvc;
using WebAppStepG6.Models;
using WebAppStepG6.ViewModels;

namespace WebAppStepG6.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel userFromRequest)//come front
        {
            if (ModelState.IsValid)
            {
                //add user db
                //create cookie
            }
            
            return View("Register",userFromRequest);
        }
    }
}
