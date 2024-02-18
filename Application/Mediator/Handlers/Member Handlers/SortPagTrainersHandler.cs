using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{

    public class SortPagTrainersHandler : IRequestHandler<SortPagTrainersQuery, object>
    {
        private readonly IUnitOfWork uow;

        public SortPagTrainersHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<object> Handle(SortPagTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = await uow.MemberRepository.SortPagTrainersAsync(request.Page, request.PageSize, request.SortBy);

            return trainers;
        }
    }
}
