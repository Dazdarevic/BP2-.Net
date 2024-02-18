using MediatR;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class SortTrainersQuery : IRequest<IEnumerable<TrainerUser>>
    {
        public string? SortByField { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }

}
