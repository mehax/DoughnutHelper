using System.Collections.Generic;
using DoughnutHelper.Application.Users.Models;
using MediatR;

namespace DoughnutHelper.Application.Users.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserModel>>
    {
    }
}