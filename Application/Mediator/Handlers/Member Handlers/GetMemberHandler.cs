using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class GetMemberHandler : IRequestHandler<GetMemberQuery, Member>
    {
        private readonly IUnitOfWork uow;

        public GetMemberHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<Member> Handle(GetMemberQuery request, CancellationToken cancellationToken)
        {
            return (Member)await uow.MemberRepository.GetMember(request.MemberId);
        }
    }
}
