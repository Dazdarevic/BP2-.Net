using MediatR;

namespace NBP.Application.Mediator.Queries.Member_Queries
{

    public class SortPagTrainersQuery : IRequest<object>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SortBy { get; set; }
        public SortPagTrainersQuery(int page, int pageSize, string sortBy)
        {
            Page = page;
            PageSize = pageSize;
            SortBy = sortBy;
        }
    }
}
