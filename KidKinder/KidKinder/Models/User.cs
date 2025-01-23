using Microsoft.AspNetCore.Identity;

namespace KidKinder.Models
{
    public class User : IdentityUser
    {
        public string Fullname { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
