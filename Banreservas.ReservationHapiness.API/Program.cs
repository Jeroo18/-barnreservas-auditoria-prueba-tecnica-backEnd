using Banreservas.ReservationHapiness.API;
using Microsoft.Net.Http.Headers;
using Serilog;
using System.Net;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Banreservas ReservationHappiness API starting");

var builder = WebApplication.CreateBuilder(args);

//ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
//ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

ServicePointManager.ServerCertificateValidationCallback +=
    (sender, cert, chain, sslPolicyErrors) => true;

builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
     .WriteTo.Console()
     .ReadFrom.Configuration(context.Configuration));

var app = builder
       .ConfigureServices()
       .ConfigurePipeline();


app.UseSerilogRequestLogging();

//await app.ResetDatabaseAsync();

app.Run();

public partial class Program { }
































//using log4net.Config;
//using Banreservas.ReservationHapiness.API.Services;
//using Banreservas.ReservationHapiness.Application.Interfaces;
//using Banreservas.ReservationHapiness.Persistence;
//using System.Runtime.Loader;
//using Serilog;
//using Microsoft.OpenApi.Models;
//using Microsoft.Extensions.Options;
//using Banreservas.ReservationHapiness.API.Middleware;
//using Microsoft.EntityFrameworkCore;
//using Banreservas.ReservationHapiness.Infrastructure;
//using GloboTicket.TicketManagement.Persistence;
//using Banreservas.ReservationHapiness.Application;

//namespace Banreservas.ReservationHapiness.API;

//class Program
//{
//    private static IConfiguration _configuration;
//    static void Main(string[] args)
//    {
//        //Log.Logger = new LoggerConfiguration()
//        //    .WriteTo.Console()
//        //    //.CreateBootstrapLogger()
//        //    ;


//        Log.Information("MAP OSP API starting");

//        var files = Directory.GetFiles(
//            AppDomain.CurrentDomain.BaseDirectory,
//            "MAP.OSP*.dll");

//        var assemblies = files
//            .Select(p => AssemblyLoadContext.Default.LoadFromAssemblyPath(p));

//        var builder = WebApplication.CreateBuilder(args);

//        //Injecting services
//        builder.Services.AddApplicationServices();
//        builder.Services.AddInfrastructureServices(builder.Configuration);        
//        builder.Services.AddPersistenceServices(builder.Configuration);

//        //builder.Host.UseSerilog((context, loggerConfiguration) => loggerConfiguration
//        // .WriteTo.Console()
//        // .ReadFrom.Configuration(context.Configuration));

//        //Configure Log4net.
//        XmlConfigurator.Configure(new FileInfo("log4net.config"));

//        builder.Services.AddHttpContextAccessor();
//        //Injecting services.
//        //builder.Services.RegisterServices(_configuration);

//        builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

//        builder.Services.AddControllers();

//        builder.Services.AddCors(options =>
//        {
//            options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
//        });

//        builder.Services.AddEndpointsApiExplorer();

//        builder.Services.AddSwaggerGen(options =>
//            {
//                options.DocumentFilter<LowercaseDocumentFilter>();
//                options.SwaggerDoc("v1", new OpenApiInfo
//                {
//                    Version = "v1",
//                    Title = "Banreservas.ReservationHapiness.API",
//                    Description = "An ASP.NET Core Web API for managing OSP system",
//                    TermsOfService = new Uri("https://example.com/terms"),
//                    Contact = new OpenApiContact
//                    {
//                        Name = "Example Contact",
//                        Url = new Uri("https://example.com/contact")
//                    },
//                    License = new OpenApiLicense
//                    {
//                        Name = "Example License",
//                        Url = new Uri("https://example.com/license")
//                    }
//                });
//            });

//        builder.Services.AddAdvancedDependencyInjection();

//        builder.Services.Scan(p => p.FromAssemblies(assemblies)
//            .AddClasses()
//            .AsMatchingInterface());

//        var app = builder.Build();

//        if (app.Environment.IsDevelopment())
//        {
//            // Enable middleware to serve generated Swagger as a JSON endpoint.
//            app.UseSwagger();
//            app.UseSwaggerUI(c =>
//            {
//                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banreservas.ReservationHapiness.API v1");
//            });
//        }

//        //app.UseSerilogRequestLogging();

//       // await app.ResetDatabaseAsync();

//        app.UseHttpsRedirection();

//        app.UseAuthentication();

//        app.UseCustomExceptionHandler();

//        app.UseCors("Open");

//        app.UseAuthorization();

//        app.MapControllers();

//        app.UseAdvancedDependencyInjection();

//        //app.ResetDatabaseAsync();

//        app.Run();
//    }


//    static async Task ResetDatabaseAsync(this WebApplication app)
//    {
//        using var scope = app.Services.CreateScope();
//        try
//        {
//            var context = scope.ServiceProvider.GetService<MAPOSPDbContext>();
//            if (context != null)
//            {
//                await context.Database.EnsureDeletedAsync();
//                await context.Database.MigrateAsync();
//            }
//        }
//        catch (Exception ex)
//        {
//            //var logger = scope.ServiceProvider.GetRequiredService<Application.Interfaces.ILogger>();
//            //logger.Error(ex, "An error occurred while migrating the database.");
//        }
//    }
//}


