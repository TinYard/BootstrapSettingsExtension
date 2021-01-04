using System;
using TinYard.BootstrapSettings.API.Interfaces;
using TinYard.BootstrapSettings.Impl.Services;

namespace TinYard.BootstrapSettings.Impl.Models
{
    public class XMLBootstrapSettingsModel : IBootstrapSettingsModel
    {
        private readonly string _bootstrapSettingsFilePath;

        private XMLFileReaderService _xmlFileReader;

        public XMLBootstrapSettingsModel(string bootstrapSettingsFilePath)
        {
            _bootstrapSettingsFilePath = bootstrapSettingsFilePath;

            _xmlFileReader = new XMLFileReaderService(_bootstrapSettingsFilePath);
        }

        public bool HasSetting(string settingName)
        {
            return _xmlFileReader.HasNode(settingName);
        }

        public string GetSetting(string settingName)
        {
            return _xmlFileReader.GetNodeStringValue(settingName);
        }

        public T GetSetting<T>(string settingName)
        {
            return _xmlFileReader.GetNodeTValue<T>(settingName);
        }

        public bool TryGetSetting<T>(string settingName, out T settingValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
