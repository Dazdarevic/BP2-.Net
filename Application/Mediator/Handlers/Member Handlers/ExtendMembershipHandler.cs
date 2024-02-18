using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Member_Commands;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class ExtendMembershipHandler : IRequestHandler<ExtendMembershipCommand, bool>
    {
        private readonly IUnitOfWork uow;

        public ExtendMembershipHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(ExtendMembershipCommand request, CancellationToken cancellationToken)
        {
            return await uow.MemberRepository.ExtendMembershipAsync(request.MemberId, request.MembershipAmount, request.Month);
        }
    }
}
