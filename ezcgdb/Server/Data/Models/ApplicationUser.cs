using Microsoft.AspNetCore.Identity;

namespace ezcgdb.Server.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int? CounterId { get; set; }

        public virtual Counter Counter { get; set; }
    }
}
