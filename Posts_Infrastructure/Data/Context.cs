
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Posts_Data.Entities;
using Posts_Data.Entities.Identity;


namespace Posts_Infrastructure.Data
{
    public class Context : IdentityDbContext<User>
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<Blog> posts { get; set; }

    }

}
