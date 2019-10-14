using MediatR;

namespace DoughnutHelper.Application.Commands
{
    public class CreateNewUserCommand : IRequest<int>
    {
        public string Name { get; set; }
    }
}