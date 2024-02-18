using MediatR;
using NBP.Application.Mediator.Commands.Receptionist_Commands;
using NBP.Application.Interfaces;

namespace NBP.Application.Mediator.Handlers.Receptionist_Handlers
{
    public class ApproveRegistrationRequestHandler : IRequestHandler<ApproveRegistrationRequestCommand, bool>
    {
        private readonly IUnitOfWork _uow;

        public ApproveRegistrationRequestHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<bool> Handle(ApproveRegistrationRequestCommand request, CancellationToken cancellationToken)
        {
            var isRequestApproved = await _uow.ReceptionistRepository.ApproveRegistrationRequestAsync(request.RequestId);

            if (isRequestApproved)
            {
                await _uow.SaveAsync();
            }

            return isRequestApproved;


        }
    }

}
