using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class GetFilteredTrainerQueryHandler : IRequestHandler<GetFilteredTrainerQuery, object>
    {
        private readonly IUnitOfWork uow;

        public GetFilteredTrainerQueryHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<object> Handle(GetFilteredTrainerQuery request, CancellationToken cancellationToken)
        {
            var trainers = await uow.MemberRepository.GetFiltredTrainerAsync(request.Page, request.PageSize, request.Filter);

            return trainers;
        }
    }
}
