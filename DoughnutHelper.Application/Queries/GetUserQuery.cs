using DoughnutHelper.Application.Models;
using MediatR;

namespace DoughnutHelper.Application.Queries
{
    public class GetUserQuery : IRequest<UserModel>
    {
        public int UserId { get; set; }
    }
}