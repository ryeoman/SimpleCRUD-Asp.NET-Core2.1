using Medico.Challange.DL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Medico.Challange.DL
{
    public class ApplicationMainDbContext: IdentityDbContext<ApplicationUser>
    {

        public DbSet<Patient> Patient { get; set; }

        public ApplicationMainDbContext(DbContextOptions<ApplicationMainDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
