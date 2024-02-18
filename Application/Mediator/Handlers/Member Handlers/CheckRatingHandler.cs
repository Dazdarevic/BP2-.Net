using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class CheckRatingHandler : IRequestHandler<CheckRatingQuery, bool>
    {
        private readonly IUnitOfWork uow;

        public CheckRatingHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<bool> Handle(CheckRatingQuery request, CancellationToken cancellationToken)
        {
            return await uow.MemberRepository.CheckRating(request.MemberId, request.TrainerId);
        }
    }
}
