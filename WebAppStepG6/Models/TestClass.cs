using System.Runtime.InteropServices;

namespace WebAppStepG6.Models
{
    public class TestClass
    {
        //dynamic pro;
        public void method1()
        {
            Myclass cc = new Myclass();
            cc.ViewBag = "Heelo";
            cc.ViewData = "Steps";

            Console.WriteLine(cc.ViewBag);


            //Close type
            //create object
            Parent<int> p = new();
            p.Model = 11;
            Parent<string> p1 = new();
            p1.Model = "11";
            Child<int> c1 = new();
            c1.Model = 11;
            Child2 c2 = new();
            c2.Model = "jhjh";
            //object boxing ,unboxing
            int no = 10;
            string name = "ahmed";
            Student student = new Student();
          //  student = no + name;
        }
    }
    class Parent<T>//Open type
    {
        public T Model { get; set; }
    }
    //open
    class Child<T>:Parent<T>
    {

    }
    //close
    class Child2 : Parent<string>
    {

    }
    class Myclass
    {
        object _viewData;
        public object ViewData { 
            get {
                return _viewData;
            
            } set {
                _viewData = value;
            } 
        }
        public dynamic ViewBag
        {
            get
            {
                return _viewData;

            }
            set
            {
                _viewData = value;
            }
        }
    }
}
