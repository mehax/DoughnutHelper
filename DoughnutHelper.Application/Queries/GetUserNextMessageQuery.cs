using DoughnutHelper.Application.Models;
using MediatR;

namespace DoughnutHelper.Application.Queries
{
    public class GetUserNextMessageQuery : IRequest<MessageModel>
    {
        public int UserId { get; set; }
    }
}