using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class GetTrainerHandler : IRequestHandler<GetTrainerQuery, TrainerUser>
    {
        private readonly IUnitOfWork uow;

        public GetTrainerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<TrainerUser> Handle(GetTrainerQuery request, CancellationToken cancellationToken)
        {
            return (TrainerUser)await uow.MemberRepository.GetTrainer(request.TrainerId);
        }
    }
}
