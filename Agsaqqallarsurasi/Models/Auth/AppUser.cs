using Microsoft.AspNetCore.Identity;

namespace Agsaqqallarsurasi.Models.Auth
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
    }
}
