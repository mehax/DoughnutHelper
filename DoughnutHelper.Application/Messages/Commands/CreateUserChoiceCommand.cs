using DoughnutHelper.Domain.Enumerations;
using MediatR;

namespace DoughnutHelper.Application.Messages.Commands
{
    public class CreateUserChoiceCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
        public int QuestionMessageId { get; set; }
        public Answers Answer { get; set; }
    }
}