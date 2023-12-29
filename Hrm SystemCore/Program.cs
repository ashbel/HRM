
using Hrm_SystemCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Hrm_SystemCore;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddSystemWebAdapters();
//builder.Services.AddHttpForwarder();
//builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<HRMEntities>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HRMEntities")));
builder.Services.AddDefaultIdentity<Users>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<HRMEntities>();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

//app.UseSystemWebAdapters();

//app.MapDefaultControllerRoute();
//app.MapForwarder("/{**catch-all}", app.Configuration["ProxyTo"])
//    .Add(static builder => ((RouteEndpointBuilder)builder).Order = int.MaxValue);

app.Run();
