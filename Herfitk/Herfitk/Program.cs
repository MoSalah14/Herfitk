using Herfitk.API.ChatServices;
using Herfitk.API.Helpers;
using Herfitk.API.Hubs;
using Herfitk.API.SendEmail;
using Herfitk.API.TokenService;
using Herfitk.Core;
using Herfitk.Core.Models;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Service_Contract;
using Herfitk.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;

//using Herfitk.Repository.Data.DbContextBase;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Configuration;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Herfitk
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("CORSPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed((hosts) => true));
            });


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.ConfigureApplicationCookie(options => { options.Cookie.SameSite = SameSiteMode.None; }); ///////

            #region Configure Services

            builder.Services.AddApplicationService(builder.Configuration);

            #endregion Configure Services



            var app = builder.Build();

            app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager) => /////////////////////////////////
                    {
                        await signInManager.SignOutAsync().ConfigureAwait(false);
                    }).RequireAuthorization(); // So that only authorized users can use this endpoint


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

            #endregion AutoUpdate Database

            #region MiddleWares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.MapIdentityApi<AppUser>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CORSPolicy");

            app.MapHub<ChatHub>("/hubs/chat");
            //app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

            app.MapControllers();
            app.UseAuthentication();
            app.UseAuthorization();

            #endregion MiddleWares

            app.Run();
        }
    }
}