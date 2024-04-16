using Herfitk.Core.Models;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;
using Herfitk.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
//Allow Debdancy Injection
builder.Services.AddScoped(typeof(IHerifyRepository), typeof(HerifyRepository));

builder.Services.AddScoped(typeof(IStaffRepository), typeof(StaffRepository));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = false)
               .AddEntityFrameworkStores<HerfitkContext>().AddDefaultTokenProviders();

builder.Services.AddDbContext<HerfitkContext>(Use =>
Use.UseSqlServer(builder.Configuration.GetConnectionString("BaseConnection")));
builder.Services.AddAutoMapper(typeof(Program));

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
//app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();