using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NBP.Application.Mediator.Commands.Manager_Commands;
using NBP.Application.Mediator.Queries.Manager_Queries;

namespace NPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IMediator mediator;

        public ManagerController(IMediator mediator)
        {
            this.mediator = mediator;

        }

        [HttpGet("trainers")]
        //[Authorize]
        public async Task<IActionResult> GetAllTrainersAsync()
        {
            var query = new GetAllTrainersQuery();
            var trainers = await mediator.Send(query);

            return Ok(trainers);
        }
        


        [HttpPost("add-salary")]
        [Authorize]
        public async Task<IActionResult> AddTrainerSalary(int trainerId, string salaryAmount)
        {
            var command = new AddTrainerSalaryCommand(trainerId, salaryAmount);
            await mediator.Send(command);

            return Ok();
        }

        [HttpPost("add-membership")]
        //[Authorize]
        public async Task<IActionResult> AddMembership(int memberId, string membershipAmount)
        {
            var command = new AddMembershipCommand(memberId, membershipAmount);
            await mediator.Send(command);

            return Ok();
        }

        [HttpGet("trainer-members/{trainerId}")]
        [Authorize]
        public async Task<IActionResult> GetTrainerOccurrence(int trainerId)
        {
            var query = new GetTrainerOccurrenceQuery(trainerId);
            int occurrenceCount = await mediator.Send(query);

            if (occurrenceCount != 0)
            {
                return Ok(occurrenceCount);
            }

            return BadRequest();
        }


    }
}
