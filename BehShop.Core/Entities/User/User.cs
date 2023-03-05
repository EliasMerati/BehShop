using BehShop.Domain.Attributes;
using Microsoft.AspNetCore.Identity;

namespace BehShop.Domain.Entities.User
{
//#nullable disable
    [Auditable]
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }

    }
}
