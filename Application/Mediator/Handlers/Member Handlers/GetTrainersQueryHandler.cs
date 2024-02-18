using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class GetTrainersQueryHandler : IRequestHandler<GetTrainersQuery, object>
    {
        private readonly IUnitOfWork uow;

        public GetTrainersQueryHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<object> Handle(GetTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = await uow.MemberRepository.GetPagTrainersAsync(request.Page, request.PageSize);

            return trainers;
        }
    }
}
