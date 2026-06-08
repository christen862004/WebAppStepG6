using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppStepG6.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageUrl { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
