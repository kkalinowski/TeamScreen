using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace TeamScreen.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public byte[] UserPhoto { get; set; }
    }
}
