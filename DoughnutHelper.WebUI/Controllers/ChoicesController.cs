using System.Collections.Generic;
using System.Threading.Tasks;
using DoughnutHelper.Application.Commands;
using DoughnutHelper.Application.Models;
using DoughnutHelper.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoughnutHelper.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoicesController : ControllerBase
    {
        
        private IMediator _mediator;

        public ChoicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ChoiceModel>>> GetUserChoices([FromRoute] int userId)
        {
            var query = new GetUserChoicesQuery { UserId = userId };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> CreateUserChoice(CreateUserChoiceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}