using System.ComponentModel.DataAnnotations;

namespace Abhishek.Entities
{
    public class Employee
    {
        public int Id{ get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$",ErrorMessage = "PLease enter Employee Name in correct format")]
        public string Name { get; set; }
       [Required]
       [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "PLease enter Employee Location in correct format")]
        public string Location { get; set; }

    }
}
