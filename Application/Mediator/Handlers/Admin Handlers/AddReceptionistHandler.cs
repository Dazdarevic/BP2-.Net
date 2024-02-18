using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Admin;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Handlers.Admin
{
    public class AddReceptionistHandler : IRequestHandler<AddReceptionistCommand, Receptionist>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddReceptionistHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;

        }

        public async Task<Receptionist> Handle(AddReceptionistCommand request, CancellationToken cancellationToken)
        {
            var rec = mapper.Map<Receptionist>(request);

            uow.AdministratorRepository.AddReceptionist(rec);
            await uow.SaveAsync();
            var newRec = rec;
            return newRec;
        }
    }
}
