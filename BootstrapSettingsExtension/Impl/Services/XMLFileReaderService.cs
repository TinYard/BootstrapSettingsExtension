using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace TinYard.BootstrapSettings.Impl.Services
{
    public class XMLFileReaderService
    {
        public bool Initialized { get; }

        private XDocument _xmlDocument;

        public XMLFileReaderService(string filepath)
        {
            _xmlDocument = XDocument.Load(filepath);

            Initialized = true;
        }

        public bool HasNode(string nodeName)
        {
            bool exists = _xmlDocument.Descendants(nodeName).Any();
            return exists;
        }

        public string GetNodeStringValue(string nodeName)
        {
            var elements = _xmlDocument.Descendants(nodeName);
            var first = elements.FirstOrDefault();
            return first.Value;
        }

        public T GetNodeTValue<T>(string nodeName)
        {
            var nodeToDeserialize = _xmlDocument.Descendants(nodeName).FirstOrDefault();
            var serializer = new XmlSerializer(typeof(T));

            try
            {
                return (T)serializer.Deserialize(nodeToDeserialize.CreateReader());
            }
            catch(InvalidOperationException e)
            {
                return (T)Convert.ChangeType(nodeToDeserialize.Value, typeof(T));
            }
        }
    }
}
