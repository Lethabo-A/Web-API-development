
using API_development.models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JWTAuthentication.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<JobTelemetry> JobTelemetry { get; set; }
        public DbSet<Process> Process { get; set; } // Ensure this line is present
        public DbSet<Client> Clients { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<JobTelemetry>().ToTable("JobTelemetry", "Telemetry");

        }
    }
}

