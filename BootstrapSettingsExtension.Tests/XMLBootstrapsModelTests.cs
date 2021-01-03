using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TinYard.BootstrapSettings.API.Interfaces;
using TinYard.BootstrapSettings.Impl.Models;

namespace TinYard.BootstrapSettings.Tests
{
    [TestClass]
    public class XMLBootstrapsModelTests
    {
        private IBootstrapSettingsModel _bootstrapSettingsModel;

        [TestInitialize]
        public void Setup()
        {
            _bootstrapSettingsModel = new XMLBootstrapSettingsModel(Path.Combine(Directory.GetCurrentDirectory(), "../../../TestAssets/example_bootstrap_settings.xml"));
        }

        [TestCleanup]
        public void Teardown()
        {

        }

        [TestMethod]
        public void Model_Can_Find_Settings()
        {
            Assert.IsTrue(_bootstrapSettingsModel.HasSetting("environment"));
        }
    }
}
