using System.ComponentModel.DataAnnotations;

namespace WebAppStepG6.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value.ToString();
            Employee? empFromReq = validationContext.ObjectInstance as Employee;
            //empFromReq.ID!=0 edit ,=0 new
            StepsContext context = new StepsContext();
            //valiadtion name with departmen
            Employee empfromDB= context.Employees.FirstOrDefault(e=>e.Name== name &&e.DepartmentId==empFromReq.DepartmentId);
            if(empfromDB==null) {
                return ValidationResult.Success;
            }
            return new ValidationResult("Name Already Exist :(");
        }
    }
}
