using System.Collections.Generic;
using System.Threading.Tasks;
using DoughnutHelper.Application.Messages.Commands;
using DoughnutHelper.Application.Messages.Models;
using DoughnutHelper.Application.Messages.Queries;
using DoughnutHelper.Domain.Enumerations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoughnutHelper.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{userId}")]
        public async Task<ActionResult<MessageModel>> GetUserNextMessage([FromRoute]int userId)
        {
            var query = new GetUserNextMessageQuery
            {
                UserId = userId
            };
            
            return Ok(await _mediator.Send(query));
        }
    }
}