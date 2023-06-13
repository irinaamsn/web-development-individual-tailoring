//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gibrid.Models
{

    public class AppDBContent :IdentityDbContext<User>
    {
        //конструктор класса AppDBContent без параметров
        public AppDBContent() { }
        //конструктор класса AppDBContent, который принимает аргумент options типа DbContextOptions<AppDBContent>. Он вызывает базовый конструктор класса, передавая ему этот аргумент
        //Затем вызывается метод Database.EnsureCreated(), который создает базу данных, если она еще не создана
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { Database.EnsureCreated(); }
        public DbSet<CategorySpecialist> CategorySpecialist{ get; set; }//представляет коллекцию объектов типа CategorySpecialist в базе данны
        public DbSet<User> User { get; set; }//представляет коллекцию объектов типа User в базе данных
        public DbSet<Specialist> Specialist { get; set; }//представляет коллекцию объектов типа Specialist в базе данных
        public DbSet<SignUp> SignUp { get; set; }//представляет коллекцию объектов типа SignUp в базе данных
        public DbSet<SignUpDetail> SignUpDetail { get; set; }//представляет коллекцию объектов типа SignUpDetail в базе данных
        public DbSet<Time> Time { get; set; }//представляет коллекцию объектов типа Time в базе данных
        public DbSet<ReseptionItem> ReseptionItem { get; set; }//представляет коллекцию объектов типа ReseptionItem в базе данных
        public DbSet<DataStorageItem> DataStorageItem { get; set; }//представляет коллекцию объектов типа DataStorageItem в базе данных
        public DbSet<Works> Works { get; set; }//представляет коллекцию объектов типа Works в базе данных
        public DbSet<Reviews> Reviews { get; set; }//представляет коллекцию объектов типа Reviews в базе данных
        protected override void OnModelCreating(ModelBuilder builder)//метод переопределяющий базовый метод OnModelCreating класса DbContext
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
