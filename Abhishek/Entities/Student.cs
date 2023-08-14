using System.ComponentModel.DataAnnotations;

namespace Abhishek.Entities
{
    public class Student
   
        {
        public int RollNumber { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "PLease enter Student Name in correct format")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "PLease enter Student Class in correct format")]
        public string Class { get; set; }

        }
    }

