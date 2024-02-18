using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBP.Domain.Identity;
using NBP.Infrastructure.Data;
using NBP.Application.Interfaces;
using NBP.Application.DTOs;

namespace NBP.Infrastructure.Repository
{
    public class AdministratorRepository : IAdministartorRepository
    {
        private readonly DataContext dc;

        public AdministratorRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddAdmin(Administrator administrator)
        {
#pragma warning disable CA2012 // Use ValueTasks correctly
            dc.Administrators.AddAsync(administrator);
#pragma warning restore CA2012 // Use ValueTasks correctly
        }
        public void AddManager(ManagerS manager)
        {
#pragma warning disable CA2012 // Use ValueTasks correctly
            dc.Managers.AddAsync(manager);
#pragma warning restore CA2012 // Use ValueTasks correctly
        }
        public void AddReceptionist(Receptionist receptionist)
        {
            //#pragma warning disable CA2012 // Use ValueTasks correctly
            dc.Receptionists.AddAsync(receptionist);
            //#pragma warning restore CA2012 // Use ValueTasks correctly
        }
        public void DeleteAdmin(int ID)
        {
            var user = dc.Administrators.Find(ID);
            //#pragma warning disable CS8604 // Possible null reference argument.
            dc.Administrators.Remove(user);
            //#pragma warning restore CS8604 // Possible null reference argument.
        }

        public async Task<IActionResult> GetAdmin(int ID)
        {
            var user = await dc.Administrators.FindAsync(ID);
            if (user == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(user);
        }

        public async Task<IEnumerable<Administrator>> GetAdminsAsync(int currentAdminId)
        {
            return await dc.Administrators
                .Where(a => a.ID != currentAdminId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Receptionist>> GetReceptionistsAsync()
        {
            return await dc.Receptionists.ToListAsync();
        }
        public async Task<IEnumerable<ManagerS>> GetManagersAsync()
        {
            return await dc.Managers.ToListAsync();
        }

    }
}
