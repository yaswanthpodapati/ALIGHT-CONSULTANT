using AllRightConsultant.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AllRightConsultant.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        public DbSet<ProjectWork> ProjectWorks { get; set; }
        public DbSet<ProjectTypeNature> ProjectTypeNatures { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Taluka> Talukas { get; set; }
        public DbSet<WorkLabourCess> WorkLabourCesss { get; set; }        
    }
}