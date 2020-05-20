using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Xml;

namespace WatershipHill
{
    public static class HillManager
    {
        #region VALUES
        private const int WAIT_TIME_IN_MILISECONDS = 3000;

        #region DATA_MEMBERS
        private static bool _toggle;
        #endregion
        #endregion

        #region METHODS
        #region AUTOMATION
        /// <summary>
        /// Automates the given hill
        /// </summary>
        /// <param name="hill"> A hill </param>
        private static void automateHill(Hill hill)
        {
            HillManager._toggle = true;

            Thread.Sleep(HillManager.WAIT_TIME_IN_MILISECONDS);

            while (true)
            { 
                HillManager.runAutomation(hill);
                HillManager.checkToggle();
            }
        }

        /// <summary>
        /// Toggles the state of the automation
        /// </summary>
        private static void toggleAutomation()
        {
            HillManager._toggle = !HillManager._toggle;
        }

        /// <summary>
        /// Checks whether the automation was toggled
        /// </summary>
        private static void checkToggle()
        {
            if (KeybaordIO.isEnterPressed())
            {
                HillManager.toggleAutomation();
            }
        }

        /// <summary>
        /// Checks whether the automation is active
        /// </summary>
        /// <returns> If the automation is active </returns>
        private static bool isAutomationActivate()
        {
             return ((HillManager._toggle) && (!KeybaordIO.isKeyPressed()));
        }

        /// <summary>
        /// Runs the given hill's automation
        /// </summary>
        /// <param name="hill"> A hill </param>
        private static void runAutomation(Hill hill)
        {
            while (HillManager.isAutomationActivate())
            {
                hill.cycle();
                Thread.Sleep(HillManager.WAIT_TIME_IN_MILISECONDS);
            }
        }
        #endregion

        #region HILL_GENERATION 
        /// <summary>
        /// Adds a rabbit to the given hill
        /// </summary>
        /// <param name="hill"> A hill </param>
        /// <param name="rabbit"> A rabbit </param>
        private static void addRabbit(Hill hill, Rabbit rabbit)
        {
            hill.rabbits().Add(rabbit);
        }

        private static void generateHill(string fileName, Hill hill)
        {
            XmlNodeList nodes = HillManager.fileNodes(fileName);

            foreach (XmlNode node in nodes)
            {
                if (HillManager.hasAttributes(node))
                {
                    HillManager.createRabbit(hill, node);
                }
            }
        }

        private static XmlNodeList fileNodes(string fileName)
        {
            XmlDocument file = XMLFileIO.loadXMLFile(fileName);

            return XMLFileIO.childNodes(file);
        }

        private static bool hasAttributes(XmlNode node)
        {
            bool hasAge;
            bool hasName;
            bool hasSex;
            bool hasColor;

            hasAge = XMLFileIO.hasAge(node);
            hasName = XMLFileIO.hasName(node);
            hasSex = XMLFileIO.hasSex(node);
            hasColor = XMLFileIO.hasColor(node);

            return (hasAge && hasName && hasSex && hasColor);
        }

        private static void createRabbit(Hill hill, XmlNode node)
        {
            int age = XMLFileIO.readAge(node);
            string name = XMLFileIO.readName(node);
            Sex sex = XMLFileIO.readSex(node);
            Color color = XMLFileIO.readColor(node);

            addRabbit(hill, new Rabbit(age, sex, color, name));
        }

        public static void runHill()
        {
            const string FILE_NAME ="InitialState.xml";
            const int NUM_OF_FEMALES = 3;
            const int NUM_OF_MALES = 2;

            Hill hill;

            if (XMLFileIO.doesFileExist(FILE_NAME))
            {
                hill = new Hill();
                generateHill(FILE_NAME, hill);
            }
            else
            {
                hill = new Hill(NUM_OF_MALES, NUM_OF_FEMALES);
            }

            automateHill(hill);
        }
        #endregion
        #endregion
    }
}
