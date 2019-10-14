using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DoughnutHelper.Application.Models;
using DoughnutHelper.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DoughnutHelper.Application.Queries.QueryHandlers
{
    public class GetUserChoicesQueryHandler : IRequestHandler<GetUserChoicesQuery, List<ChoiceModel>>
    {
        private DoughnutHelperDbContext _dbContext;

        public GetUserChoicesQueryHandler(DoughnutHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ChoiceModel>> Handle(GetUserChoicesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Choices
                .Where(c => c.UserId == request.UserId)
                .Select(ChoiceModel.Projection)
                .ToListAsync(cancellationToken);
        }
    }
}