using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.User_Commands;
using System.Threading;
using System.Threading.Tasks;

namespace NBP.Application.Mediator.Handlers.User_Handlers
{
    public class UpdateProfilePictureCommandHandler : IRequestHandler<UpdateProfilePictureCommand, Unit>
    {
        private readonly IUnitOfWork uow;

        public UpdateProfilePictureCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<Unit> Handle(UpdateProfilePictureCommand request, CancellationToken cancellationToken)
        {
            await this.uow.UserInfoRepository.UpdateProfilePictureUrlAsync(request.UserId, request.Role, request.ProfilePictureUrl);
            return Unit.Value;
        }
    }

}
