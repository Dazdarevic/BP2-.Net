using MediatR;
using Microsoft.AspNetCore.Mvc;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Commands.Login_Commands
{
    public class PostLoginDetailsCommand : IRequest<JsonResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
