using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Queries.Receptionist_Queries
{
    public class GetAllPaymentsQuery : IRequest<IEnumerable<PaymentDto>>
    {
    }

}
