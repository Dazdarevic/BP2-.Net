using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Mediator.Queries.User;
using NBP.Application.Mediator.Commands.User_Commands;

namespace NPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserInfoDto>> GetUserByIdAndRole(int userId, [FromQuery] string role)
        {
            var query = new GetUserByIdAndRoleQuery(userId, role);
            var result = await _mediator.Send(query);

            if (result == null)
            {
                return NotFound("Korisnik nije pronađen");
            }

            return Ok(result);
        }

        [HttpPost("update-profile-picture")]
        public async Task<IActionResult> UpdateProfilePicture([FromBody] UpdateProfilePictureCommand command)
        {
            try
            {
                await _mediator.Send(command);
                return Ok("URL slike profila uspešno ažuriran");
            }
            catch (Exception ex)
            {
                return BadRequest($"Došlo je do greške prilikom ažuriranja URL-a slike profila: {ex.Message}");
            }
        }
    }
}
