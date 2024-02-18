using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Member_Commands;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class RateTrainerHandler : IRequestHandler<RateTrainerCommand, bool>
    {
        private readonly IUnitOfWork uow;

        public RateTrainerHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(RateTrainerCommand request, CancellationToken cancellationToken)
        {
            if (request.RatingValue < 1 || request.RatingValue > 5)
            {
                return false;
            }
            await uow.MemberRepository.RateTrainerAsync(request.MemberId, request.TrainerId, request.RatingValue);


            return await uow.SaveAsync();
        }
    }
}
