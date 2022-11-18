using AutoMapper;
using HorizonSearchPlatform.Server;
using HorizonSearchPlatform.Server.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

using IHost host = CreateHostBuilder(args);


var configurationBuilder = new ConfigurationBuilder();
BuildConfig(configurationBuilder);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configurationBuilder.Build())
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();
Log.Logger.Information("Server starting");

var configuration = host.Services.GetService<IConfiguration>();
var connectionClient = host.Services.GetService<ConnectionClient>();

var address = configuration.GetSection("ConnectionInfo").Get<ConnectionAddress>();

var listener = connectionClient.GetListener(address);

try
{
    listener.Start();


    while (true)
    {
        var client = listener.AcceptTcpClient();

        var processingThread = new Thread(new ParameterizedThreadStart(connectionClient.Process));
        processingThread.Start(client);
    }
}
catch (Exception ex)
{
    Log.Error(ex.Message);
}
finally
{
    if (listener != null)
        listener.Stop();
}

IHost CreateHostBuilder(string[] args)
{
    var mapperConfiguration = new MapperConfiguration(
        cf => cf.AddProfile(new MapperProfile()));
    var mapper = mapperConfiguration.CreateMapper();
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<ConnectionClient>();
            services.AddSingleton(mapper);
        })
        .UseSerilog()
        .Build();
}
static void BuildConfig(IConfigurationBuilder builder)
{
    builder.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", false, true)
        .AddEnvironmentVariables();

}