using MediatR;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Queries.Admin
{
    public class GetAdminQuery : IRequest<Administrator>
    {
        public int CurrentAdminId { get; set; }
        public GetAdminQuery(int currentAdminId)
        {
            CurrentAdminId = currentAdminId;
        }
    }
}
