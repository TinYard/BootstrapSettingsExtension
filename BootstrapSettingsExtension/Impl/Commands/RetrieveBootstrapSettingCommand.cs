using TinYard.BootstrapSettings.API.Events;
using TinYard.BootstrapSettings.API.Interfaces;
using TinYard.Extensions.CommandSystem.API.Interfaces;
using TinYard.Extensions.EventSystem.API.Interfaces;
using TinYard.Framework.Impl.Attributes;

namespace TinYard.BootstrapSettings.Impl.Commands
{
    public class RetrieveBootstrapSettingCommand : ICommand
    {
        [Inject]
        public RetrieveBootstrapSettingEvent evt;

        [Inject]
        public IBootstrapSettingsModel bootstrapSettingsModel;

        [Inject]
        public IEventDispatcher dispatcher;

        public void Execute()
        {
            string settingName = evt.SettingName;

            if (!bootstrapSettingsModel.HasSetting(settingName))
                return;

            if (evt.SettingValueType != null)
            {
                object settingVal = bootstrapSettingsModel.GetSetting(settingName, evt.SettingValueType);
                dispatcher.Dispatch(new RetrieveBootstrapSettingEvent(RetrieveBootstrapSettingEvent.Type.Got, settingName, evt.SettingValueType, settingVal));
            }
            else
            {
                string settingVal = bootstrapSettingsModel.GetSetting(settingName);
                dispatcher.Dispatch(new RetrieveBootstrapSettingEvent(RetrieveBootstrapSettingEvent.Type.Got, settingName, typeof(string), settingVal));
            }

        }
    }
}
