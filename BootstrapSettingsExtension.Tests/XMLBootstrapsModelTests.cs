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
            //TODO : Tidy this hard coded path up.. Maybe generate a file and delete it in teardown?
            _bootstrapSettingsModel = new XMLBootstrapSettingsModel(Path.Combine(Directory.GetCurrentDirectory(), "../../../TestAssets/example_bootstrap_settings.xml"));
        }

        [TestCleanup]
        public void Teardown()
        {

        }

        [TestMethod]
        public void Model_Can_Find_Settings()
        {
            Assert.IsTrue(_bootstrapSettingsModel.HasSetting("Environment"));
        }

        [TestMethod]
        public void Model_Can_Get_Setting()
        {
            string expected = "true";
            string value = _bootstrapSettingsModel.GetSetting("Valid");

            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Model_Can_Get_Generic_Setting()
        {
            TestClasses.Environment expected = new TestClasses.Environment
            {
                Name="Production",
                OS="Windows",
                Deployed=true
            };

            TestClasses.Environment value = _bootstrapSettingsModel.GetSetting<TestClasses.Environment>("Environment");

            Assert.AreEqual(expected, value);
        }

        [TestMethod]
        public void Model_Throws_On_Invalid_Get_Generic_Setting()
        {
            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                _bootstrapSettingsModel.GetSetting<bool>("Environment");
            });
        }
    }
}
