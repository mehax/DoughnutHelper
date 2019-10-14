using System.Threading;
using System.Threading.Tasks;
using DoughnutHelper.Application.Models;
using DoughnutHelper.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DoughnutHelper.Application.Queries.QueryHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserModel>
    {
        private DoughnutHelperDbContext _dbContext;

        public GetUserQueryHandler(DoughnutHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<UserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);

            return UserModel.CreateModel(entity);
        }
    }
}