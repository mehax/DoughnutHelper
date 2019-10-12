using DoughnutHelper.Application.Messages.Models;
using MediatR;

namespace DoughnutHelper.Application.Messages.Queries
{
    public class GetInitialQuestionQuery : IRequest<MessageModel>
    {
    }
}