using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Queries.Member_Queries
{

    public class GetMemberPaymentsQuery : IRequest<IEnumerable<PaymentDto>>

    {
        public string UserName { get; }

        public GetMemberPaymentsQuery(string userName)
        {
            UserName = userName;
        }
    }
}
