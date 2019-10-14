using System.Threading;
using System.Threading.Tasks;
using DoughnutHelper.Domain.Entities;
using DoughnutHelper.Persistence;
using MediatR;

namespace DoughnutHelper.Application.Commands.CommandHandlers
{
    public class CreateUserChoiceCommandHandler : IRequestHandler<CreateUserChoiceCommand, Unit>
    {
        private DoughnutHelperDbContext _dbContext;

        public CreateUserChoiceCommandHandler(DoughnutHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<Unit> Handle(CreateUserChoiceCommand request, CancellationToken cancellationToken)
        {
            var model = new Choice
            {
                UserId = request.UserId,
                QuestionMessageId = request.QuestionMessageId,
                Answer = request.Answer
            };
            
            await _dbContext.Choices.AddAsync(model, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}