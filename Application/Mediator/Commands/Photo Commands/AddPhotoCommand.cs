using MediatR;
using Microsoft.AspNetCore.Http;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Commands.Photo_Commands
{
    public class AddPhotoCommand : IRequest<Photo> // string označava URL fotografije
    {
        public IFormFile? File { get; set; }
    }
}
