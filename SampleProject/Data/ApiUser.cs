using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;

namespace SampleProject.Data
{
    public class ApiUser:IdentityUser   
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
    }
}
