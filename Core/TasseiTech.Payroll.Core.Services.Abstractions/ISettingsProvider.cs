using Microsoft.Extensions.Configuration;

namespace TasseiTech.Payroll.Core.Services.Abstractions;

public interface ISettingsProvider
{
    string this[string settingName] => GetValue<string>(settingName);

    string GetEnvironment();

    string GetConnectionString<T>();

    string GetConnectionString(string connectionStringName);

    T GetValue<T>(string settingName, T defaultValue = default(T));

    IEnumerable<T> GetValueList<T>(string settingName);

    T GetSecret<T>(string settingName, T defaultValue = default(T));

    IEnumerable<T> GetSecretList<T>(string settingName);

    void Bind(string key, object instance);

    IConfigurationSection GetSection(string key);
}
