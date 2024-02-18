using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Commands.Receptionist_Commands
{
    public class SendEmailCommand : IRequest
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }

}
