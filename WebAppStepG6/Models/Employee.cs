using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppStepG6.Models
{
    //valiadtion appliaction level
    public class Employee
    {
        public int Id { get; set; }
        // [Required]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Name must be beween 3 letter to 50 letter")]//default message error
        [Unique]
        public string Name { get; set; }
        [RegularExpression(@"[a-z0-9]+\.(jpg|png)",ErrorMessage ="Image must be jpg or png")]//ask.png
        public string? ImageUrl { get; set; }//Regular Expression decalre pattern
                                             // [Range(7000,50000)]
                                             //[MoreThan(6000)]//server side
        [Remote(action:"CheckSalary",controller:"Employee",AdditionalFields = "DepartmentId")]
        public int Salary { get; set; }//Employee/CheckSalary?Salary=10000
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
