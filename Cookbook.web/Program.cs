using Cookbook.Infrastructure.Extensions;
using Data.DataAccess;
using Data.DataModels.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var webApplicationBuilder = WebApplication.CreateBuilder(args);
var connectionString = webApplicationBuilder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// Add services to the container.
webApplicationBuilder.Services.AddDbContext<ApplicationDbContext>();
webApplicationBuilder.Services.AddDatabaseDeveloperPageExceptionFilter();

webApplicationBuilder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

webApplicationBuilder.Services.AddControllersWithViews();

var webApplication = webApplicationBuilder.Build();

var logger = webApplication.Services.GetService<ILogger<Program>>();

// Configure the HTTP request pipeline.
if (webApplication.Environment.IsDevelopment())
{
    webApplication.UseDeveloperExceptionPage();

    webApplication.UseMigrationsEndPoint();

    webApplication.MigrateDatabase(logger);

    webApplication.ApplyDatabaseSeeding(logger);
}
else
{
    webApplication.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    webApplication.UseHsts();
}

webApplication.UseHttpsRedirection();
webApplication.UseStaticFiles();

webApplication.UseRouting();

webApplication.UseAuthentication();
webApplication.UseAuthorization();

webApplication.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
webApplication.MapRazorPages();

webApplication.Run();
