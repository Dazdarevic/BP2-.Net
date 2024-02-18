using MediatR;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class GetTrainersQuery : IRequest<object>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetTrainersQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
