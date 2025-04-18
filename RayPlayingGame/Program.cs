using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace RayPlayingGame;

internal class Program(ILogger<Program> logger)
{
    private static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddLogging(x => x.AddSerilog());
        serviceCollection.AddSingleton<Program>();

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var program = serviceProvider.GetService<Program>();

        program?.Run();
    }

    public void Run()
    {
        try
        {

        }
        catch (Exception exception)
        {
            logger.LogCritical(exception, exception.Message);
        }
    }
}