using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DoughnutHelper.Application.Models;
using DoughnutHelper.Domain.Entities;
using DoughnutHelper.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DoughnutHelper.Application.Queries.QueryHandlers
{
    public class GetUserNextMessageQueryHandler : IRequestHandler<GetUserNextMessageQuery, MessageModel>
    {
        private DoughnutHelperDbContext _dbContext;

        public GetUserNextMessageQueryHandler(DoughnutHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<MessageModel> Handle(GetUserNextMessageQuery request, CancellationToken cancellationToken)
        {
            var lastChoice = await _dbContext.Choices
                .OrderBy(choice => choice.Id)
                .LastOrDefaultAsync(choice => choice.UserId == request.UserId, cancellationToken);
            
            Message nextQuestion;
            if (lastChoice != null)
            {
                nextQuestion = await _dbContext.Messages.FirstOrDefaultAsync(message =>
                    message.ParentId == lastChoice.QuestionMessageId && message.ByAnswer == lastChoice.Answer,
                    cancellationToken);
            }
            else
            {
                nextQuestion = await _dbContext.Messages.FirstOrDefaultAsync(message =>
                    message.IsQuestion && message.ParentId == null, cancellationToken);
            }

            return MessageModel.CreateModel(nextQuestion);
        }
    }
}