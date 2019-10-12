using System.Threading.Tasks;
using DoughnutHelper.Application.Messages.Models;
using DoughnutHelper.Application.Messages.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DoughnutHelper.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private IMediator _mediator;

        public MessagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<MessageModel>> GetInitialMessage()
        {
            return Ok(await _mediator.Send(new GetInitialQuestionQuery()));
        }
        
        [HttpPost]
        public async Task<ActionResult<MessageModel>> GetNextMessage(GetNextMessageQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}