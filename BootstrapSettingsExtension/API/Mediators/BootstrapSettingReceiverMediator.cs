using TinYard.BootstrapSettings.API.Events;
using TinYard.BootstrapSettings.API.Interfaces;
using TinYard.Extensions.MediatorMap.API.Base;
using TinYard.Framework.Impl.Attributes;

namespace TinYard.BootstrapSettings.API.Mediators
{
    public class BootstrapSettingReceiverMediator : Mediator
    {
        [Inject]
        public IBootstrapSettingReceiver view;

        public override void Configure()
        {
            AddContextListener<RetrieveBootstrapSettingEvent>(RetrieveBootstrapSettingEvent.Type.Got, OnGotSetting);
        }

        private void OnGotSetting(RetrieveBootstrapSettingEvent evt)
        {
            view.ReceiveBootstrapSetting(evt.SettingName, evt.SettingValue, evt.SettingValueType);
        }
    }
}
