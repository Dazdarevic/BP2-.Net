using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class GetAverageRatingHandler : IRequestHandler<GetAverageRating, double>
    {
        private readonly IUnitOfWork uow;
        public GetAverageRatingHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<double> Handle(GetAverageRating request, CancellationToken cancellationToken)
        {
            return await uow.MemberRepository.GetAverageRatingByTrainerId(request.TrainerId);
        }
    }

}
