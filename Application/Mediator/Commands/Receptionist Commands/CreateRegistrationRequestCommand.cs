using MediatR;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Commands.Receptionist_Commands
{
    public class CreateRegistrationRequestCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BirthDate { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
    }

}
