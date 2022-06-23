using Microsoft.AspNetCore.Identity;

namespace eTicaret.Core.DbModels.Identity
{
    public class AppUser:IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }

    }
}
