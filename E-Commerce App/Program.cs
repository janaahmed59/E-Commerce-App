using E_Commerce_App.Models;
using E_Commerce_App.Services.ServiceImplementation;
using E_Commerce_App.UnitOfWorkLayer.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using E_Commerce_App.Services.Interface;
using E_Commerce_App.Repo;
using E_Commerce_App.UnitOfWorkLayer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
namespace E_Commerce_App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddEndpointsApiExplorer(); 
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer("Server = .\\SQLEXPRESS;Database= E-Commerce; Integrated Security = True;trust server certificate = true"));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            builder.Services.AddAuthentication()
            .AddJwtBearer(options =>
            {

                options.TokenValidationParameters =
                new TokenValidationParameters
                {

                    ValidateIssuer = true,

                    ValidateAudience = true,

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,


                    IssuerSigningKey =
                new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(
                builder.Configuration["Jwt:Key"]))

                };

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
