using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class GetMemberCommentsQuery : IRequest<IEnumerable<MemberComment>>
    {
        public int MemberId { get; set; }
    }
}
