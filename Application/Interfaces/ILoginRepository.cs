using Microsoft.AspNetCore.Mvc;
using NBP.Domain.Identity;

namespace NBP.Application.Interfaces
{
    public interface ILoginRepository
    {
        Task<IActionResult> PostLoginDetails(UserData userData);
        string GenerateRefreshToken();

    }
}
