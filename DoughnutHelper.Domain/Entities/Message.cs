using DoughnutHelper.Domain.Enumerations;

namespace DoughnutHelper.Domain.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public bool IsQuestion { set; get; }
        public string Title { get; set; }

        public int? ParentId { get; set; }
        public Answers? ByAnswer { get; set; }

        public Message? Parent { get; set; }
    }
}