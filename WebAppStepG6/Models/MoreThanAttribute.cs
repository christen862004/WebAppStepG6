using System.ComponentModel.DataAnnotations;

namespace WebAppStepG6.Models
{
    public class MoreThanAttribute:ValidationAttribute
    {
        public MoreThanAttribute(int min)
        {
            Min = min;
        }
        public int Min { get; set; }
        public override bool IsValid(object? value)
        {
            int no = int.Parse(value.ToString());
            if (no > Min)
            {
                return true;
            }
            return false;
        }
    }
}
