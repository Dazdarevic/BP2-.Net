using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Sponsor_Commands;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Handlers.Sponsor_Handlers
{
    public class AddAdCommandHandler : IRequestHandler<AddAdCommand, Advertisement>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddAdCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<Advertisement> Handle(AddAdCommand request, CancellationToken cancellationToken)
        {
            var pom = mapper.Map<Advertisement>(request);

            uow.SponsorRepository.AddAd(pom);
            await uow.SaveAsync();
            var newAdmin = pom;
            return newAdmin;
        }
    }

}
