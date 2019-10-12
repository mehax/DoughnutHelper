using DoughnutHelper.Domain.Enumerations;

namespace DoughnutHelper.Domain.Entities
{
    public class Choice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionMessageId { get; set; }
        public Answers Answer { get; set; }

        public User? User { get; set; }
        public Message Question { get; set; }
    }
}