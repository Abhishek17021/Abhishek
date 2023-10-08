namespace Abhishek.Model.Domain
{
    public class ScoreList
    {
        public int UserId { get; set; }

        public List<Marsksheet> marksheet { get; set; }

        public class Marsksheet
        {

            public int SubjectId { get; set; }
        public int GradeId { get; set; }
    }
}
    }

