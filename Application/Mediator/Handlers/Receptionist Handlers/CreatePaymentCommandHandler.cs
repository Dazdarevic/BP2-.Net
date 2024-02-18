using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Receptionist_Commands;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Handlers.Receptionist_Handlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, bool>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper mapper;


        public CreatePaymentCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            this.mapper = mapper;
        }
        public async Task<bool> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var pom = mapper.Map<Payment>(request);

            var isRequestCreated = await _uow.ReceptionistRepository.CreatePaymentAsync(pom);

            if (isRequestCreated)
            {
                await _uow.SaveAsync();
            }

            return isRequestCreated;
        }
    }
}
