using Gibrid.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Gibrid.Data;
using Gibrid.Models;
using Gibrid.Models.Interfaces;
using Gibrid.Models.Repository;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'WebApplication2ContextConnection' not found.");

builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connectionString));

//builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<UserContext>();

builder.Services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppDBContent>()
                .AddDefaultTokenProviders();
//builder.Services.AddIdentity<User, IdentityRole>()
//                .AddEntityFrameworkStores<UserContext>();

//builder.Services.AddIdentity<User, IdentityRole>(opts => {
//    opts.User.RequireUniqueEmail = true;    // уникальный email
//    opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz"; // допустимые символы
//}).AddEntityFrameworkStores<AppDBContent>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new PathString("/Account/Login");
                });
//builder.Services.AddMvc(o =>
//{
//    o.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
//});

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddIdentity<User, IdentityRole>();
builder.Services.AddTransient<IdentityUser, User>();
builder.Services.AddTransient<ISpecialistCategory, CategorySpecialistRepository>();
builder.Services.AddTransient<IAllSpecialist, SpecialistRepository>();
builder.Services.AddTransient<IAllSignUp, SignUpRepository>();
builder.Services.AddTransient<IListTime, TimeRepository>();
builder.Services.AddTransient<IPersonalAccount, PersonalAccountRepository>();
builder.Services.AddTransient<IDataStorage, DataStorageRepository>();
builder.Services.AddTransient<IAllWorks, WorksRepository>();
builder.Services.AddTransient<IReview, ReviewsRepository>();

//builder.Services.AddTransient<IUser, UserRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(res => Reseption.GetReseption(res));

builder.Services.AddMvc();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddHttpClient();
builder.Services.AddRazorPages();
//builder.Services.AddAuthentication("Bearer")  // добавление сервисов аутентификации
//    .AddJwtBearer();      // подключение аутентификации с помощью jwt-токенов
builder.Services.AddAuthorization();            // добавление сервисов авторизации

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(name: "categoryFilter", pattern: "Cars/{action}/{category?}", defaults: new { Controller = "Cars", action = "List" });
    endpoints.MapControllerRoute(name: "categorySpecialist", pattern: "Specialist/{action}/{category?}", defaults: new { Controller = "Specialist", action = "List" });
    endpoints.MapRazorPages(); //Routes for pages
    endpoints.MapControllers(); //Routes for my API controllers
    //endpoints.MapControllerRoute(name: "Register", pattern: "User/{action}", defaults: new { Controller = "User", action = "CreateAccount" });
    // endpoints.MapControllerRoute(name: "ShopCart", pattern: "ShopCart/{action}/{id?}", defaults: new { Controller = "ShopCart", action = "AddToACart" });
});

AppDBContent content;
using (var scope = app.Services.CreateScope())
{
    content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
   // DbObjects.Initial(content);
    //DbObjects.CategoriesSpecialist(content);
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<User>>();
        var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await RoleInitializer.InitializeAsync(userManager, rolesManager);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}
app.Run();
