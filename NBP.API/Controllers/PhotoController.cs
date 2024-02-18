using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBP.Application.Mediator.Commands.Photo_Commands;

namespace NPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IMediator mediator;
        public PhotoController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost("upload-photo")]
        //[Authorize]
        public async Task<IActionResult> UploadPhoto(IFormFile file)
        {
            var command = new AddPhotoCommand { File = file };

            try
            {
                var photoUrl = await mediator.Send(command);
                return Ok(photoUrl);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
