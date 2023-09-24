using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abhishek.Model.Domain
{
    public class Grade
    {
        [Key]
        public int GradeId { get; set; }
        public string GradeName { get; set; }

        [ForeignKey("SubjectId")]
        public int SubjectId { get; set; }
    }
}
