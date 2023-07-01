using Demo1.Helper.Services.GrpcServiceClient;
using UserService.Application.Models;
using UserService.Application.Registration;
using UserService.Persistence.Registration;
using UserService.Persistence.Seeds;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders(); //Default olarak eklenen b�t�n log providerlar�n� kald�r�r
builder.Logging.AddConsole(); //Sadece `Console` provider�n� ekler
builder.Logging.AddDebug(); //Sadece `Debug` provider�n� ekler
builder.Logging.AddEventSourceLogger(); //Sadece `EventSource` provider�n� ekler

// Add services to the container.

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
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(configuration).AddControllers();
#region ForGrpc
builder.Services.AddSingleton(appSettings.GrpcServiceSettings); //AppSettings i�erisinde tan�mlad���m�z "GrpcServiceSettings" objectini de servise ekledik ��nk� grpc servisinin hangi portta vs �al��aca��n� bilmemiz gerekiyor
builder.Services.AddSingleton<IGrpcServiceClientFactory, GrpcServiceClientFactory>(); //Registration etmemiz gerekiyor ��nk� bu "GrpcServiceClientFactory" kullanarak "noteApiGrpcServiceClient.FirstGrpcServiceAsync" grpc servisini �a��raca��z
#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.UsePersistence();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
await app.Services.InitializeDatabase();
app.Run();
public partial class Program { }