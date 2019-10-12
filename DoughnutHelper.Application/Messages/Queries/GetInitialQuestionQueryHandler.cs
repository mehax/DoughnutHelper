using System.Threading;
using System.Threading.Tasks;
using DoughnutHelper.Application.Messages.Models;
using DoughnutHelper.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DoughnutHelper.Application.Messages.Queries
{
    public class GetInitialQuestionQueryHandler : IRequestHandler<GetInitialQuestionQuery, MessageModel>
    {
        private DoughnutHelperDbContext _dbContext;

        public GetInitialQuestionQueryHandler(DoughnutHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<MessageModel> Handle(GetInitialQuestionQuery request, CancellationToken cancellationToken)
        {
            var initialQuestion = await _dbContext.Messages.FirstOrDefaultAsync(message =>
                message.IsQuestion && message.ParentId == null);

            return MessageModel.CreateMessage(initialQuestion);
        }
    }
}