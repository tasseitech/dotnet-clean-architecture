using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TasseiTech.Payroll.Core.Services.Abstractions;

namespace TasseiTech.Payroll.Core.Services;

public class JsonSettingsProvider : ISettingsProvider
{
    public IConfiguration Configuration { get; private set; }

    public JsonSettingsProvider()
    {
        var env = GetEnvironment();
        var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var stringsFileName = $"appsettings.json";
        var envStringsFileName = $"appsettings.{env}.json";
        var connectionStringsFileName = $"connectionStrings.json";
        var envConnectionStringsFileName = $"connectionStrings.{env}.json";
        var secretsFileName = $"secrets.{env}.json";
        var dynamicAppSettingFileName = $"appsettings.{Assembly.GetEntryAssembly().GetName().Name.ToLower()}.k8s.json";

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

        if (File.Exists(Path.Combine(appPath, connectionStringsFileName)))
        {
            configurationBuilder
                .AddJsonFile(connectionStringsFileName, optional: false, reloadOnChange: true)
                .AddJsonFile(Path.Combine(appPath, connectionStringsFileName), optional: true, reloadOnChange: true);
        }

        if (File.Exists(Path.Combine(appPath, envConnectionStringsFileName)))
        {
            configurationBuilder
                .AddJsonFile(envConnectionStringsFileName, optional: false, reloadOnChange: true)
                .AddJsonFile(Path.Combine(appPath, envConnectionStringsFileName), optional: true, reloadOnChange: true);
        }

        // NOTE: Needed to apply dynamic configuration through this custom appsetting mapped to Kubernetes through Azure fileshare
        configurationBuilder
            .AddJsonFile(Path.Combine(appPath, "Config", dynamicAppSettingFileName), optional: true, reloadOnChange: true);

        // NOTE: Dynamic configuration to be accessed via AKS VM mount
        configurationBuilder
            .AddJsonFile(Path.Combine(@"Z:\\", dynamicAppSettingFileName), optional: true, reloadOnChange: true);

        // NOTE: Add Development Secrets
        if (File.Exists(Path.Combine(appPath, secretsFileName)))
        {
            configurationBuilder
                .AddJsonFile(secretsFileName, optional: false, reloadOnChange: true)
                .AddJsonFile(Path.Combine(appPath, secretsFileName), optional: true, reloadOnChange: true);
        }

        Configuration = configurationBuilder.Build();
    }

    public string GetEnvironment()
    {
        return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
    }

    public string GetConnectionString<T>()
    {
        return GetConnectionString(typeof(T).Name);
    }

    public string GetConnectionString(string connectionStringName)
    {
        return Configuration.GetConnectionString(connectionStringName) ?? Environment.GetEnvironmentVariable($"ConnectionStrings_{connectionStringName}");
    }

    public T GetValue<T>(string settingName, T defaultValue = default)
    {
        return Configuration.GetValue(settingName, defaultValue);
    }
    public T GetSecret<T>(string settingName, T defaultValue = default)
    {
        return Configuration.GetValue(settingName, defaultValue);
    }

    public IEnumerable<T> GetValueList<T>(string settingName)
    {
        return Configuration.GetSection(settingName).Get<IEnumerable<T>>();
    }
    public IEnumerable<T> GetSecretList<T>(string settingName)
    {
        return Configuration.GetSection(settingName).Get<IEnumerable<T>>();
    }

    public void Bind(string key, object instance)
    {
        Configuration.Bind(key, instance);
    }

    public IConfigurationSection GetSection(string key)
    {
        return Configuration.GetSection(key);
    }
}
