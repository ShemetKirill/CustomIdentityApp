using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CustomIdentityApp.Models
{
    public class ApplicationContext: IdentityDbContext<User>
    {

        public DbSet<Note> Notes { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base (options)

        {
            Database.EnsureCreated();
        }
    }
}
