using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SampleProject.Contracts;
using SampleProject.Data;
using SampleProject.Models;

namespace SampleProject.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper mapper;
        private readonly UserManager<ApiUser> userManager;

        public AuthManager(IMapper mapper,UserManager<ApiUser> userManager) 
        { 
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            var user = mapper.Map<ApiUser>(userDto);
            user.UserName = userDto.Email;

            var result=await userManager.CreateAsync(user,userDto.Password);
            if(result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors;
        }
    }
}
