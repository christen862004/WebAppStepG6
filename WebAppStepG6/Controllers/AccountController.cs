using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebAppStepG6.Models;
using WebAppStepG6.ViewModels;

namespace WebAppStepG6.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel userFromRequest)//come front
        {
            if (ModelState.IsValid)
            {
                ApplicationUser appUser = new ApplicationUser()
                {
                    UserName=userFromRequest.UserName,
                    PasswordHash=userFromRequest.Password,
                    Address=userFromRequest.Address
                };
                //add user db
               IdentityResult result= await  userManager.CreateAsync(appUser, userFromRequest.Password);
                if(result.Succeeded)
                {
                    //assign admin role to user
                    await userManager.AddToRoleAsync(appUser, "Admin");
                    //create cookie
                    await signInManager.SignInAsync(appUser, false);
                    return RedirectToAction("Index", "Employee");

                }
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
            }
            
            return View("Register",userFromRequest);
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                //check ddb
                ApplicationUser appUser=await userManager.FindByNameAsync(userFromReq.UserName);
                if (appUser!=null)
                {
                    bool found= await userManager.CheckPasswordAsync(appUser, userFromReq.Password);
                    if (found)
                    {
                        List<Claim> extraClaim = new List<Claim>();
                        extraClaim.Add(new Claim("Address",appUser.Address));
                        //cookie
                        await signInManager.SignInWithClaimsAsync(appUser, userFromReq.RememberMe, extraClaim);//id,username ,email? ,role? +extar claim
                        return RedirectToAction("Index", "Employee");
                    }

                }
                ModelState.AddModelError("", "Invalid Account");
            }
            return View("Login",userFromReq);
        }
        #endregion

        #region SignOUT
        public async Task<IActionResult> SignOut() {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");

         }
        #endregion
    }
}
