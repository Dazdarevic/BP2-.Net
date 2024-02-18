using MediatR;

namespace NBP.Application.Mediator.Queries.Member_Queries
{

    public class GetFilteredTrainerQuery : IRequest<object>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string Filter { get; set; }


        public GetFilteredTrainerQuery(int page, int pageSize, string filter)
        {
            Page = page;
            PageSize = pageSize;
            Filter = filter;
        }
    }
}
