using TinYard.API.Interfaces;
using TinYard.Framework.Impl.Attributes;
using TinYard.BootstrapSettings.Impl.Models;
using TinYard.BootstrapSettings.API.Interfaces;
using System.IO;

namespace TinYard.BootstrapSettings
{
    public class XMLBootstrapSettingsConfig : IConfig
    {
        [Inject]
        public IContext context;

        private readonly string _bootstrapSettingsFilePath;

        public XMLBootstrapSettingsConfig()
        {
            _bootstrapSettingsFilePath = Directory.GetCurrentDirectory();
        }

        public XMLBootstrapSettingsConfig(string bootstrapSettingsFilePath)
        {
            _bootstrapSettingsFilePath = bootstrapSettingsFilePath;
        }

        public void Configure()
        {            
            //Map Models
            context.Mapper.Map<IBootstrapSettingsModel>()
                .ToValue(new XMLBootstrapSettingsModel(_bootstrapSettingsFilePath));
        }
    }
}
