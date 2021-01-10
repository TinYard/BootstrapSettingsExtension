using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinYard.API.Interfaces;

namespace TinYard.BootstrapSettings.Tests
{
    [TestClass]
    public class BootstrapSettingsExtensionTests
    {
        [TestMethod]
        public void BootstrapSettings_Is_Extension()
        {
            Assert.IsInstanceOfType(new BootstrapSettingsExtension(), typeof(IExtension));
        }

        [TestMethod]
        public void XMLBootstrapSettingsConfig_Is_Config()
        {
            Assert.IsInstanceOfType(new XMLBootstrapSettingsConfig(), typeof(IConfig));
        }
    }
}