using Abhishek.Model.Domain;

namespace Abhishek.Model.DTO
{
    public class ScoreDTO
    {
        public int UserId { get; set; }

        public List<Marsksheet> marksheet { get; set; }

        public class Marsksheet
        {
            public int SubjectId { get; set; }
            public string subject { get; set; }
            public string grade { get; set; }
            public int GradeId { get; set; }
        }
}
    }
