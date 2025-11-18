using Microsoft.AspNetCore.Identity;

namespace CondoLounge.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public int CondoId { get; set; }
        public Condo Condo { get; set; }
    }
}
