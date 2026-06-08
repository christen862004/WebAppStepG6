namespace WebAppStepG6.ViewModels
{
    public class EmpWithMsgTempColorDeptListViewModel
    {
        //1,2) some Model Data ,hide Struct
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        //3) Add Extra Data
        public int Temp { get; set; }
        public string Message { get; set; }
        public string Color { get; set; }
        //4) Megre with another Model
        public List<string> DeptList { get; set; }
    }
}
