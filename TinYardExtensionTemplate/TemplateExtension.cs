using TinYard.API.Interfaces;

namespace TinYardExtensionTemplate
{
    public class TemplateExtension : IExtension
    {
        private IContext _context;

        public void Install(IContext context)
        {
            _context = context;

            //Install any dependencies here
        }
    }
}
