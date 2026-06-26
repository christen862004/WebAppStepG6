using Microsoft.AspNetCore.Mvc;
using WebAppStepG6.Models;
using WebAppStepG6.Repository;

namespace WebAppStepG6.Controllers
{
    public class BindController : Controller
    {
        /*
         MEthod=>action
        1_p[ublic
        2- no overload )one case
        3- not static
         */
        //Bind/method1
        [HttpGet]
        public IActionResult method1()
        {

            return Content("M1 get");
        }
     
        //Bind/method1
        //Bind/m-ethod1?no=12
        [HttpPost]
        public IActionResult method1(int no)
        {
            return Content("M1 post");
        }
        /**
         <form method="post" action="http://localhost:27103/bind/test">
        <div>
            <label>UserNAme</label>
            <input type="text" name="username">
        </div>
        <div>
            <label>Password</label>
            <input type="password" name="PWS">
        </div>
        <div>
            <label>id</label>
            <input type="number" name="id">
            <input type="text" name="phoneBook[ahmed]">
        </div>
        <input type="number" name="age">
        <input type="submit" value="Register">
         </form>
         */
        //Bind/Test/1?username=ahmed
        //Bind/Test?username=ahmed&id=99&color[0]=red
        //Test types : primitiet int ,string ,arr
        public IActionResult test(string username,string PWS,string[] color,int id)
        {
            return Content("hiiiiii");
        }

        //test Collect "List",Dic
        //Bind/TestDic?name=christen&phoneBook[ahmed]=123&phoneBook[mohamed]=456
        public IActionResult TestDic(string name,Dictionary<string,string> phoneBook)
        {
            //phoneBook["ahmed"]="123"
            return Content("hiiiiii");
        }

        //Test object custom class
        //http://localhost:27103/bind/testobj?name=.net&id=10&employees[0].Name=mohamed
        public IActionResult TestObj(Department dept)
       // public IActionResult TestObj(int Id, string Name, string? ManagerName, List<Employee> Employees)
        {
            //1) create object dept=new Department()
            //2) search abput public propety inside this object (
            return Content("hiiiiii");

        }
    }
}
