using System.Collections.Generic;
using DoughnutHelper.Application.Messages.Models;
using MediatR;

namespace DoughnutHelper.Application.Messages.Queries
{
    public class GetUserChoicesQuery : IRequest<List<ChoiceModel>>
    {
        public int UserId { get; set; }
    }
}