using System;
using System.Linq.Expressions;
using DoughnutHelper.Application.Users.Models;
using DoughnutHelper.Domain.Entities;
using DoughnutHelper.Domain.Enumerations;

namespace DoughnutHelper.Application.Messages.Models
{
    public class ChoiceModel
    {
        public int UserId { get; set; }
        public int QuestionMessageId { get; set; }
        public Answers Answer { get; set; }
        
        public UserModel User { get; set; }
        public MessageModel Question { get; set; }

        public static Expression<Func<Choice, ChoiceModel>> Projection
        {
            get
            {
                return model => new ChoiceModel
                {
                    UserId = model.UserId,
                    QuestionMessageId = model.QuestionMessageId,
                    Answer = model.Answer,
                    User = UserModel.CreateModel(model.User),
                    Question = MessageModel.CreateModel(model.QuestionMessage)
                };
            }
        }
    }
}