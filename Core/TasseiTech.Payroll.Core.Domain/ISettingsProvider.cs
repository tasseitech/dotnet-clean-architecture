namespace TasseiTech.Sample.Core.Domain;

public interface ISettingsProvider
{
    string GetEnvironment();

    string GetConnectionString(string connectionStringName);

    T GetValue<T>(string settingName, T defaultValue = default);

    void Bind(string key, object instance);
}
