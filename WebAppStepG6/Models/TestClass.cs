using Microsoft.Identity.Client;
using NuGet.Common;
using System.Runtime.InteropServices;

namespace WebAppStepG6.Models
{
    interface ISort
    {
        void Sort(int[] arr);
    }
    class BubbleSort:ISort
    {
        public void Sort(int[] arr)
        {

        }
    }
    class ChrisSort : ISort
    {
        public void Sort(int[] arr)
        {

        }
    }
    //extend
    class SelectionSort:ISort
    {
        public void Sort(int[] arr) { }
    }
    //DIP :based on abstrat ,interface
    class MyList//high level
    {
        int[] arr;
        ISort sortAlg; //low level
        public MyList(ISort _sortAlg)//injection dont create but ask "create myllist"
        {
            arr=new int[10];
            sortAlg = _sortAlg;//new BubbleSort();//??? specific type
        }
        public void SortList()
        {
            sortAlg.Sort(arr);
        }

    }
    class testClass2
    {
        public void Test()
        {
            MyList l1 = new MyList(new BubbleSort());
            l1.SortList();//using bubble
            MyList l2 = new MyList(new ChrisSort());
            l2.SortList();//using SelectionSort

        }
    }













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
