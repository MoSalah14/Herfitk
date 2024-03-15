
using Herfitk.Core.Models;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;

using Herfitk.Repository;
//using Herfitk.Repository.Data.DbContextBase;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.PortableExecutable;

namespace Herfitk
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);





            #region Configure Services
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Allow  Repository
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IHerifyRepository), typeof(HerifyRepository));

            //Allow DbContext D_Injection
            builder.Services.AddDbContext<HerfitkContext>(Use =>
            Use.UseSqlServer(builder.Configuration.GetConnectionString("BaseConnection")));

            builder.Services.AddAutoMapper(typeof(Program));


            builder.Services.AddAuthentication();
            builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<HerfitkContext>();
            //builder.Services.AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<IdentityContext>();


            #endregion





            var app = builder.Build();

            #region AutoUpdate Database
            using var scope = app.Services.CreateScope();

            var services = scope.ServiceProvider;
            var _Context = services.GetRequiredService<HerfitkContext>();

            var IdentityDbContext = services.GetRequiredService<HerfitkContext>();

            var loggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                await _Context.Database.MigrateAsync(); // Update Database
                await IdentityDbContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "Error When Try Update Database");

            }
            #endregion


            #region MiddleWares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.MapIdentityApi<AppUser>();
            app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}
