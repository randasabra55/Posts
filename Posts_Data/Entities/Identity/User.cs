using Microsoft.AspNetCore.Identity;

namespace Posts_Data.Entities.Identity
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public virtual ICollection<Blog>? Posts { get; set; }
    }
}
