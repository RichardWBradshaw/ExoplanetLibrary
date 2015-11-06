using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExoplanetLibrary;

namespace ExoplanetLibraryUnitTest
    {
    [TestClass]
    public class UnitTest
        {
        [TestMethod]
        public void TestMethodReadCSVs ()
            {
            ReadCSV.Read (Constant.UnitTestFolder + "Version1.csv");
            ReadCSV.Read (Constant.UnitTestFolder + "Version2.csv");
            }

        [TestMethod]
        public void TestMethodVersion1 ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (Constant.UnitTestFolder + "Version1.csv");
            ReadXML.Read (Constant.UnitTestFolder + "Version1.xml", ref exoplanetArray, true);
            WriteCSV.Write (Constant.UnitTestFolder + "Version1TestResults.csv", exoplanetArray, Constant.Version1);

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (Constant.UnitTestFolder + "Version1TestResults.csv");
            ReadXML.Read (Constant.UnitTestFolder + "Version1TestResults.xml", ref exoplanetArray2, true);

            Assert.IsNotNull (exoplanetArray);
            Assert.IsNotNull (exoplanetArray2);
            Assert.AreEqual (exoplanetArray.Count, exoplanetArray2.Count);
            Assert.AreEqual (Helper.AreEqual (exoplanetArray, exoplanetArray2), true);
            }

        [TestMethod]
        public void TestMethodVersion2 ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (Constant.UnitTestFolder + "Version2.csv");
            ReadXML.Read (Constant.UnitTestFolder + "Version2.xml", ref exoplanetArray, true);
            WriteCSV.Write (Constant.UnitTestFolder + "Version2TestResults.csv", exoplanetArray, Constant.Version2);

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (Constant.UnitTestFolder + "Version2TestResults.csv");
            ReadXML.Read (Constant.UnitTestFolder + "Version2TestResults.xml", ref exoplanetArray2, true);

            Assert.IsNotNull (exoplanetArray);
            Assert.IsNotNull (exoplanetArray2);
            Assert.AreEqual (exoplanetArray.Count, exoplanetArray2.Count);
            Assert.AreEqual (Helper.AreEqual (exoplanetArray, exoplanetArray2), true);
            }

        [TestMethod]
        public void TestMethodTypeCounters ()
            {
            ArrayList exoplanetArray = null;

            if (System.IO.File.Exists (Constant.UnitTestFolder + "Version2.xml"))
                ReadXML.Read (Constant.UnitTestFolder + "Version2.xml", ref exoplanetArray, true);
            else
                {
                ReadCSV.Read (Constant.UnitTestFolder + "Version2.csv");
                ReadXML.Read (Constant.UnitTestFolder + "Version2.xml", ref exoplanetArray, true);
                }

            Assert.IsNotNull (exoplanetArray);

            Assert.AreEqual (1927, Helper.NumberOfExoplanets (exoplanetArray));
            Assert.AreEqual (0, Helper.NumberOfTypeOStars (exoplanetArray));
            Assert.AreEqual (11, Helper.NumberOfTypeBStars (exoplanetArray));
            Assert.AreEqual (13, Helper.NumberOfTypeAStars (exoplanetArray));
            Assert.AreEqual (128, Helper.NumberOfTypeFStars (exoplanetArray));
            Assert.AreEqual (384, Helper.NumberOfTypeGStars (exoplanetArray));
            Assert.AreEqual (267, Helper.NumberOfTypeKStars (exoplanetArray));
            Assert.AreEqual (88, Helper.NumberOfTypeMStars (exoplanetArray));
            Assert.AreEqual (717, Helper.NumberOfMultiPlanetStars (exoplanetArray));
            }

        [TestMethod]
        public void TestMethodReadVersion1NValid ()
            {
            ArrayList exoplanetArray = null;

            if (System.IO.File.Exists (Constant.UnitTestFolder + "Version1.xml"))
                ReadXML.Read (Constant.UnitTestFolder + "Version1.xml", ref exoplanetArray);
            else
                {
                ReadCSV.Read (Constant.UnitTestFolder + "Version1.csv");
                ReadXML.Read (Constant.UnitTestFolder + "Version1.xml", ref exoplanetArray);
                }

            Assert.IsNotNull (exoplanetArray);
            }

        [TestMethod]
        public void TestMethodReadVersion2NValid ()
            {
            ArrayList exoplanetArray = null;

            if (System.IO.File.Exists (Constant.UnitTestFolder + "Version2.xml"))
                ReadXML.Read (Constant.UnitTestFolder + "Version2.xml", ref exoplanetArray);
            else
                {
                ReadCSV.Read (Constant.UnitTestFolder + "Version2.csv");
                ReadXML.Read (Constant.UnitTestFolder + "Version2.xml", ref exoplanetArray);
                }

            Assert.IsNotNull (exoplanetArray);
            }

        [TestMethod]
        public void TestMethodReadEUCatalogAsCSVNValid ()
            {
            ArrayList exoplanetArray = null;

            if (System.IO.File.Exists (Constant.UnitTestFolder + "exoplanet.eu_catalog.xml"))
                ReadXML.Read (Constant.UnitTestFolder + "Version1.xml", ref exoplanetArray);
            else
                {
                ReadCSV.Read (Constant.UnitTestFolder + "exoplanet.eu_catalog.csv");
                ReadXML.Read (Constant.UnitTestFolder + "exoplanet.eu_catalog.xml", ref exoplanetArray);
                }

            Assert.IsNotNull (exoplanetArray);
            }

        [TestMethod]
        public void TestMethodReadEUCatalogAsVOTNValid ()
            {
            ArrayList exoplanetArray = null;

            if (System.IO.File.Exists (Constant.UnitTestFolder + "exoplanet_catalog.xml"))
                ReadXML.Read (Constant.UnitTestFolder + "exoplanet_catalog.xml", ref exoplanetArray);
            else
                {
                ReadVOT.Read (Constant.UnitTestFolder + "exoplanet_catalog.vot");
                ReadXML.Read (Constant.UnitTestFolder + "exoplanet_catalog.eu_catalog.xml", ref exoplanetArray);
                }

            Assert.IsNotNull (exoplanetArray);
            }
        }
    }
