using TinYard.API.Interfaces;
using TinYard.Framework.Impl.Attributes;
using TinYard.Extensions.CommandSystem.API.Interfaces;
using TinYard.Extensions.MediatorMap.API.Interfaces;
using TinYard.BootstrapSettings.Impl.Models;
using TinYard.BootstrapSettings.API.Interfaces;
using System.IO;

namespace TinYard.BootstrapSettings
{
    public class BootstrapSettingsConfig : IConfig
    {
        [Inject]
        public IContext context;

        private readonly string _bootstrapSettingsFilePath;

        public BootstrapSettingsConfig()
        {
            _bootstrapSettingsFilePath = Directory.GetCurrentDirectory();
        }

        public BootstrapSettingsConfig(string bootstrapSettingsFilePath)
        {
            _bootstrapSettingsFilePath = bootstrapSettingsFilePath;
        }

        public void Configure()
        {
            //Get Mediator and Command Mappers

            var mediatorMapper = context.Mapper.GetMappingValue<IMediatorMapper>();
            var commandMap = context.Mapper.GetMappingValue<ICommandMap>();

            //Map Mediators

            //Map Commands

            //Map Models
            context.Mapper.Map<IBootstrapSettingsModel>().ToValue(new XMLBootstrapSettingsModel(_bootstrapSettingsFilePath));

            //Map Services
        }
    }
}
