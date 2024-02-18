using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Queries.Admin
{
    public class GetAllReceptionistsQuery : IRequest<IEnumerable<ReceptionistDto>>
    {
    }
}
