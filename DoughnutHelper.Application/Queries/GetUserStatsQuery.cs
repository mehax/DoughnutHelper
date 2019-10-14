using DoughnutHelper.Application.Models;
using MediatR;

namespace DoughnutHelper.Application.Queries
{
    public class GetUserStatsQuery : IRequest<StatsModel>
    {
        public int UserId { get; set; }
    }
}