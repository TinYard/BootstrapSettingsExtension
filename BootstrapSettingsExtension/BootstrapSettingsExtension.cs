using TinYard.API.Interfaces;
using TinYard.BootstrapSettings.API.Events;
using TinYard.BootstrapSettings.API.Interfaces;
using TinYard.BootstrapSettings.API.Mediators;
using TinYard.BootstrapSettings.Impl.Commands;
using TinYard.BootstrapSettings.Impl.Guards;
using TinYard.Extensions.CommandSystem.API.Interfaces;
using TinYard.Extensions.MediatorMap.API.Interfaces;

namespace TinYard.BootstrapSettings
{
    public class BootstrapSettingsExtension : IExtension
    {
        private IContext _context;

        public void Install(IContext context)
        {
            _context = context;

            //Install any dependencies here
            var mediatorMapper = _context.Mapper.GetMappingValue<IMediatorMapper>();
            var commandMap = _context.Mapper.GetMappingValue<ICommandMap>();

            //Map Mediators
            mediatorMapper.Map<IBootstrapSettingReceiver>().ToMediator<BootstrapSettingReceiverMediator>();
            mediatorMapper.Map<IBootstrapSettingRequestor>().ToMediator<BootstrapSettingRequestorMediator>();

            //Map Commands
            commandMap
                .Map<RetrieveBootstrapSettingEvent>(RetrieveBootstrapSettingEvent.Type.Get)
                .ToCommand<RetrieveBootstrapSettingCommand>().WithGuard<BootstrapSettingRequestGuard>();

        }
    }
}
