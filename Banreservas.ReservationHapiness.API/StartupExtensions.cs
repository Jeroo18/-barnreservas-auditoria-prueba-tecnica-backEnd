using Banreservas.ReservationHapiness.API.Middleware;
using Banreservas.ReservationHapiness.API.Services;
using Banreservas.ReservationHapiness.API.Utility;
using Banreservas.ReservationHapiness.Application;
using Banreservas.ReservationHapiness.Application.Interfaces;
using Banreservas.ReservationHapiness.Identity;
using Banreservas.ReservationHapiness.Infrastructure;
using Banreservas.ReservationHapiness.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using Serilog;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using Banreservas.ReservationHapiness.Domain.Entities;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Banreservas.ReservationHapiness.API
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
        this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);

            //Injecting services
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            builder.Services.AddHttpContextAccessor();
            // Add services to the container.
            builder.Services.AddControllers()
                .AddJsonOptions(configure =>
                {
                    configure.JsonSerializerOptions.PropertyNamingPolicy = null;
                    //  configure.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
                });
            builder.Services
            .AddMvcCore(options =>
            {
                options.RequireHttpsPermanent = true; // does not affect api requests
                options.RespectBrowserAcceptHeader = true; // false by default
                                                           //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();

                //remove these two below, but added so you know where to place them...
                //options.OutputFormatters.Add(new YourCustomOutputFormatter());
                //options.InputFormatters.Add(new YourCustomInputFormatter());
            })
            //.AddApiExplorer()
            //.AddAuthorization()
            .AddFormatterMappings()
            //.AddCacheTagHelper()
            //.AddDataAnnotations()
            //.AddCors()
            //.AddJsonFormatters()
            ; // JSON, or you can build your own custom one (above)

            builder.Services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = (int)HttpStatusCode.TemporaryRedirect;
                options.HttpsPort = 5001;
            });

            builder.Services.AddEndpointsApiExplorer();


            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();


            builder.Services.AddCors(options =>
            {

                options.AddPolicy("CorsPolicy", corsBuilder =>
                {
                    corsBuilder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();

                });
            });

            return builder.Build();

        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservationHappiness API");
                });
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReservationHappiness API - Azure");
                });
            }

            app.UseHttpsRedirection();
            app.UseCustomExceptionHandler();
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            return app;

        }

        private static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
               
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ReservationHappiness API",

                });

                c.OperationFilter<FileResultContentTypeOperationFilter>();

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,

                        },
                        new List<string>()
                      }
                    });
            });
        }

        //public static async Task ResetDatabaseAsync(this WebApplication app)
        //{
        //    using var scope = app.Services.CreateScope();
        //    try
        //    {
        //        var context = scope.ServiceProvider.GetService<ReservationHappinessDbContext>();
        //        if (context != null)
        //        {
        //            await context.Database.EnsureDeletedAsync();
        //            await context.Database.MigrateAsync();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
        //        //logger.LogError(ex, "An error occurred while migrating the database.");
        //    }
        //}
    }
}