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
            exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "Version1.xml", true);
            WriteCSV.Write (Constant.UnitTestFolder + "Version1TestResults.csv", exoplanetArray, Constant.Version1);

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (Constant.UnitTestFolder + "Version1TestResults.csv");
            exoplanetArray2 = ReadXML.Read (Constant.UnitTestFolder + "Version1TestResults.xml", true);

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
            exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "Version2.xml", true);
            WriteCSV.Write (Constant.UnitTestFolder + "Version2TestResults.csv", exoplanetArray, Constant.Version2);

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (Constant.UnitTestFolder + "Version2TestResults.csv");
            exoplanetArray2 = ReadXML.Read (Constant.UnitTestFolder + "Version2TestResults.xml", true);

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
                exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "Version2.xml", true);
            else
                {
                ReadCSV.Read (Constant.UnitTestFolder + "Version2.csv");
                exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "Version2.xml", true);
                }

            Assert.IsNotNull (exoplanetArray);

            Assert.AreEqual (Helper.NumberOfExoplanets (exoplanetArray), 1927);
            Assert.AreEqual (Helper.NumberOfTypeOStars (exoplanetArray), 0);
            Assert.AreEqual (Helper.NumberOfTypeBStars (exoplanetArray), 11);
            Assert.AreEqual (Helper.NumberOfTypeAStars (exoplanetArray), 13);
            Assert.AreEqual (Helper.NumberOfTypeFStars (exoplanetArray), 128);
            Assert.AreEqual (Helper.NumberOfTypeGStars (exoplanetArray), 384);
            Assert.AreEqual (Helper.NumberOfTypeKStars (exoplanetArray), 267);
            Assert.AreEqual (Helper.NumberOfTypeMStars (exoplanetArray), 88);
            Assert.AreEqual (Helper.NumberOfMultiPlanetStars (exoplanetArray), 717);
            }

        [TestMethod]
        public void TestMethodReadVersion1NValid ()
            {
            ArrayList exoplanetArray = null;

            if (System.IO.File.Exists (Constant.UnitTestFolder + "Version1.xml"))
                exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "Version1.xml" );
            else
                {
                ReadCSV.Read (Constant.UnitTestFolder + "Version1.csv");
                exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "Version1.xml" );
                }

            Assert.IsNotNull (exoplanetArray);
            }

        [TestMethod]
        public void TestMethodReadVersion2NValid ()
            {
            ArrayList exoplanetArray = null;

            if (System.IO.File.Exists (Constant.UnitTestFolder + "Version2.xml"))
                exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "Version2.xml");
            else
                {
                ReadCSV.Read (Constant.UnitTestFolder + "Version2.csv");
                exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "Version2.xml" );
                }

            Assert.IsNotNull (exoplanetArray);
            }

        [TestMethod]
        public void TestMethodReadEUCatalogAsCSVNValid ()
            {
            ArrayList exoplanetArray = null;

            if (System.IO.File.Exists (Constant.UnitTestFolder + "exoplanet.eu_catalog.xml"))
                exoplanetArray =  ReadXML.Read (Constant.UnitTestFolder + "Version1.xml");
            else
                {
                ReadCSV.Read (Constant.UnitTestFolder + "exoplanet.eu_catalog.csv");
                exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "exoplanet.eu_catalog.xml");
                }

            Assert.IsNotNull (exoplanetArray);
            }

        [TestMethod]
        public void TestMethodReadEUCatalogAsVOTNValid ()
            {
            ArrayList exoplanetArray = null;

            if (System.IO.File.Exists (Constant.UnitTestFolder + "exoplanet_catalog.xml"))
                exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "exoplanet_catalog.xml");
            else
                {
                ReadVOT.Read (Constant.UnitTestFolder + "exoplanet_catalog.vot");
                exoplanetArray = ReadXML.Read (Constant.UnitTestFolder + "exoplanet_catalog.eu_catalog.xml");
                }

            Assert.IsNotNull (exoplanetArray);
            }
        }
    }
