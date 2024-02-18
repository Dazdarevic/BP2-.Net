using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Receptionist_Commands;

namespace NBP.Application.Mediator.Handlers.Receptionist_Handlers
{
    public class DeleteRequestHandler : IRequestHandler<DeleteRequestCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public DeleteRequestHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
        {
            var isRequestDeleted = await _uow.ReceptionistRepository.DeleteRequestAsync(request.RequestId);

            if (isRequestDeleted)
            {
                await _uow.SaveAsync();
            }

            return isRequestDeleted;
        }
    }

}
