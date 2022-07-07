using IdentityServer;
using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
var seed = args.Contains("/seed");
if (seed)
{
    args = args.Except(new[] { "/seed" }).ToArray();
}

var builder = WebApplication.CreateBuilder(args);
var assembly = typeof(Program).Assembly.GetName().Name;
var defaultconnstring = builder.Configuration.GetConnectionString("DefaultConnection");

if(seed)
{
    SeedData.EnsureSeedData(defaultconnstring);
}

builder.Services.AddDbContext<AspNetIdentityDBConntext>(options =>
{
    options.UseSqlServer(defaultconnstring,b=>b.MigrationsAssembly(assembly));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AspNetIdentityDBConntext>();

builder.Services.AddIdentityServer().
    AddConfigurationStore(options =>
{
    options.ConfigureDbContext = b =>
    b.UseSqlServer(defaultconnstring, opt => opt.MigrationsAssembly(assembly));
})
    .AddOperationalStore(options =>
{
    options.ConfigureDbContext = b =>
    b.UseSqlServer(defaultconnstring, opt => opt.MigrationsAssembly(assembly));
})
    .AddDeveloperSigningCredential();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
app.Run();
