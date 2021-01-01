using TinYard.API.Interfaces;
using TinYard.Framework.Impl.Attributes;
//using TinYard.Extensions.CommandSystem.API.Interfaces;
//using TinYard.Extensions.MediatorMap.API.Interfaces;

namespace TinYardExtensionTemplate
{
    public class TemplateConfig : IConfig
    {
        [Inject]
        public IContext context;

        public void Configure()
        {
            //Get Mediator and Command Mappers

            //var mediatorMapper = context.Mapper.GetMappingValue<IMediatorMapper>();
            //var commandMap = context.Mapper.GetMappingValue<ICommandMap>();

            //Map Mediators

            //Map Commands

            //Map Models

            //Map Services
        }
    }
}
