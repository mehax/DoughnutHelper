using DoughnutHelper.Application.Messages.Models;
using DoughnutHelper.Domain.Enumerations;
using MediatR;

namespace DoughnutHelper.Application.Messages.Queries
{
    public class GetUserNextMessageQuery : IRequest<MessageModel>
    {
        public int UserId { get; set; }
    }
}