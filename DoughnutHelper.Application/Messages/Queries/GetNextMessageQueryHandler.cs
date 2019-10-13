using System.Threading;
using System.Threading.Tasks;
using DoughnutHelper.Application.Messages.Models;
using DoughnutHelper.Domain.Entities;
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
            var nextQuestion = new Message();
            if (request.QuestionMessageId != null)
            {
                nextQuestion = await _dbContext.Messages.FirstOrDefaultAsync(message =>
                    message.ParentId == request.QuestionMessageId.Value && message.ByAnswer == request.Answer.Value, cancellationToken);   
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