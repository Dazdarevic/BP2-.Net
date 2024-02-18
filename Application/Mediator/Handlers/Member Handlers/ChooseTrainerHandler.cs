using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Member_Commands;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class ChooseTrainerHandler : IRequestHandler<ChooseTrainerCommand, bool>
    {
        private readonly IUnitOfWork uow;

        public ChooseTrainerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(ChooseTrainerCommand request, CancellationToken cancellationToken)
        {
            await uow.MemberRepository.ChooseTrainer(request.MemberId, request.TrainerId);
            return await uow.SaveAsync();
        }
    }
}
