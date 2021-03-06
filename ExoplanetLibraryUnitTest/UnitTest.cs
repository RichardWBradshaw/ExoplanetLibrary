﻿using System.Collections;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExoplanetLibrary;
using System.IO;

namespace ExoplanetLibraryUnitTest
    {
    [TestClass]
    public class UnitTest
        {
        [TestMethod]
        public void TestMethodReadCSVs ()
            {
            ReadCSV.Read (Constant.UnitTestCSVFolder + "Version1.csv");
            ReadCSV.Read (Constant.UnitTestCSVFolder + "Version2.csv");
            ReadCSV.Read (Constant.UnitTestCSVFolder + "Version3.csv");
            }

        [TestMethod]
        [Ignore]
        public void TestMethodVersion1 ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (Constant.UnitTestCSVFolder + "Version1.csv");
            exoplanetArray = ReadXML.Read (Constant.UnitTestCSVFolder + "Version1.xml", true);
            WriteCSV.Write (Constant.UnitTestCSVFolder + "Version1TestResults.csv", exoplanetArray, Constant.Version1);

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (Constant.UnitTestCSVFolder + "Version1TestResults.csv");
            exoplanetArray2 = ReadXML.Read (Constant.UnitTestCSVFolder + "Version1TestResults.xml", true);

            Assert.IsNotNull (exoplanetArray);
            Assert.IsNotNull (exoplanetArray2);
            Assert.AreEqual (exoplanetArray.Count, exoplanetArray2.Count);
            Assert.AreEqual (Exoplanets.AreEqual (exoplanetArray, exoplanetArray2), true);
            }

        [TestMethod]
        [Ignore]
        public void TestMethodVersion2 ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (Constant.UnitTestCSVFolder + "Version2.csv");
            exoplanetArray = ReadXML.Read (Constant.UnitTestCSVFolder + "Version2.xml", true);
            WriteCSV.Write (Constant.UnitTestCSVFolder + "Version2TestResults.csv", exoplanetArray, Constant.Version2);

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (Constant.UnitTestCSVFolder + "Version2TestResults.csv");
            exoplanetArray2 = ReadXML.Read (Constant.UnitTestCSVFolder + "Version2TestResults.xml", true);

            Assert.IsNotNull (exoplanetArray);
            Assert.IsNotNull (exoplanetArray2);
            Assert.AreEqual (exoplanetArray.Count, exoplanetArray2.Count);
            Assert.AreEqual (Exoplanets.AreEqual (exoplanetArray, exoplanetArray2), true);
            }

        [TestMethod]
        [Ignore]
        public void TestMethodVersion3 ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (Constant.UnitTestCSVFolder + "Version3.csv");
            exoplanetArray = ReadXML.Read (Constant.UnitTestCSVFolder + "Version3.xml", true);
            WriteCSV.Write (Constant.UnitTestCSVFolder + "Version3TestResults.csv", exoplanetArray, Constant.Version3);

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (Constant.UnitTestCSVFolder + "Version3TestResults.csv");
            exoplanetArray2 = ReadXML.Read (Constant.UnitTestCSVFolder + "Version3TestResults.xml", true);

            Assert.IsNotNull (exoplanetArray);
            Assert.IsNotNull (exoplanetArray2);
            Assert.AreEqual (exoplanetArray.Count, exoplanetArray2.Count);
            Assert.AreEqual (Exoplanets.AreEqual (exoplanetArray, exoplanetArray2), true);
            }

        [TestMethod]
        public void TestMethodReadDATs ()
            {
            ReadCSV.Read (Constant.UnitTestDATFolder + "Version1.dat");
            ReadCSV.Read (Constant.UnitTestDATFolder + "Version2.dat");
            ReadCSV.Read (Constant.UnitTestDATFolder + "Version3.dat");
            }

        [TestMethod]
        [Ignore]
        public void TestMethodVersion1Dat ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (Constant.UnitTestDATFolder + "Version1.dat");
            exoplanetArray = ReadXML.Read (Constant.UnitTestDATFolder + "Version1.xml", true);
            WriteCSV.Write (Constant.UnitTestDATFolder + "Version1TestResults.dat", exoplanetArray, Constant.Version2);

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (Constant.UnitTestDATFolder + "Version1TestResults.dat");
            exoplanetArray2 = ReadXML.Read (Constant.UnitTestDATFolder + "Version1TestResults.xml", true);

            Assert.IsNotNull (exoplanetArray);
            Assert.IsNotNull (exoplanetArray2);
            Assert.AreEqual (exoplanetArray.Count, exoplanetArray2.Count);
            Assert.AreEqual (Exoplanets.AreEqual (exoplanetArray, exoplanetArray2), true);
            }

        [TestMethod]
        [Ignore]
        public void TestMethodVersion2Dat ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (Constant.UnitTestDATFolder + "Version2.dat");
            exoplanetArray = ReadXML.Read (Constant.UnitTestDATFolder + "Version2.xml", true);
            WriteCSV.Write (Constant.UnitTestDATFolder + "Version2TestResults.dat", exoplanetArray, Constant.Version2);

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (Constant.UnitTestDATFolder + "Version2TestResults.dat");
            exoplanetArray2 = ReadXML.Read (Constant.UnitTestDATFolder + "Version2TestResults.xml", true);

            Assert.IsNotNull (exoplanetArray);
            Assert.IsNotNull (exoplanetArray2);
            Assert.AreEqual (exoplanetArray.Count, exoplanetArray2.Count);
            Assert.AreEqual (Exoplanets.AreEqual (exoplanetArray, exoplanetArray2), true);
            }

        [TestMethod]
        [Ignore]
        public void TestMethodVersion3Dat ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (Constant.UnitTestDATFolder + "Version3.dat");
            exoplanetArray = ReadXML.Read (Constant.UnitTestDATFolder + "Version3.xml", true);
            WriteCSV.Write (Constant.UnitTestDATFolder + "Version3TestResults.dat", exoplanetArray, Constant.Version3);

            ArrayList exoplanetArray2 = null;

            ReadCSV.Read (Constant.UnitTestDATFolder + "Version3TestResults.dat");
            exoplanetArray2 = ReadXML.Read (Constant.UnitTestDATFolder + "Version3TestResults.xml", true);

            Assert.IsNotNull (exoplanetArray);
            Assert.IsNotNull (exoplanetArray2);
            Assert.AreEqual (exoplanetArray.Count, exoplanetArray2.Count);
            Assert.AreEqual (Exoplanets.AreEqual (exoplanetArray, exoplanetArray2), true);
            }

        [TestMethod]
        public void TestMethodTypeCounters ()
            {
            ArrayList exoplanetArray = null;

            if (File.Exists (Constant.UnitTestCSVFolder + "Version2.xml"))
                exoplanetArray = ReadXML.Read (Constant.UnitTestCSVFolder + "Version2.xml", true);
            else
                {
                ReadCSV.Read (Constant.UnitTestCSVFolder + "Version2.csv");
                exoplanetArray = ReadXML.Read (Constant.UnitTestCSVFolder + "Version2.xml", true);
                }

            Assert.IsNotNull (exoplanetArray);

            Assert.AreEqual (Exoplanets.NumberOfExoplanets (exoplanetArray), 1950);
            Assert.AreEqual (Exoplanets.NumberOfTypeOStars (exoplanetArray), 0);
            Assert.AreEqual (Exoplanets.NumberOfTypeBStars (exoplanetArray), 8);
            Assert.AreEqual (Exoplanets.NumberOfTypeAStars (exoplanetArray), 13);
            Assert.AreEqual (Exoplanets.NumberOfTypeFStars (exoplanetArray), 129);
            Assert.AreEqual (Exoplanets.NumberOfTypeGStars (exoplanetArray), 389);
            Assert.AreEqual (Exoplanets.NumberOfTypeKStars (exoplanetArray), 274);
            Assert.AreEqual (Exoplanets.NumberOfTypeMStars (exoplanetArray), 91);
            Assert.AreEqual (Exoplanets.NumberOfMultiPlanetStars (exoplanetArray), 539);
            }

        [TestMethod]
        public void TestMethodReadVersion1NValid ()
            {
            ArrayList exoplanetArray = null;

            if (File.Exists (Constant.UnitTestCSVFolder + "Version1.xml"))
                exoplanetArray = ReadXML.Read (Constant.UnitTestCSVFolder + "Version1.xml");
            else
                {
                ReadCSV.Read (Constant.UnitTestCSVFolder + "Version1.csv");
                exoplanetArray = ReadXML.Read (Constant.UnitTestCSVFolder + "Version1.xml");
                }

            Assert.IsNotNull (exoplanetArray);
            }

        [TestMethod]
        public void TestMethodReadVersion2NValid ()
            {
            ArrayList exoplanetArray = null;

            if (File.Exists (Constant.UnitTestCSVFolder + "Version2.xml"))
                exoplanetArray = ReadXML.Read (Constant.UnitTestCSVFolder + "Version2.xml");
            else
                {
                ReadCSV.Read (Constant.UnitTestCSVFolder + "Version2.csv");
                exoplanetArray = ReadXML.Read (Constant.UnitTestCSVFolder + "Version2.xml");
                }

            Assert.IsNotNull (exoplanetArray);
            }

        [TestMethod]
        public void TestMethodReadEUCatalogAsVOTNValid ()
            {
            ArrayList exoplanetArray = null;

            if (File.Exists (Constant.UnitTestVOTFolder + "exoplanet_catalog.xml"))
                exoplanetArray = ReadXML.Read (Constant.UnitTestVOTFolder + "exoplanet_catalog.xml");
            else
                {
                ReadVOT.Read (Constant.UnitTestVOTFolder + "exoplanet_catalog.vot");
                exoplanetArray = ReadXML.Read (Constant.UnitTestVOTFolder + "exoplanet_catalog.eu_catalog.xml");
                }

            Assert.IsNotNull (exoplanetArray);
            }

        [TestMethod]
        public void TestBestFitCurve ()
            {
            double [] x = { 1.0, 2.0, 3.0, 4.0 };
            double [] y = { 1.26, 1.65, 2.52, 6.08 };

            BestFitCurve bestFitCurve = new BestFitCurve ();

            bestFitCurve.Compute (x, y);
            double result = bestFitCurve.ComputeYAtX (5.0);
            }
        }

    }
