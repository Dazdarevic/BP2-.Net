using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Receptionist_Queries;

namespace NBP.Application.Mediator.Handlers.Receptionist_Handlers
{
    public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, IEnumerable<PaymentDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllPaymentsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<IEnumerable<PaymentDto>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
        {
            return await _uow.ReceptionistRepository.GetAllPaymentsAsync();
        }
    }

}
