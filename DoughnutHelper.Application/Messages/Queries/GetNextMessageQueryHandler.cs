using System.Threading;
using System.Threading.Tasks;
using DoughnutHelper.Application.Messages.Models;
using DoughnutHelper.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DoughnutHelper.Application.Messages.Queries
{
    public class GetNextMessageQueryHandler : IRequestHandler<GetNextMessageQuery, MessageModel>
    {
        private DoughnutHelperDbContext _dbContext;

        public GetNextMessageQueryHandler(DoughnutHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<MessageModel> Handle(GetNextMessageQuery request, CancellationToken cancellationToken)
        {
            var nextQuestion = await _dbContext.Messages.FirstOrDefaultAsync(message =>
                message.ParentId == request.QuestionMessageId && message.ByAnswer == request.Answer);

            return MessageModel.CreateMessage(nextQuestion);
        }
    }
}