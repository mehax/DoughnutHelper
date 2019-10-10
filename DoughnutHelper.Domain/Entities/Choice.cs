using DoughnutHelper.Domain.Enumerations;

namespace DoughnutHelper.Domain.Entities
{
    public class Choice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public Answers Answer { get; set; }

        public User? User { get; set; }
        public Question Question { get; set; }
    }
}