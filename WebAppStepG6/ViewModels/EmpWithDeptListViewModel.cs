
using System.ComponentModel.DataAnnotations;
using WebAppStepG6.Models;

namespace WebAppStepG6.ViewModels
{
    public class EmpWithDeptListViewModel
    {
        public int EmpId { get; set; }
        [Display(Name ="Employee  - Name")]
        //????
        //[DataType(DataType.Password)]
        public string EmpName { get; set; } //string =>text,int=>number , bool=>check
        public string? ImageUrl { get; set; }
        public int Salary { get; set; }
        public int DepartmentId { get; set; }

        public List<Department>? DeptList { get; set; }
    }
}
