using DoughnutHelper.Application.Users.Models;
using MediatR;

namespace DoughnutHelper.Application.Users.Queries
{
    public class GetUserQuery : IRequest<UserModel>
    {
        public int UserId { get; set; }
    }
}