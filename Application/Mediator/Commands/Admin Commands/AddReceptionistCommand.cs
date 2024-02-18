using MediatR;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Commands.Admin
{
    public class AddReceptionistCommand : IRequest<Receptionist>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BirthDate { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string? Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }

        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }

        public AddReceptionistCommand()
        {
            this.RegistrationDate = DateTime.Now;
        }

    }
}
