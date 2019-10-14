using System.Collections.Generic;
using DoughnutHelper.Application.Models;
using MediatR;

namespace DoughnutHelper.Application.Queries
{
    public class GetAllUsersQuery : IRequest<List<UserModel>>
    {
    }
}