using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Queries.Admin
{
    public class GetAllAdminsQuery : IRequest<IEnumerable<AdminDto>>
    {
        public int CurrentAdminId { get; set; }
        public GetAllAdminsQuery(int currentAdminId)
        {
            CurrentAdminId = currentAdminId;
        }
    }
}
