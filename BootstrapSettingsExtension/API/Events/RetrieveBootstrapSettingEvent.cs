using TinYard.Extensions.EventSystem.Impl.Base;

namespace TinYard.BootstrapSettings.API.Events
{
    public class RetrieveBootstrapSettingEvent : Event
    {
        public enum Type
        {
            Get,
            Got
        }

        public readonly string SettingName;

        public readonly System.Type SettingValueType;
        public readonly object SettingValue;

        public RetrieveBootstrapSettingEvent(Type type, string settingName) : base(type)
        {
            SettingName = settingName;
        }

        public RetrieveBootstrapSettingEvent(Type type, string settingName, System.Type settingType) : base(type)
        {
            SettingName = settingName;
            SettingValueType = settingType;
        }

        public RetrieveBootstrapSettingEvent(Type type, string settingName, System.Type settingType, object settingValue) : base(type)
        {
            SettingName = settingName;

            SettingValueType = settingType;
            SettingValue = settingValue;
        }
    }
}
