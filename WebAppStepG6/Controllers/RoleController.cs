using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebAppStepG6.ViewModels;

namespace WebAppStepG6.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManger;

        public RoleController(RoleManager<IdentityRole> roleManger)
        {
            this.roleManger = roleManger;
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]//check cookie + check claim role :dmin
        public IActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]//check cookie + check claim role :dmin

        public async Task<IActionResult> Create(RoleViewModel roleFromReq)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleFromReq.RoleName;
                //create
                IdentityResult result= await  roleManger.CreateAsync(role);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Department");
                }
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
            }
            return View("Create",roleFromReq);
        }
    }
}
