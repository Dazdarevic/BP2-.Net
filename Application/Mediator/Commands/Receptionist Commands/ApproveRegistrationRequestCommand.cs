using MediatR;

namespace NBP.Application.Mediator.Commands.Receptionist_Commands
{
    public class ApproveRegistrationRequestCommand : IRequest<bool>
    {
        public int RequestId { get; }

        public ApproveRegistrationRequestCommand(int requestId)
        {
            RequestId = requestId;
        }
    }

}
