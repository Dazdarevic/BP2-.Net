using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Admin;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Handlers.Admin
{
    public class AddAdminHandler : IRequestHandler<AddAdminCommand, Administrator>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        
        public AddAdminHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<Administrator> Handle(AddAdminCommand request, CancellationToken cancellationToken)
        {
            /// <summary>
            /// ovde pozivam sve te argumente
            /// </summary>
            /// 
            var admin = mapper.Map<Administrator>(request);

            uow.AdministratorRepository.AddAdmin(admin);
            await uow.SaveAsync();
            var newAdmin = admin;
            return newAdmin;
        }
    }
}
