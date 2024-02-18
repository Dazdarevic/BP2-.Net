using MediatR;
using NBP.Application.DTOs;
using System.Collections.Generic;

namespace NBP.Application.Mediator.Queries
{
    public class GetAllMembersByManager : IRequest<IEnumerable<MemberInfoDto>>
    {
    }
}
