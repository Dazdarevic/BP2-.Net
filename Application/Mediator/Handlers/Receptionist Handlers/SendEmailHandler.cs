using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Receptionist_Commands;

namespace NBP.Application.Mediator.Handlers.Receptionist_Handlers
{

    public class SendEmailHandler : IRequestHandler<SendEmailCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper mapper;


        public SendEmailHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            this.mapper = mapper;
        }

        public async Task Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            var pom = mapper.Map<EmailDto>(request);

            await _uow.EmailSenderRepository.SendEmailAsync(pom.Email, pom.Subject, pom.Message);
        }
    }

}
