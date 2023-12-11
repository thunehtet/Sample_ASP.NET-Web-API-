using Microsoft.AspNetCore.Identity;
using SampleProject.Models;

namespace SampleProject.Contracts
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto user);
    }
}
