using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class GetPaginatedTrainersHandler : IRequestHandler<GetPaginatedTrainersQuery, IEnumerable<TrainerUser>>
    {
        private readonly IUnitOfWork uow;

        public GetPaginatedTrainersHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<TrainerUser>> Handle(GetPaginatedTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = await uow.MemberRepository.GetPaginatedTrainersAsync(request.Page, request.PageSize, request.Id);

            return trainers;
        }
    }

}
