// Microsoft Learn. 2024. ASP.NET Core application startup, 12 December 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/startup [Accessed 16 October 2025].
// Microsoft Learn. 2024. Routing in ASP.NET Core, 18 September 2024. [Online]. Available at:https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing [Accessed 16 October 2025].
// Microsoft Learn. 2024. Session state in ASP.NET Core, 24 April 2024. [Online]. Available at:https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state [Accessed 16 October 2025].

using ST10085639_PROG6212_CMCS.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// This is to add MVC services to the containers in order to support the controllers and views
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // THis is to configure the database to use SQL servrs

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseSession();

// This is to configure default route patterns for the MVC controllers
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();