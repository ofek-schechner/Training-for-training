using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WatershipHill
{
    public static class XMLFileIO
    {
        // Loads and returns the given XML file
        public static XmlDocument loadXMLFile(string fileName)
        {
            XmlDocument file = new XmlDocument();
            file.Load(fileName);

            return file;
        }

        // Returns all child nodes of an XML file
        public static XmlNodeList childNodes(XmlDocument file)
        {
            return file.DocumentElement.ChildNodes;
        }

        // Reads the age attribute from an XML node
        public static int readAge(XmlNode node)
        {
            return int.Parse(node.Attributes["Age"]?.InnerText);
        }

        // Reads the name attribute from an XML node
        public static string readName(XmlNode node)
        {
            return node.Attributes["Name"]?.InnerText;
        }

        // Reads the sex attribute from an XML node
        public static Sex readSex(XmlNode node)
        {
            return (Sex)Enum.Parse(typeof(Sex), node.Attributes["Sex"]?.InnerText, true);
        }

        // Reads the color attribute from an XML node
        public static Color readColor(XmlNode node)
        {
            return (Color)Enum.Parse(typeof(Color), node.Attributes["Color"]?.InnerText, true);
        }
    }
}
