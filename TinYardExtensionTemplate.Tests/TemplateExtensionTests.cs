using Microsoft.VisualStudio.TestTools.UnitTesting;
using TinYard.API.Interfaces;

namespace TinYardExtensionTemplate.Tests
{
    [TestClass]
    public class TemplateExtensionTests
    {
        [TestMethod]
        public void TemplateExtension_Is_Extension()
        {
            Assert.IsInstanceOfType(new TemplateExtension(), typeof(IExtension));
        }
    }
}
