using MediatR;

namespace NBP.Application.Mediator.Commands.User_Commands
{
    public class UpdateProfilePictureCommand : IRequest<Unit>
    {
        public int UserId { get; }
        public string Role { get; }
        public string ProfilePictureUrl { get; }

        public UpdateProfilePictureCommand(int userId, string role, string profilePictureUrl)
        {
            UserId = userId;
            Role = role;
            ProfilePictureUrl = profilePictureUrl;
        }
    }

}
