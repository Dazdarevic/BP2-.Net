using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBP.Application.Mediator.Commands.Member_Commands;
using NBP.Application.Mediator.Queries.Member_Queries;

namespace NPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMediator mediator;

        public MemberController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("member/{id}")]
        [Authorize]
        public async Task<IActionResult> GetMember(int id)
        {
            var query = new GetMemberQuery(id);
            var member = await mediator.Send(query);
            return Ok(member);
        }

        [HttpGet("payment/{userName}")]
        //[Authorize]
        public async Task<IActionResult> GetPayment(string userName)
        {
            var query = new GetMemberPaymentsQuery(userName);
            var member = await mediator.Send(query);
            return Ok(member);
        }

        [HttpGet("trainers")]
        //[Authorize]
        public async Task<IActionResult> GetAllTrainersAsync()
        {
            var query = new GetAllTrainersByMemberQuery();
            var trainersDto = await mediator.Send(query);
            return Ok(trainersDto);
        }

        [HttpPut("{memberId}/choose-trainer/{trainerId}")]
        [Authorize]
        public async Task<IActionResult> ChooseTrainer(int memberId, int trainerId)
        {
            var command = new ChooseTrainerCommand(memberId, trainerId);
            var isSuccessful = await mediator.Send(command);

            if (isSuccessful)
            {
                return Ok(new { message = "Member has selected a trainer." });
            }
            return Ok(new { message = "Uspesno." });
        }


        [HttpGet("{memberId}/check-rating/{trainerId}")]
        [Authorize]
        public async Task<IActionResult> CheckRating(int memberId, int trainerId)
        {
            var command = new CheckRatingQuery(memberId, trainerId);
            var isSuccessful = await mediator.Send(command);
            if (isSuccessful)
            {
                return Ok(new { message = "Rating exists." });
            }
            else
            {
                return Ok(new { message = "Rating does not exist." });
            }
        }

        [HttpPut("{memberId}/reset-selectedtrainer")]
        [Authorize]
        public async Task<IActionResult> ResetSelectedTrainer(int memberId)
        {
            var command = new ResetSelectedTrainerCommand(memberId);
            var isSuccessful = await mediator.Send(command);

            if (isSuccessful)
            {
                return Ok(new { message = "Reseted successfully." });

            }

            return Ok(new { message = "Successfully." });
        }

        [HttpGet("average-rating/{trainerId}")]
     
        public async Task<IActionResult> GetAverageRating(int trainerId)
        {
            var query = new GetAverageRating { TrainerId = trainerId };
            var result = await mediator.Send(query);

            if (result >= 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Nema ocena za datog trenera."); 
            }
        }

        [HttpGet("mytrainer/{trainerId}")]
        [Authorize]
        public async Task<IActionResult> GetMyTrainer(int trainerId)
        {
            var query = new GetTrainerQuery(trainerId);
            var trainer = await mediator.Send(query);
            return Ok(trainer);
        }

        [HttpGet("memberships/{memberId}")]
        [Authorize]
        public async Task<IActionResult> GetMembershipsForMember(int memberId)
        {
            var query = new GetMembershipsForMemberQuery { MemberId = memberId };
            var memberships = await mediator.Send(query);
            return Ok(memberships);
        }

        [HttpPost("extend-membership/{memberId}")]
        [Authorize]
        public async Task<IActionResult> ExtendMembership(int memberId, string newMembershipAmount, int targetMonth)
        {
            var command = new ExtendMembershipCommand
            {
                MemberId = memberId,
                MembershipAmount = newMembershipAmount,
                Month = targetMonth
            };
            var isExtended = await mediator.Send(command);

            if (isExtended)
            {
                return Ok("Membership extended successfully.");
            }

            return BadRequest("Membership extension failed. Member not found or extension for the current month.");
        }

        [HttpPost("{memberId}/rate-trainer/{trainerId}/{ratingValue}")]
        [Authorize]
        public async Task<IActionResult> RateTrainer(int memberId, int trainerId, int ratingValue)
        {
            var command = new RateTrainerCommand
            {
                MemberId = memberId,
                TrainerId = trainerId,
                RatingValue = ratingValue
            };
            var isRated = await mediator.Send(command);

            if (isRated)
            {
                return Ok(new { message = "Trainer rated successfully." });
            }

            return BadRequest(new { message = "Rating failed. Member or trainer not found, or invalid rating value." });
        }

        [HttpGet("comments/{memberId}")]
        [Authorize]
        public async Task<IActionResult> GetMemberComments(int memberId)
        {
            var query = new GetMemberCommentsQuery { MemberId = memberId };
            var comments = await mediator.Send(query);
            if (comments != null && comments.Any())
            {
                return Ok(comments);
            }
            return NotFound("No comments found for the member");
        }

        [HttpGet("check-selected-trainer/{memberId}")]
        [Authorize]
        public async Task<IActionResult> CheckSelectedTrainer(int memberId)
        {
            var query = new GetHasSelectedTrainerQuery { MemberId = memberId };
            var hasSelectedTrainer = await mediator.Send(query);

            if (hasSelectedTrainer)
            {
                return Ok(new { message = "Member has selected a trainer." });
            }
            else
            {
                return Ok(new { message = "Member has not selected a trainer." });
            }
        }

        [HttpGet("trainers/sort")]
        //[Authorize]
        public async Task<IActionResult> SortTrainers(string sortByField, int page, int pageSize)
        {
            var query = new SortTrainersQuery { SortByField = sortByField, Page = page, PageSize = pageSize };
            var sortedTrainers = await mediator.Send(query);

            if (sortedTrainers != null)
            {
                return Ok(sortedTrainers);
            }

            return NotFound("No trainers found or sorting failed.");
        }

        [HttpGet("trainers/paginated")]
        //[Authorize]
        public async Task<IActionResult> GetPaginatedTrainers(int page, int pageSize, int id)
        {
            var query = new GetPaginatedTrainersQuery(page, pageSize, id);
            var paginatedTrainers = await mediator.Send(query);

            if (paginatedTrainers != null)
            {
                return Ok(paginatedTrainers);
            }

            return NotFound("No paginated trainers found.");
        }


        [HttpGet("trainers/pagtrainers")]
        //[Authorize]
        public async Task<IActionResult> GetPagTrainers(int page, int pageSize)
        {
            var query = new GetTrainersQuery(page, pageSize);
            var paginatedTrainers = await mediator.Send(query);

            if (paginatedTrainers != null)
            {
                return Ok(paginatedTrainers);
            }

            return NotFound("No paginated trainers found.");
        }

        [HttpGet("trainers/filter-trainer")]
        //[Authorize]
        public async Task<IActionResult> FilterTrainer(int page, int pageSize, string filter)
        {
            var query = new GetFilteredTrainerQuery(page, pageSize, filter);
            var paginatedTrainers = await mediator.Send(query);

            if (paginatedTrainers != null)
            {
                return Ok(paginatedTrainers);
            }

            return NotFound("No paginated trainers found.");
        }

        [HttpGet("trainers/sort-trainers")]
        //[Authorize]
        public async Task<IActionResult> SortTrainers(int page, int pageSize, string sortBy)
        {
            var query = new SortPagTrainersQuery(page, pageSize, sortBy);
            var paginatedTrainers = await mediator.Send(query);

            if (paginatedTrainers != null)
            {
                return Ok(paginatedTrainers);
            }

            return NotFound("No paginated trainers found.");
        }
    }
}
