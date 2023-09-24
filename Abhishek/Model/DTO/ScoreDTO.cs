using Abhishek.Model.Domain;

namespace Abhishek.Model.DTO
{
    public class ScoreDTO
    {
        public int UserId { get; set; }

        public List<ScoreList> scoreList { get; set; }
    }
}
