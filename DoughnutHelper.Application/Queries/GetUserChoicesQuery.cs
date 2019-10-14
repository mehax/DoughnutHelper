using System.Collections.Generic;
using DoughnutHelper.Application.Models;
using MediatR;

namespace DoughnutHelper.Application.Queries
{
    public class GetUserChoicesQuery : IRequest<List<ChoiceModel>>
    {
        public int UserId { get; set; }
    }
}