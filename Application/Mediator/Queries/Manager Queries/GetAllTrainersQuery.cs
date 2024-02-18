using MediatR;
using NBP.Application.DTOs;
using Sieve.Models;

namespace NBP.Application.Mediator.Queries.Manager_Queries
{
    public class GetAllTrainersQuery : IRequest<IEnumerable<TrainerWithSalaryDto>>
    {

        public GetAllTrainersQuery()
        {
        }
    }
}
