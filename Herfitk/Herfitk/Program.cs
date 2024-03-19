
using Herfitk.API.TokenService;
using Herfitk.Core.Models;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Repository;

using Herfitk.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;

//using Herfitk.Repository.Data.DbContextBase;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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


            #region Configure Services
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Allow  Repository
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped(typeof(IHerifyRepository), typeof(HerifyRepository));
            builder.Services.AddScoped(typeof(IHerifyCategoriesRepository), typeof(HerifyCategoriesRepository));
            builder.Services.AddScoped(typeof(IStaffRepository), typeof(StaffRepository));

            

            //Allow DbContext D_Injection

            builder.Services.AddDbContext<HerfitkContext>(Use =>
            Use.UseSqlServer(builder.Configuration.GetConnectionString("BaseConnection")));

            builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
            builder.Services.AddAutoMapper(typeof(Program));


            builder.Services.AddAuthentication();
            builder.Services.AddIdentity<AppUser, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<HerfitkContext>().AddDefaultTokenProviders();

            //builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
                    ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                    (builder.Configuration.GetSection("Jwt:Key").Value))

                };
            });


            builder.Services.ConfigureApplicationCookie(options => { options.Cookie.SameSite = SameSiteMode.None; }); ///////

            //builder.Services.AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<IdentityContext>();


            #endregion





            var app = builder.Build();

            app.MapPost("/logout", async (SignInManager<IdentityUser> signInManager) => /////////////////////////////////
                    {
                        await signInManager.SignOutAsync().ConfigureAwait(false);
                    }).RequireAuthorization(); // So that only authorized users can use this endpoint


            //app.MapIdentityApi<AppUser>();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseCors(option => option.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());

            app.MapControllers();
            app.UseAuthentication();
            app.UseAuthorization();
            #endregion

            app.Run();
        }
    }
}
