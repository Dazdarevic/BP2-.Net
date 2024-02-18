using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBP.Application.Mediator.Commands.Login_Commands;
using NBP.Domain.Identity;

namespace NPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator mediator;

        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        [Route("PostLoginDetails")]
        public async Task<IActionResult> PostLoginDetails(PostLoginDetailsCommand command)
        {
            var result = await mediator.Send(command);

            if (result == null)
            {
                return BadRequest();
            }

            var jsonResult = new JsonResult(result);

            return Ok(jsonResult);
        }

    }
}
