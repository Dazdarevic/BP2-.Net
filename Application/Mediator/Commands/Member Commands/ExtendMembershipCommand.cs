using MediatR;

namespace NBP.Application.Mediator.Commands.Member_Commands
{
    public class ExtendMembershipCommand : IRequest<bool>
    {
        public int MemberId { get; set; }
        public string MembershipAmount { get; set; }
        public int Month { get; set; }
    }
}
