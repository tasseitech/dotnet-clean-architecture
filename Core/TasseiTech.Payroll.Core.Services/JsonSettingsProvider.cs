using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using TasseiTech.Sample.Core.Domain;

namespace TasseiTech.Sample.Core.Services;

public class JsonSettingsProvider : ISettingsProvider
{
    public IConfiguration Configuration { get; private set; }

    public JsonSettingsProvider()
    {
        var env = GetEnvironment();
        var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var stringsFileName = $"appsettings.json";
        var envStringsFileName = $"appsettings.{env}.json";

        var configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(appPath);

        if (File.Exists(Path.Combine(appPath, stringsFileName)))
        {
            configurationBuilder
                .AddJsonFile(stringsFileName, optional: false, reloadOnChange: true)
                .AddJsonFile(Path.Combine(appPath, stringsFileName), optional: true, reloadOnChange: true);
        }

        if (File.Exists(Path.Combine(appPath, envStringsFileName)))
        {
            configurationBuilder
                .AddJsonFile(envStringsFileName, optional: false, reloadOnChange: true)
                .AddJsonFile(Path.Combine(appPath, envStringsFileName), optional: true, reloadOnChange: true);
        }

        Configuration = configurationBuilder.Build();
    }

    public string GetEnvironment()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
    }

    public string GetConnectionString(string connectionStringName)
    {
        return Configuration.GetConnectionString(connectionStringName) ?? Environment.GetEnvironmentVariable($"ConnectionStrings_{connectionStringName}");
    }

    public T GetValue<T>(string settingName, T defaultValue = default)
    {
        return Configuration.GetValue(settingName, defaultValue);
    }

    public void Bind(string key, object instance)
    {
        Configuration.Bind(key, instance);
    }

}
