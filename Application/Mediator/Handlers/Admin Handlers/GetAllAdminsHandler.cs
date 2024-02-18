using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Admin;
using Serilog;
using Microsoft.Extensions.Logging; // Dodajte Microsoft.Extensions.Logging

namespace NBP.Application.Mediator.Handlers.Admin
{
    public class GetAllAdminsHandler : IRequestHandler<GetAllAdminsQuery, IEnumerable<AdminDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllAdminsHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AdminDto>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            var admins = await uow.AdministratorRepository.GetAdminsAsync(request.CurrentAdminId);
            var adminsDto = mapper.Map<IEnumerable<AdminDto>>(admins);
            return adminsDto;
        }
    }
}
