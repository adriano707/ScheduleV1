using Microsoft.AspNetCore.Identity;

namespace Schedule.CrossCutting.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
