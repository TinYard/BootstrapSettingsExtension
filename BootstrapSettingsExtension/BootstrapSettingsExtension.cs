using TinYard.API.Interfaces;

namespace TinYard.BootstrapSettings
{
    public class BootstrapSettingsExtension : IExtension
    {
        private IContext _context;

        public void Install(IContext context)
        {
            _context = context;

            //Install any dependencies here
        }
    }
}
