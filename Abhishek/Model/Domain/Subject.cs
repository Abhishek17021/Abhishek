using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abhishek.Model.Domain
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
