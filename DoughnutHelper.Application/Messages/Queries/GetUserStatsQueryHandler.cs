using System.Threading;
using System.Threading.Tasks;
using DoughnutHelper.Application.Messages.Models;
using MediatR;

namespace DoughnutHelper.Application.Messages.Queries
{
    public class GetUserStatsQueryHandler : IRequestHandler<GetUserStatsQuery, StatsModel>
    {
        private IMediator _mediator;

        public GetUserStatsQueryHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task<StatsModel> Handle(GetUserStatsQuery request, CancellationToken cancellationToken)
        {
            var userChoices = await _mediator.Send(new GetUserChoicesQuery {UserId = request.UserId});
            var userNextMessage = await _mediator.Send(new GetUserNextMessageQuery {UserId = request.UserId});

            return new StatsModel()
            {
                Choices = userChoices,
                NextMessage = userNextMessage
            };
        }
    }
}