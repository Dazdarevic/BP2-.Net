using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBP.Application.DTOs;
using NBP.Application.Mediator.Commands.Trainer_Commands;
using NBP.Application.Mediator.Queries;
using NBP.Application.Mediator.Queries.Trainer;
using NBP.Application.Mediator.Queries.Trainer_Queries;
using System.Collections.Generic;

namespace NPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly IMediator mediator;

        public TrainerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("members")]
        //[Authorize]
        public async Task<IActionResult> GetAllMembersAsync()
        {
            var command = new GetAllMembersQuery();
            var membersDto = await mediator.Send(command);
            return Ok(membersDto);
        }

        [HttpGet("all-members-by-manager")]
        //[Authorize]
        public async Task<IActionResult> GetAllMembersByManager()
        {
            var query = new GetAllMembersByManager();

            try
            {
                var members = await mediator.Send(query);
                return Ok(members);
            }
            catch (Exception ex)
            {
                return BadRequest($"Došlo je do greške prilikom dohvatanja članova: {ex.Message}");
            }
        }

        [HttpPost("add-comment")]
        //[Authorize]
        public async Task<IActionResult> AddComment(AddCommentCommand comment)
        {
            var isAdded = await mediator.Send(comment);

            if (isAdded)
            {
                return Ok("Comment added successfully.");
            }

            return BadRequest("Adding comment failed. Member or trainer not found.");
        }



        [HttpGet("members-with-selected-trainer/{trainerId}")]
        //Authorize
        public async Task<IActionResult> GetMembersWithSelectedTrainer(int trainerId)
        {
            var query = new GetMembersWithSelectedTrainerQuery(trainerId);
            var members = await mediator.Send(query);

            return Ok(members);
        }


        [HttpGet("comments/{trainerId}/{memberId}")]
        //Authorize
        public async Task<IActionResult> GetComment(int trainerId, int memberId)
        {
            var query = new GetCommentQuery(trainerId, memberId);
            var comment = await mediator.Send(query);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

        [HttpGet("comment/{memberId}")]
        //Authorize
        public async Task<IActionResult> GetMyComment(int memberId)
        {
            var query = new GetCommentByMemberQuery(memberId);
            var comment = await mediator.Send(query);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }
    }
}
