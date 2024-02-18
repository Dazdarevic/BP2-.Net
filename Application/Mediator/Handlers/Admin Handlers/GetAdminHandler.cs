using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Admin;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Handlers.Admin
{
    public class GetAdminHandler : IRequestHandler<GetAdminQuery, Administrator>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAdminHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }


        public async Task<Administrator> Handle(GetAdminQuery request, CancellationToken cancellationToken)
        {
            return (Administrator)await uow.AdministratorRepository.GetAdmin(request.CurrentAdminId);
        }
    }
}
