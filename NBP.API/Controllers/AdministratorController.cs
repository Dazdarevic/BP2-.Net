using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBP.Application.Mediator.Commands.Admin;
using NBP.Application.Mediator.Queries.Admin;
using NBP.Domain.Identity;
using Serilog;

namespace NPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly ILogger<AdministratorController> _logger; // Dodajte ILogger ovde


        public AdministratorController(IMediator mediator, ILogger<AdministratorController> logger)
        {
            this.mediator = mediator;
            _logger = logger; 
        }

        [HttpGet("admins")]
        //[Authorize]
        public async Task<IActionResult> GetAdminsAsync(int currentAdminId)
        {
            //Log.Information("Admins getall triggered"); local way to impc(currentAdminId);
            //var adminsDto = mapper.Map<IEnumerable<AdminDto>>(admins);lement serilog, we need to implement this globally.
            //this._logger.LogInformation("| Log || Testing");
            //var admins = await uow.AdministratorRepository.GetAdminsAsync
            _logger.LogInformation("Getting all admins."); // Primer korišćenja ILogger za logiranje informacije
            var command = new GetAllAdminsQuery(currentAdminId);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("receptionists")]
        //[Authorize]
        public async Task<IActionResult> GetReceptionistsAsync()
        {
            var command = new GetAllReceptionistsQuery();
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpGet("managers")]
        [Authorize]
        public async Task<IActionResult> GetManagersAsync()
        {
            var command = new GetAllManagersQuery();
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("admin/{id}")]
        public async Task<IActionResult> GetAdmin(int id)
        {
            var query = new GetAdminQuery(id); 

            var admin = await mediator.Send(query);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        [HttpPost("add-admin")]
        //[Authorize]
        public async Task<IActionResult> AddAdmin(AddAdminCommand administrator)
        {
            var newAdmin = await mediator.Send(administrator);
            return Ok(newAdmin);
        }
        [HttpPost("add-manager")]
        //[Authorize]
        public async Task<IActionResult> AddManager(AddManagerCommand manager)
        {
            var newManager = await mediator.Send(manager);
            return Ok(newManager);
        }
        [HttpPost("add-receptionist")]
        [Authorize]
        public async Task<IActionResult> AddReceptionist(AddReceptionistCommand receptionist)
        {
            var newRec = await mediator.Send(receptionist);
            return Ok(newRec);
        }

        [HttpDelete("delete/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteAdmin(int id)
        {
            var command = new DeleteAdminCommand(id);
            await mediator.Send(command);
            return Ok();
        }
    }
}
