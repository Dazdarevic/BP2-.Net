using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class HasSelectedTrainerHandler : IRequestHandler<GetHasSelectedTrainerQuery, bool>
    {
        private readonly IUnitOfWork uow;
        public HasSelectedTrainerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(GetHasSelectedTrainerQuery request, CancellationToken cancellationToken)
        {
            return await uow.MemberRepository.HasSelectedTrainer(request.MemberId);
        }
    }
}
