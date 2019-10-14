using DoughnutHelper.Application.Messages.Models;
using MediatR;

namespace DoughnutHelper.Application.Messages.Queries
{
    public class GetUserStatsQuery : IRequest<StatsModel>
    {
        public int UserId { get; set; }
    }
}