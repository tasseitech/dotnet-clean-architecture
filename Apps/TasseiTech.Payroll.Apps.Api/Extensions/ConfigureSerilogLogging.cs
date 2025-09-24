using Serilog;
using Serilog.Events;
using Serilog.Sinks.Datadog.Logs;

namespace TasseiTech.Sample.Apps.Api.Extensions;

/// <summary></summary>
public static class ConfigureSerilogLogging
{
    /// <summary>Configures the tassei logging.</summary>
    /// <param name="builder">The builder.</param>
    /// <param name="configureLogger">The configure logger.</param>
    /// <returns></returns>
    public static IHostBuilder ConfigureTasseiLogging(this IHostBuilder builder,
        Action<HostBuilderContext, LoggerConfiguration> configureLogger = null)
    {
        builder.UseSerilog((hostingContext, loggerConfiguration) =>
        {
            loggerConfiguration.MinimumLevel.Information()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information)
                    .MinimumLevel.Override("System", LogEventLevel.Warning)
                    .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Debug,
                                     outputTemplate: "[{Timestamp:u}][{SourceContext}] - {Level:u5} -- {Message}{NewLine}{Exception}");


            var ddApiKey = hostingContext.Configuration.GetValue<string>("ApiKeys:DD_API_KEY");
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "development";

            if (!string.IsNullOrWhiteSpace(ddApiKey))
            {
                loggerConfiguration.Enrich.FromLogContext();
                loggerConfiguration
                .WriteTo.DatadogLogs(
                    ddApiKey,
                    service: System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
                    host: Environment.MachineName,
                    configuration: new DatadogConfiguration { Url = "https://http-intake.logs.us5.datadoghq.com" },
                    tags: new string[] { $"env:{environment.ToLowerInvariant()}" },
                    batchPeriod: TimeSpan.FromSeconds(5),
                    batchSizeLimit: 50,
                    logLevel: LogEventLevel.Information
                 );
            }

            if (configureLogger != null)
                configureLogger(hostingContext, loggerConfiguration);
        });

        return builder;
    }
}
