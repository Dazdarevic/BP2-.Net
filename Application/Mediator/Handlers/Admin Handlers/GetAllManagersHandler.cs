using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Admin;

namespace NBP.Application.Mediator.Handlers.Admin
{
    public class GetAllManagersHandler : IRequestHandler<GetAllManagersQuery, IEnumerable<ManagerDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllManagersHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<ManagerDto>> Handle(GetAllManagersQuery request, CancellationToken cancellationToken)
        {
            var managers = await uow.AdministratorRepository.GetManagersAsync();
            var managersDto = mapper.Map<IEnumerable<ManagerDto>>(managers);
            return managersDto;
        }
    }
}
