using MediatR;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class GetMemberQuery : IRequest<Member>
    {
        public int MemberId { get; }

        public GetMemberQuery(int memberId)
        {
            MemberId = memberId;
        }
    }
}
