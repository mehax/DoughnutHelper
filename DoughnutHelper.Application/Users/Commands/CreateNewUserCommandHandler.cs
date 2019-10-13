using System.Threading;
using System.Threading.Tasks;
using DoughnutHelper.Domain.Entities;
using DoughnutHelper.Persistence;
using MediatR;

namespace DoughnutHelper.Application.Users.Commands
{
    public class CreateNewUserCommandHandler : IRequestHandler<CreateNewUserCommand, int>
    {
        private DoughnutHelperDbContext _dbContext;

        public CreateNewUserCommandHandler(DoughnutHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<int> Handle(CreateNewUserCommand request, CancellationToken cancellationToken)
        {
            var model = new User
            {
                Name = request.Name
            };
            
            await _dbContext.Users.AddAsync(model, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return model.Id;
        }
    }
}