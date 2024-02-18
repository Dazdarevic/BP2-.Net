using MediatR;

namespace NBP.Application.Mediator.Commands.Manager_Commands
{
    public class AddMembershipCommand : IRequest
    {
        public int MemberId { get; }
        public string MembershipAmount { get; }

        public AddMembershipCommand(int memberId, string membershipAmount)
        {
            MemberId = memberId;
            MembershipAmount = membershipAmount;
        }
    }
}
