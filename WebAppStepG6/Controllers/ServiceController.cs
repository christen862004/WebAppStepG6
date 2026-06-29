using Microsoft.AspNetCore.Mvc;
using System.CodeDom;
using WebAppStepG6.Repository;

namespace WebAppStepG6.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IService service;

        public ServiceController(IService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            ViewBag.Id = service.Id;
            return View("Index");
        }
    }
}
