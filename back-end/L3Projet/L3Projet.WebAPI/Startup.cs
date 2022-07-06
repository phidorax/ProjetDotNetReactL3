﻿using L3Projet.Business.Implementations;
using L3Projet.Business.Interfaces;
using L3Projet.Common;
using L3Projet.Common.Models;
using L3Projet.DataAccess;
using L3Projet.WebAPI.HealthCheck;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace L3Projet.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private const string CORS_POLICY = "CORS_POLICY";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // Add services to the container.
            services.AddTransient<IMersService, MersService>();
            services.AddTransient<IIlesService, IlesService>();
            services.AddTransient<IClassementsService, ClassementsService>();
            services.AddTransient<IBatimentsService, BatimentsService>();
            services.AddTransient<IBatimentParametrageService, BatimentParametrageService>();
            services.AddTransient<ICoutRessourcesService, CoutRessoucesService>();
            services.AddTransient<IMondesService, MondesService>();
            services.AddTransient<IParametragesService, ParametragesService>();
            services.AddTransient<IRessoucesService, RessourcesService>();
            services.AddTransient<IUtilisateursService, UtilisateursService>();
            services.AddTransient<IUtilisateursMicrosoftService, UtilisateursMicrosoftService>();
            services.AddTransient<IUtilisateursLocalService, UtilisateursLocalService>();
            services.AddScoped<GameContext>();

            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            var builder = WebApplication.CreateBuilder();
            var configuration = builder.Configuration;

            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = configuration["Authentication:Microsoft:ClientId"];
                microsoftOptions.ClientSecret = configuration["Authentication:Microsoft:ClientSecret"];
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: CORS_POLICY,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:3000")
                                            .AllowAnyMethod()
                                            .AllowAnyHeader();
                                  });
            });

            services.AddAuthorization();

            services.AddHealthChecks()
                .AddCheck<DbHealthCheck>("Database");

            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(CORS_POLICY);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}")
                .RequireAuthorization();

                endpoints.MapHealthChecks("/health");
            });
        }
    }
}
