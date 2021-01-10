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
        public void Model_Can_Get_Setting_As_Object()
        {
            //If this fails, Generic setting should be failing too
            TestClasses.Environment expected = _bootstrapSettingsModel.GetSetting<TestClasses.Environment>("Environment");

            object result = _bootstrapSettingsModel.GetSetting("Environment", typeof(TestClasses.Environment));

            var actual = result as TestClasses.Environment;

            Assert.AreEqual(expected, actual);
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

        [TestMethod]
        public void Model_Returns_False_On_Try_Get_Invalid()
        {
            int result = -1;

            bool actual = _bootstrapSettingsModel.TryGetSetting<int>("Environment", out result);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Model_Returns_True_On_Try_Get_Valid()
        {
            int result = -1;

            bool actual = _bootstrapSettingsModel.TryGetSetting<int>("Numerical", out result);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void Model_Returns_True_And_Correct_Value_With_Try_Get()
        {
            int expected = _bootstrapSettingsModel.GetSetting<int>("Numerical");

            //-1 means that even if expected fails to get the value, the test will still fail
            int actual = -1;

            bool success = _bootstrapSettingsModel.TryGetSetting<int>("Numerical", out actual);

            Assert.IsTrue(success);
            Assert.AreEqual(expected, actual);
        }
    }
}
