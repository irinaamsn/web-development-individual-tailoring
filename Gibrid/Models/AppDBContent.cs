//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gibrid.Models
{

    public class AppDBContent :IdentityDbContext<User>
    {
        public AppDBContent() { }
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { Database.EnsureCreated(); }
        public DbSet<CategorySpecialist> CategorySpecialist{ get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Specialist> Specialist { get; set; }
        public DbSet<SignUp> SignUp { get; set; }
        public DbSet<SignUpDetail> SignUpDetail { get; set; }
        public DbSet<Time> Time { get; set; }
        public DbSet<ReseptionItem> ReseptionItem { get; set; }
        public DbSet<DataStorageItem> DataStorageItem { get; set; }
        public DbSet<Works> Works { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
