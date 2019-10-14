using System.Collections.Generic;
using DoughnutHelper.Application.Models;
using MediatR;

namespace DoughnutHelper.Application.Queries
{
    public class GetAllMessagesQuery : IRequest<List<MessageModel>>
    {
    }
}