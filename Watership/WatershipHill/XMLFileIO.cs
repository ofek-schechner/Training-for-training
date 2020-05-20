using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace WatershipHill
{
    public static class XMLFileIO
    {
        #region METHODS 
        /// <summary>
        /// hecks whether the given file exists
        /// </summary>
        /// <param name="filePath"> The given file's path </param>
        /// <returns> If the file exists </returns>
        public static bool doesFileExist(string filePath)
        {
            return File.Exists(filePath);
        }

        /// <summary>
        /// Loads the given XML file
        /// </summary>
        /// <param name="fileName"> The name of the file </param>
        /// <returns>The file content </returns>
        public static XmlDocument loadXMLFile(string fileName)
        {
            XmlDocument file = new XmlDocument();
            file.Load(fileName);

            return file;
        }

        /// <summary>
        /// Gets all child nodes of an XML file
        /// </summary>
        /// <param name="file"> The file </param>
        /// <returns> Child nodes of an XML file </returns>
        public static XmlNodeList childNodes(XmlDocument file)
        {
            return file.DocumentElement.ChildNodes;
        }

        #region ATTRIBUTES
        #region READ_ATTRIBUTES
        /// <summary>
        /// Reads the age attribute from an XML node
        /// </summary>
        /// <param name="node"> The given node </param>
        /// <returns> The age attribute </returns>
        public static int readAge(XmlNode node)
        {
            return int.Parse(node.Attributes["Age"]?.InnerText);
        }

        /// <summary>
        /// Reads the name attribute from an XML node
        /// </summary>
        /// <param name="node"> The given node </param>
        /// <returns> The name attribute </returns>
        public static string readName(XmlNode node)
        {
            return node.Attributes["Name"]?.InnerText;
        }

        /// <summary>
        /// Reads the sex attribute from an XML node
        /// </summary>
        /// <param name="node"> The given node </param>
        /// <returns> The sex attribute </returns>
        public static Sex readSex(XmlNode node)
        {
            return (Sex)Enum.Parse(typeof(Sex), node.Attributes["Sex"]?.InnerText, true);
        }

        /// <summary>
        /// Reads the color attribute from an XML node
        /// </summary>
        /// <param name="node"> The given node </param>
        /// <returns> The color attribute </returns>
        public static Color readColor(XmlNode node)
        {
            return (Color)Enum.Parse(typeof(Color), node.Attributes["Color"]?.InnerText, true);
        }
        #endregion

        #region CHECK_ATTRIBUTES
        public static bool hasAge(XmlNode node)
        {
            return ((XmlElement) node).HasAttribute("Age");
        }

        public static bool hasName(XmlNode node)
        {
            return ((XmlElement)node).HasAttribute("Name");
        }

        public static bool hasSex(XmlNode node)
        {
            return ((XmlElement)node).HasAttribute("Sex");
        }

        public static bool hasColor(XmlNode node)
        {
            return ((XmlElement)node).HasAttribute("Color");
        }

        #endregion
        #endregion
        #endregion
    }
}
