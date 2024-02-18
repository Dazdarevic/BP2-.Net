using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBP.Application.DTOs;
using NBP.Application.Mediator.Commands.Receptionist_Commands;
using NBP.Application.Mediator.Handlers.Receptionist_Handlers;
using NBP.Application.Mediator.Queries.Receptionist_Queries;
using NBP.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceptionistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReceptionistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail(SendEmailCommand emailModel)
        {
            await _mediator.Send(emailModel);
            return Ok();
        }

        [HttpPost("create-registration-request")]
        public async Task<IActionResult> CreateRegistrationRequest(CreateRegistrationRequestCommand request)
        {
            var isRequestCreated = await _mediator.Send(request);

            if (isRequestCreated)
            {
                return Ok(new { message = "Registration request created successfully." });
            }

            return BadRequest("Creating registration request failed.");
        }

        [HttpGet("get-all-requests")]
        //[Authorize]
        public async Task<IActionResult> GetAllRequests()
        {
            var query = new GetAllRequestsQuery();
            var allRequestsDto = await _mediator.Send(query);
            return Ok(allRequestsDto);
        }

        [HttpGet("get-all-members-names")]
        //[Authorize]
        public async Task<IActionResult> GetAllMembersNames()
        {
            var query = new GetAllMembersQuery();
            var allRequestsDto = await _mediator.Send(query);
            return Ok(allRequestsDto);
        }

        [HttpPost("approve-registration-request/{requestId}")]
        //[Authorize]
        public async Task<IActionResult> ApproveRegistrationRequest(int requestId)
        {
            var command = new ApproveRegistrationRequestCommand(requestId);
            var isRequestApproved = await _mediator.Send(command);

            if (isRequestApproved)
            {
                return Ok(new { message = "Registration request approved and processed successfully." });
            }

            return BadRequest("Approving registration request failed.");
        }

        [HttpPost("create-payment")]
        //[Authorize]
        public async Task<IActionResult> CreatePayment(CreatePaymentCommand payment)
        {
            var result = await _mediator.Send(payment);

            if (result)
            {
                return Ok(new { success = true, message = "Payment created successfully." });
            }
            else
            {
                return BadRequest(new { success = false, message = "Failed to create payment." });
            }
        }

        [HttpDelete("delete-request/{requestId}")]
        [Authorize]
        public async Task<IActionResult> DeleteRequest(int requestId)
        {
            var command = new DeleteRequestCommand(requestId);
            var isRequestDeleted = await _mediator.Send(command);

            if (isRequestDeleted)
            {
                return Ok(new { message = "Registration request deleted successfully." });
            }

            return NotFound("Registration request not found or deletion failed.");
        }

        [HttpGet("all-payments")]
        public async Task<IActionResult> GetAllPayments()
        {
            var query = new GetAllPaymentsQuery();
            var result = await _mediator.Send(query);

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
