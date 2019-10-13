using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DoughnutHelper.Application.Users.Models;
using DoughnutHelper.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DoughnutHelper.Application.Users.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
    {
        private DoughnutHelperDbContext _dbContext;

        public GetAllUsersQueryHandler(DoughnutHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
                .Select(UserModel.Projection)
                .ToListAsync(cancellationToken);
        }
    }
}