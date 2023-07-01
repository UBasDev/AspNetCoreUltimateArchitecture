using Demo1.Helper.Exceptions;
using Demo1.Helper.Services.GrpcServiceClient;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using NoteService.Application.Models;
using NoteService.Grpc.Services;
using NoteService.Persistence.Registration;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.

try
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Configuration/Settings"))
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

    var appSettings = new AppSettings();
    configuration.Bind(nameof(AppSettings), appSettings);

    builder.Services.AddSingleton(appSettings);
    builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
    builder.Services.AddHttpClient();
    builder.Services.AddHttpContextAccessor();
    builder.Services.AddSingleton(appSettings.GrpcServiceSettings);
    

    builder.Services.AddPersistenceServices().AddGrpc(options =>
    {
        {
            options.EnableDetailedErrors = true;
            options.MaxReceiveMessageSize = null;
            options.MaxSendMessageSize = null;
            options.Interceptors.Add<ExceptionGrpcInterceptor>();
            options.EnableDetailedErrors = true;
        }
    });

    var isUseWithoutTls =
        bool.Parse(configuration["AppSettings:GrpcServiceSettings:NoteApiGrpcServiceSettings:isUseWithoutTls"]);
    if (isUseWithoutTls)
        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(
                Convert.ToInt32(configuration["AppSettings:GrpcServiceSettings:NoteApiGrpcServiceSettings:Port"]),
                o => o.Protocols =
                    HttpProtocols.Http2);
        });
    const string allowAllPolicy1 = "AllowAllPolicy1";
    builder.Services.AddGrpcReflection();
    builder.Services.AddCors(o => o.AddPolicy(name: allowAllPolicy1,
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                .WithExposedHeaders("Grpc-Status", "Grpc-Message");
        }));

    var app = builder.Build();
    
    if (appSettings.IsSwaggerActive)
    {
        app.MapGrpcReflectionService();
    }
    
    app.UseRouting();
    app.UseCors(allowAllPolicy1);
    app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });

    app.MapGrpcService<NoteApiGrpcService>().EnableGrpcWeb().RequireCors(allowAllPolicy1);
    app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

    app.Run();

}
catch (Exception ex)
{
    Console.WriteLine("Error While Hosting Services: {0}", ex);
}

//builder.Services.AddGrpc();



// Configure the HTTP request pipeline.
/*
app.MapGrpcService<NoteApiGrpcService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
*/