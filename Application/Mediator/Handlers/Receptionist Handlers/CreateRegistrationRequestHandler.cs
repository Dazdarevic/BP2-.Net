using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Receptionist_Commands;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Handlers.Receptionist_Handlers
{
    public class CreateRegistrationRequestHandler : IRequestHandler<CreateRegistrationRequestCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper mapper;


        public CreateRegistrationRequestHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateRegistrationRequestCommand request, CancellationToken cancellationToken)
        {
            var pom = mapper.Map<RegistrationRequest>(request);

            var isRequestCreated = await _uow.ReceptionistRepository.CreateRegistrationRequestAsync(pom);

            if (isRequestCreated)
            {
                await _uow.SaveAsync();
            }

            return isRequestCreated;
        }
    }

}
