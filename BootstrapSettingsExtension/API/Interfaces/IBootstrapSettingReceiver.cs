using System;

namespace TinYard.BootstrapSettings.API.Interfaces
{
    public interface IBootstrapSettingReceiver
    {
        void ReceiveBootstrapSetting(string settingName, object settingValue, Type settingType);
    }
}
