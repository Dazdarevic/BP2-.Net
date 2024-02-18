using Microsoft.AspNetCore.Mvc;
using NBP.Domain.Identity;

namespace NBP.Application.Interfaces
{
    public interface IAdministartorRepository
    {
        Task<IEnumerable<Administrator>> GetAdminsAsync(int currentAdminId);
        Task<IEnumerable<Receptionist>> GetReceptionistsAsync();
        Task<IEnumerable<ManagerS>> GetManagersAsync();
        void AddAdmin(Administrator administrator);
        void AddReceptionist(Receptionist receptionist);
        void AddManager(ManagerS manager);
        void DeleteAdmin(int ID);
        Task<IActionResult> GetAdmin(int ID);
    }
}
