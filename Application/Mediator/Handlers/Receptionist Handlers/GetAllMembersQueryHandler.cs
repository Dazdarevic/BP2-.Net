using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Receptionist_Queries;

namespace NBP.API.Mediator.Handlers.Receptionist_Handlers
{
    public class GetAllMembersQueryHandler : IRequestHandler<GetAllMembersQuery, IEnumerable<MemberNameDto>>
    {

        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetAllMembersQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberNameDto>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _uow.ReceptionistRepository.GetAllMembersAsync();
            var membersNames = _mapper.Map<IEnumerable<MemberNameDto>>(members);
            return membersNames;
        }
    }
}
