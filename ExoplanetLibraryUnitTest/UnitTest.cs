using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExoplanetLibrary;

namespace ExoplanetLibraryUnitTest
    {
    [TestClass]
    public class UnitTest
        {
        static private string UnitTestDataFolder = "C:\\Various Code\\EXOPLANET_LIBRARY\\ExoplanetLibrary\\ProgramData\\Exoplanet Library\\_UnitTestData\\";

        [TestMethod]
        public void TestMethodVersion1 ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (UnitTestDataFolder + "Version1.csv");
            ReadXML.Read (UnitTestDataFolder + "Version1.xml", ref exoplanetArray, true);
            WriteCSV.Write (UnitTestDataFolder + "Version1TestResults.csv", exoplanetArray, "1.0");

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (UnitTestDataFolder + "Version1TestResults.csv");
            ReadXML.Read (UnitTestDataFolder + "Version1TestResults.xml", ref exoplanetArray2, true);

            Assert.IsNotNull (exoplanetArray);
            Assert.IsNotNull (exoplanetArray2);
            Assert.AreEqual (exoplanetArray.Count, exoplanetArray2.Count);
            Assert.AreEqual (Helper.AreEqual (exoplanetArray, exoplanetArray2), true);
            }

        [TestMethod]
        public void TestMethodVersion2 ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (UnitTestDataFolder + "Version2.csv");
            ReadXML.Read (UnitTestDataFolder + "Version2.xml", ref exoplanetArray, true);
            WriteCSV.Write (UnitTestDataFolder + "Version2TestResults.csv", exoplanetArray, "2.0");

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (UnitTestDataFolder + "Version2TestResults.csv");
            ReadXML.Read (UnitTestDataFolder + "Version2TestResults.xml", ref exoplanetArray2, true);

            Assert.IsNotNull (exoplanetArray);
            Assert.IsNotNull (exoplanetArray2);
            Assert.AreEqual (exoplanetArray.Count, exoplanetArray2.Count);
            Assert.AreEqual (Helper.AreEqual (exoplanetArray, exoplanetArray2), true);
            }

        [TestMethod]
        public void TestMethodVersion3 ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (UnitTestDataFolder + "Version3.csv");
            ReadXML.Read (UnitTestDataFolder + "Version3.xml", ref exoplanetArray, true);

            Assert.IsNotNull (exoplanetArray);
            }
        }
    }
