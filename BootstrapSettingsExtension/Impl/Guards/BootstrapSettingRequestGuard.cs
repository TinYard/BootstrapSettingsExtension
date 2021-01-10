using TinYard.BootstrapSettings.API.Events;
using TinYard.Framework.API.Base;
using TinYard.Framework.Impl.Attributes;

namespace TinYard.BootstrapSettings.Impl.Guards
{
    public class BootstrapSettingRequestGuard : Guard
    {
        [Inject]
        public RetrieveBootstrapSettingEvent evt;

        public override bool Satisfies()
        {
            if (string.IsNullOrWhiteSpace(evt.SettingName))
                return false;

            return true;
        }
    }
}
