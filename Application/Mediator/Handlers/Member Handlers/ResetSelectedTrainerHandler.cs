using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Member_Commands;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{

    public class ResetSelectedTrainerHandler : IRequestHandler<ResetSelectedTrainerCommand, bool>
    {
        private readonly IUnitOfWork uow;
        public ResetSelectedTrainerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(ResetSelectedTrainerCommand request, CancellationToken cancellationToken)
        {
            await uow.MemberRepository.ResetSelectedTrainer(request.MemberId);
            return await uow.SaveAsync();
        }
    }
}
