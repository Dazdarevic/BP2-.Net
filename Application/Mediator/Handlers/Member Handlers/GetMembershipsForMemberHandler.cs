using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class GetMembershipsForMemberHandler : IRequestHandler<GetMembershipsForMemberQuery, IEnumerable<Membership>>
    {
        private readonly IUnitOfWork uow;

        public GetMembershipsForMemberHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<Membership>> Handle(GetMembershipsForMemberQuery request, CancellationToken cancellationToken)
        {
            return await uow.MemberRepository.GetMembershipsForMemberAsync(request.MemberId);
        }
    }
}
