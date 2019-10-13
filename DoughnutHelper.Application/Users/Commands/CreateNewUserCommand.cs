using MediatR;

namespace DoughnutHelper.Application.Users.Commands
{
    public class CreateNewUserCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}