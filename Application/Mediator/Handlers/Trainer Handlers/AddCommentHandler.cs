using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Trainer_Commands;

namespace NBP.Application.Mediator.Handlers.Trainer_Handlers
{
    public class AddCommentHandler : IRequestHandler<AddCommentCommand, bool>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        public AddCommentHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this._mapper = mapper;
        }

        public async Task<bool> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var pom = _mapper.Map<CommentDto>(request);

            var isAdded = await uow.TrainerRepository.AddOrUpdateCommentAsync(pom);
            if (isAdded)
            {
                await uow.SaveAsync();
            }
            return isAdded;
        }
    }

}
