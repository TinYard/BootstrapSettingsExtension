using System;

namespace TinYard.BootstrapSettings.API.Interfaces
{
    public interface IBootstrapSettingsModel
    {
        bool HasSetting(string settingName);

        string GetSetting(string settingName);

        T GetSetting<T>(string settingName);
        object GetSetting(string settingName, Type settingValueType);
        bool TryGetSetting<T>(string settingName, out T settingValue);
    }
}
