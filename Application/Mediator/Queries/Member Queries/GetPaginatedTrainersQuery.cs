using MediatR;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class GetPaginatedTrainersQuery : IRequest<IEnumerable<TrainerUser>>
    {
        public int Page { get; }
        public int PageSize { get; }
        public int Id { get; }


        public GetPaginatedTrainersQuery(int page, int pageSize, int id)
        {
            Page = page;
            PageSize = pageSize;
            Id = id;
        }
    }

}
