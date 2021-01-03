using System.Xml;

namespace TinYard.BootstrapSettings.Impl.Services
{
    public class XMLFileReaderService
    {
        public bool Initialized { get; }

        private XmlDocument _xmlDocument;

        public XMLFileReaderService(string filepath)
        {
            _xmlDocument = new XmlDocument();
            _xmlDocument.Load(filepath);

            Initialized = true;
        }

        public bool HasNodeValue(string nodeName)
        {
            string val = GetNodeValue(nodeName);
            return val != null;
        }

        public string GetNodeValue(string nodeName)
        {
            return _xmlDocument?.DocumentElement?.SelectSingleNode(nodeName).InnerText;
        }
    }
}
