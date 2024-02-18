using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Manager_Commands;

namespace NBP.Application.Mediator.Handlers.Memberships
{
    public class AddMembershipHandler : IRequestHandler<AddMembershipCommand>
    {
        private readonly IUnitOfWork uow;

        public AddMembershipHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task Handle(AddMembershipCommand request, CancellationToken cancellationToken)
        {
            await uow.ManagerRepository.AddMembershipAmount(request.MemberId, request.MembershipAmount);
            await uow.SaveAsync();
        }
    }
}

