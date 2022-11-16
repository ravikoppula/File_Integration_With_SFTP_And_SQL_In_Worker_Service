//using File_Integration_With_SFTP_And_SQL_In_Worker_Service;
using Serilog;
using Serilog.Enrichers;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Security.Principal;

// https://codeburst.io/create-a-windows-service-app-in-net-core-3-0-5ecb29fb5ad0
//const string loggerTemplate = @"{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u4}]<{ThreadId}> [{SourceContext:l}] {Message:lj}{NewLine}{Exception}";
//var baseDir = AppDomain.CurrentDomain.BaseDirectory;

//Console.WriteLine(baseDir + "Testing the logger location");

//var logfile = Path.Combine(baseDir, "App_Data", "logs", "log.txt");
//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//    .Enrich.With(new ThreadIdEnricher())
//    .Enrich.FromLogContext()
//    .WriteTo.Console(LogEventLevel.Information, loggerTemplate, theme: AnsiConsoleTheme.Literate)
//    .WriteTo.File(logfile, LogEventLevel.Information, loggerTemplate,
//        rollingInterval: RollingInterval.Day, retainedFileCountLimit: 90)
//    .CreateLogger();

//try
//{
//    Log.Information("====================================================================");
//    Log.Information($"Application Starts. Version: {System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version}");
//    Log.Information($"Application Directory: {AppDomain.CurrentDomain.BaseDirectory}");
//    Host.CreateDefaultBuilder(args).Build().Run();
//}
//catch (Exception e)
//{
//    Log.Fatal(e, "Application terminated unexpectedly");
//}
//finally
//{
//    Log.Information("====================================================================\r\n");
//    Log.CloseAndFlush();
//}

//IHost host = (IHost)Host.CreateDefaultBuilder(args)

//    .UseWindowsService()
//    .ConfigureAppConfiguration((context, config) =>
//    {
//        // configure the app here.
//    })

//    .ConfigureServices((hostContext, services) =>
//    {
//        services.AddHostedService<Worker>();

//        services.Configure<AppSettings>(hostContext.Configuration.GetSection("AppSettings"));
//        services.AddScoped<IServiceA, ServiceA>();
//        services.AddScoped<IServiceB, ServiceB>();

//    })
//     .UseSerilog();

namespace File_Integration_With_SFTP_And_SQL_In_Worker_Service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const string loggerTemplate = @"{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u4}]<{ThreadId}> [{SourceContext:l}] {Message:lj}{NewLine}{Exception}";
            var baseDir = AppDomain.CurrentDomain.BaseDirectory;

            Log.Information(baseDir + "Testing the logger location");

            var logfile = Path.Combine(baseDir, "App_Data", "logs", "log.txt");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.With(new ThreadIdEnricher())
                .Enrich.FromLogContext()
                .WriteTo.Console(LogEventLevel.Information, loggerTemplate, theme: AnsiConsoleTheme.Literate)
                .WriteTo.File(logfile, LogEventLevel.Information, loggerTemplate,
                    rollingInterval: RollingInterval.Day, retainedFileCountLimit: 90)
                .CreateLogger();

            try
            {
                Log.Information("====================================================================");
                Log.Information($"Application Starts. Version: {System.Reflection.Assembly.GetEntryAssembly()?.GetName().Version}");
                Log.Information($"Application Directory: {baseDir}");
                if (OperatingSystem.IsWindows())
                {
                    var userName = WindowsIdentity.GetCurrent().Name;
                    Log.Information("The runner account is [{runnerAccountName}]", userName);
                }

                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception e)
            {
                Log.Fatal(e, "Application terminated unexpectedly");
            }
            finally
            {
                Log.Information("====================================================================\r\n");
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .ConfigureAppConfiguration((context, config) =>
                {
                    // Configure the app here.
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();

                    services.Configure<AppSettings>(hostContext.Configuration.GetSection("AppSettings"));
                    services.AddScoped<IServiceA, ServiceA>();
                    services.AddScoped<IServiceB, ServiceB>();
                })
                .UseSerilog();
    }

}



