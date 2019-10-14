using System;
using System.Linq.Expressions;
using DoughnutHelper.Domain.Entities;
using DoughnutHelper.Domain.Enumerations;

namespace DoughnutHelper.Application.Messages.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public bool IsQuestion { get; set; }
        
        public int? ParentId { get; set; }
        public Answers? ByAnswer { get; set; } 

        public static Expression<Func<Message, MessageModel>> Projection
        {
            get
            {
                return message => new MessageModel
                {
                    MessageId = message.Id,
                    MessageText = message.Title,
                    IsQuestion = message.IsQuestion,
                    ParentId = message.ParentId,
                    ByAnswer = message.ByAnswer
                };
            }
        }

        public static MessageModel CreateModel(Message message)
        {
            return Projection.Compile().Invoke(message);
        }
    }
}