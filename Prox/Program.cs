using MySql.Data.MySqlClient;
using System.Data;
using Prox;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Prox.Data;



var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDbConnection>((s) =>
{

    IDbConnection conn = new MySqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"));
    conn.Open();
    return conn;

});

builder.Services.AddDbContext<ProxContext>(options => options.UseSqlServer("name=ConnectionStrings:Proappconecctions"));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ProxContext>();








// interfacerepository & class repository
builder.Services.AddTransient<IClientRepository,CientRepository >();
builder.Services.AddTransient<IScheduleRepository,ScheduleRepository >();
var app = builder.Build();



// Configure the HTTP request pipeline.

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); ;
app.UseAuthorization();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();

