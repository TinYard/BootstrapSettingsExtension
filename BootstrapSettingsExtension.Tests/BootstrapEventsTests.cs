using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using TinYard.API.Interfaces;
using TinYard.BootstrapSettings.API.Events;
using TinYard.BootstrapSettings.Tests.TestClasses;
using TinYard.Extensions.Bundles;
using TinYard.Extensions.EventSystem.API.Interfaces;

namespace TinYard.BootstrapSettings.Tests
{
    [TestClass]
    public class BootstrapEventsTests
    {
        private IContext _context;
        private IEventDispatcher _dispatcher;

        [TestInitialize]
        public void Setup()
        {
            var testXmlPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "../../../TestAssets/example_bootstrap_settings.xml");

            _context = new Context();

            _context.Install(new MVCBundle());//Dependency
            _context.Install(new BootstrapSettingsExtension());
            _context.Configure(new XMLBootstrapSettingsConfig(testXmlPath));

            _context.Initialize();

            _dispatcher = _context.Mapper.GetMappingValue<IEventDispatcher>();
        }

        [TestCleanup]
        public void Teardown()
        {

        }

        [TestMethod]
        public void Retrieve_Bootstrap_Event_Retrieves_Setting()
        {
            bool isNull = true;
            _dispatcher.AddListener<RetrieveBootstrapSettingEvent>(RetrieveBootstrapSettingEvent.Type.Got, (evt) =>
            {
                isNull = evt.SettingValue == null;
            });

            _dispatcher.Dispatch(new RetrieveBootstrapSettingEvent(RetrieveBootstrapSettingEvent.Type.Get, 
                "Environment", typeof(Environment)));

            Assert.IsFalse(isNull);
        }
    }
}
