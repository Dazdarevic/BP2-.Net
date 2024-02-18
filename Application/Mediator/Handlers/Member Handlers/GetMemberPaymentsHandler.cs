using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class GetMemberPaymentsHandler : IRequestHandler<GetMemberPaymentsQuery, IEnumerable<PaymentDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetMemberPaymentsHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }


        Task<IEnumerable<PaymentDto>> IRequestHandler<GetMemberPaymentsQuery, IEnumerable<PaymentDto>>.Handle(GetMemberPaymentsQuery request, CancellationToken cancellationToken)
        {
            var result =  uow.MemberRepository.GetPaymentsForMemberAsync(request.UserName);

            return result;
        }
    }
}
