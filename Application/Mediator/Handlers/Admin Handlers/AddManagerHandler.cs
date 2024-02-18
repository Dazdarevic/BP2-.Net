using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Admin;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Handlers.Admin
{
    public class AddManagerHandler : IRequestHandler<AddManagerCommand, ManagerS>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;


        public AddManagerHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;

        }
        public async Task<ManagerS> Handle(AddManagerCommand request, CancellationToken cancellationToken)
        {
            var manager = mapper.Map<ManagerS>(request);

            uow.AdministratorRepository.AddManager(manager);
            await uow.SaveAsync();
            var newAdmin = manager;
            return newAdmin;
        }
    }
}
