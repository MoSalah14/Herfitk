using Herfitk.API.ChatServices;
using Herfitk.API.SendEmail;
using Herfitk.API.TokenService;
using Herfitk.Core;
using Herfitk.Core.Models.Data;
using Herfitk.Core.Models;
using Herfitk.Core.Service_Contract;
using Herfitk.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StackExchange.Redis;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Herfitk.API.Helpers
{
    public static class ApplicationServiceExtension
    {

        public static IServiceCollection AddApplicationService(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            Services.AddSingleton<IResponseCachService, ResponseCachService>();

            Services.AddSingleton<ChatService>();
            Services.AddSignalR();


            //Allow DbContext D_Injection

            Services.AddDbContext<HerfitkContext>(Use =>
            Use.UseSqlServer(configuration.GetConnectionString("BaseConnection")));

            Services.AddScoped(typeof(IAuthService), typeof(AuthService));
            Services.AddAutoMapper(typeof(Program));

            Services.AddAuthentication();
            Services.AddIdentity<AppUser, IdentityRole<int>>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<HerfitkContext>().AddDefaultTokenProviders();

            Services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            Services.AddTransient<IEmailService, EmailService>();


            Services.AddSingleton<IConnectionMultiplexer>(ServiceProv =>
            {
                var connection = configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connection);
            });



            Services.AddAuthentication(option =>
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
                    ValidIssuer = configuration.GetSection("Jwt:Issuer").Value,
                    ValidAudience = configuration.GetSection("Jwt:Audience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                    (configuration.GetSection("Jwt:Key").Value))
                };
            });


            return Services;

        }
    }
}
