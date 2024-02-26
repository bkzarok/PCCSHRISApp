using HRISApplication.Data;
using HRISApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<SspdfContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//            name: "areas",
//            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//          );

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=PersonalDetails}/{action=Index}/{id?}");
app.MapRazorPages();

#pragma warning disable ASP0014 // Suggest using top level route registrations
app.UseEndpoints(endpoints =>
{
    //endpoints.MapAreaControllerRoute(
    //  name: "PersonalDetailsArea",
    //  areaName: "PersonalDetailsArea",
    //  pattern: "PersonalDetailsArea/{controller=PersonalDetails}/{action=Index}/{id?}"
    //);

    endpoints.MapControllerRoute(
     name: "areas",
     pattern: "{area:exists}/{controller=PersonalDetails}/{action=Index}/{id?}"
   );

    endpoints.MapControllerRoute(
        name: "default",
       // pattern: "{area=PersonalDetailsArea}/{controller=PersonalDetails}/{action=Index}/{id?}" );
        pattern: "{controller=Home}/{action=Index}/{id?}");

});
#pragma warning restore ASP0014 // Suggest using top level route registrations



app.Run();
