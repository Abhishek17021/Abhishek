using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Abhishek.Model.Domain;

namespace Abhishek.Model.DTO
{
    public class UserDetailsDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]

        public string UserEmail { get; set; }

        [Required]

        public Role Role { get; set; }
        public Boolean IsStudent { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }

    }
}
