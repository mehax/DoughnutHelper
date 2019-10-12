using DoughnutHelper.Application.Messages.Models;
using DoughnutHelper.Domain.Enumerations;
using MediatR;

namespace DoughnutHelper.Application.Messages.Queries
{
    public class GetNextMessageQuery : IRequest<MessageModel>
    {
        public int QuestionMessageId { get; set; }
        public Answers Answer { get; set; }
    }
}