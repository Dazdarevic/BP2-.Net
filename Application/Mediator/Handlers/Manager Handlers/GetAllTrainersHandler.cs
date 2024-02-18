using MediatR;
using Sieve.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NBP.Application.Mediator.Queries.Manager_Queries;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;

namespace NBP.Application.Mediator.Handlers.Trainers
{
    public class GetAllTrainersHandler : IRequestHandler<GetAllTrainersQuery, IEnumerable<TrainerWithSalaryDto>>
    {
        private readonly IUnitOfWork uow;

        public GetAllTrainersHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<TrainerWithSalaryDto>> Handle(GetAllTrainersQuery request, CancellationToken cancellationToken)
        {
            var trainers = await uow.ManagerRepository.GetAllTrainersWithSalariesAsync();


            return trainers;
        }
    }
}
