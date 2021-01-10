using TinYard.BootstrapSettings.API.Events;
using TinYard.Extensions.MediatorMap.API.Base;

namespace TinYard.BootstrapSettings.API.Mediators
{
    public class BootstrapSettingRequestorMediator : Mediator
    {
        public override void Configure()
        {
            AddViewListener<RetrieveBootstrapSettingEvent>(RetrieveBootstrapSettingEvent.Type.Get, Dispatch);
        }
    }
}
