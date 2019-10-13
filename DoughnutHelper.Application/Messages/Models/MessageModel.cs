using DoughnutHelper.Domain.Entities;

namespace DoughnutHelper.Application.Messages.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public bool IsQuestion { get; set; }

        public static MessageModel CreateModel(Message message)
        {
            return new MessageModel
            {
                MessageId = message.Id,
                MessageText = message.Title,
                IsQuestion = message.IsQuestion
            };
        }
    }
}