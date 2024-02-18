using MediatR;

namespace NBP.Application.Mediator.Commands.Member_Commands
{
    public class ResetSelectedTrainerCommand : IRequest<bool>
    {
        public int MemberId { get; }

        public ResetSelectedTrainerCommand(int memberId)
        {
            MemberId = memberId;
        }
    }
}
