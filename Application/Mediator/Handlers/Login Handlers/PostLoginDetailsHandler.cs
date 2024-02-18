using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Login_Commands;
using NBP.Domain.Identity;
using System.Web.Http.Results;

namespace NBP.Application.Mediator.Handlers.Login_Handlers
{
    public class PostLoginDetailsHandler : IRequestHandler<PostLoginDetailsCommand, JsonResult>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;


        public PostLoginDetailsHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<JsonResult> Handle(PostLoginDetailsCommand request, CancellationToken cancellationToken)
        {
            var pom = mapper.Map<UserData>(request);

            var loginResult = await uow.LoginRepository.PostLoginDetails(pom);
            return (JsonResult)loginResult;
        }
    }

}
