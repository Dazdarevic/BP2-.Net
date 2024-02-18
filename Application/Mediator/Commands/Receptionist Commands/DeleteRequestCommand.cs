using MediatR;

namespace NBP.Application.Mediator.Commands.Receptionist_Commands
{
    public class DeleteRequestCommand : IRequest<bool>
    {
        public int RequestId { get; }

        public DeleteRequestCommand(int requestId)
        {
            RequestId = requestId;
        }
    }

}
