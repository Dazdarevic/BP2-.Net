using MediatR;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class GetMembershipsForMemberQuery : IRequest<IEnumerable<Membership>>
    {
        public int MemberId { get; set; }
    }
}
