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
    public class GetAllMessagesQueryHandler : IRequestHandler<GetAllMessagesQuery, List<MessageModel>>
    {
        private DoughnutHelperDbContext _dbContext;

        public GetAllMessagesQueryHandler(DoughnutHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<MessageModel>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Messages
                .Select(MessageModel.Projection)
                .ToListAsync(cancellationToken);
        }
    }
}