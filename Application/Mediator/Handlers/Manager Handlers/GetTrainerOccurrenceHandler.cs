using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Manager_Queries;

namespace NBP.Application.Mediator.Handlers.Trainers
{
    public class GetTrainerOccurrenceHandler : IRequestHandler<GetTrainerOccurrenceQuery, int>
    {
        private readonly IUnitOfWork uow;

        public GetTrainerOccurrenceHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<int> Handle(GetTrainerOccurrenceQuery request, CancellationToken cancellationToken)
        {
            return await uow.ManagerRepository.GetTrainerIdOccurrenceAsync(request.TrainerId);
        }
    }
}
