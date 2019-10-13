using System.Collections.Generic;
using System.Threading.Tasks;
using DoughnutHelper.Application.Users.Commands;
using DoughnutHelper.Application.Users.Models;
using DoughnutHelper.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoughnutHelper.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetAll()
        {
            var query = new GetAllUsersQuery();
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserModel>> GetById([FromRoute]int userId)
        {
            var query = new GetUserQuery {UserId = userId};
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateNewUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}