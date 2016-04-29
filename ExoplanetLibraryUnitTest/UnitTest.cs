using System.Collections;
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
        public void TestMethodVersion3 ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (Constant.UnitTestCSVFolder + "Version3.csv");
            exoplanetArray = ReadXML.Read (Constant.UnitTestCSVFolder + "Version3.xml", true);
            WriteCSV.Write (Constant.UnitTestCSVFolder + "Version3TestResults.csv", exoplanetArray, Constant.Version2);    // Constant.Version2 needs work

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
        public void TestMethodVersion3Dat ()
            {
            ArrayList exoplanetArray = null;

            ReadCSV.Read (Constant.UnitTestDATFolder + "Version3.dat");
            exoplanetArray = ReadXML.Read (Constant.UnitTestDATFolder + "Version3.xml", true);
            WriteCSV.Write (Constant.UnitTestDATFolder + "Version3TestResults.dat", exoplanetArray, Constant.Version2);    // Constant.Version2 needs work

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
            Assert.AreEqual (Exoplanets.NumberOfMultiPlanetStars (exoplanetArray), 720);
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
        public void TestSettingsReadWrite ()
            {
            Filters keeper = Settings.ReadFilter ();

            Filters test1 = new Filters ();
            test1.TypeOEnabled = CheckState.Checked;
            test1.TypeBEnabled = CheckState.Checked;
            test1.TypeAEnabled = CheckState.Checked;
            test1.TypeFEnabled = CheckState.Checked;
            test1.TypeGEnabled = CheckState.Checked;
            test1.TypeKEnabled = CheckState.Checked;
            test1.TypeMEnabled = CheckState.Checked;
            test1.UnknownStarEnabled = CheckState.Checked;

            test1.PrimaryTransitEnabled = CheckState.Checked;
            test1.RadialVelocityEnabled = CheckState.Checked;
            test1.MicrolensingEnabled = CheckState.Checked;
            test1.ImagingEnabled = CheckState.Checked;
            test1.PulsarEnabled = CheckState.Checked;
            test1.AstrometryEnabled = CheckState.Checked;
            test1.TTVEnabled = CheckState.Checked;
            test1.UnknownDetectionEnabled = CheckState.Checked;

            Settings.WriteFilter (test1);

            Filters test2 = Settings.ReadFilter ();

            Settings.WriteFilter (keeper);

            Assert.IsNotNull (test1);
            Assert.IsNotNull (test2);

            Assert.AreEqual (test1.TypeOEnabled, test2.TypeOEnabled);
            Assert.AreEqual (test1.TypeBEnabled, test2.TypeBEnabled);
            Assert.AreEqual (test1.TypeAEnabled, test2.TypeAEnabled);
            Assert.AreEqual (test1.TypeFEnabled, test2.TypeFEnabled);
            Assert.AreEqual (test1.TypeGEnabled, test2.TypeGEnabled);
            Assert.AreEqual (test1.TypeKEnabled, test2.TypeKEnabled);
            Assert.AreEqual (test1.TypeMEnabled, test2.TypeMEnabled);
            Assert.AreEqual (test1.UnknownStarEnabled, test2.UnknownStarEnabled);

            Assert.AreEqual (test1.PrimaryTransitEnabled, test2.PrimaryTransitEnabled);
            Assert.AreEqual (test1.RadialVelocityEnabled, test2.RadialVelocityEnabled);
            Assert.AreEqual (test1.MicrolensingEnabled, test2.MicrolensingEnabled);
            Assert.AreEqual (test1.ImagingEnabled, test2.ImagingEnabled);
            Assert.AreEqual (test1.PulsarEnabled, test2.PulsarEnabled);
            Assert.AreEqual (test1.AstrometryEnabled, test2.AstrometryEnabled);
            Assert.AreEqual (test1.TTVEnabled, test2.TTVEnabled);
            Assert.AreEqual (test1.UnknownDetectionEnabled, test2.UnknownDetectionEnabled);
            }

        [TestMethod]
        [Ignore]
        public void TestMethodGetMinimumMaximumValues ()
            {
            ArrayList exoplanetArray = null;

            if (File.Exists (Constant.UnitTestVOTFolder + "exoplanet_catalog.xml"))
                exoplanetArray = ReadXML.Read (Constant.UnitTestVOTFolder + "exoplanet_catalog.xml");
            else
                {
                ReadVOT.Read (Constant.UnitTestVOTFolder + "exoplanet_catalog.vot");
                exoplanetArray = ReadXML.Read (Constant.UnitTestVOTFolder + "exoplanet_catalog.xml");
                }

            Assert.IsNotNull (exoplanetArray);

            TextWriter writer = null;

            using (writer = File.CreateText (Constant.UnitTestVOTFolder + "MinMax.txt"))
                {
                string [] properties = { "Mass", "Radius", "OrbitalPeriod", "SemiMajorAxis", "Eccentricity",
                                    "AngularDistance", "Inclination", "TzeroTr","TzeroTrSec","LambdaAngle",
                                    "TzeroVr", "LogG", "Omega", "Tperi", "ImpactParameter", "K", "GeometricAlbedo"
                                    };

                foreach (string property in properties)
                    {
                    if (Helper.IsPlotable (property))
                        {
                        double minimum = Helper.GetMinimum (exoplanetArray, property);

                        if (minimum < double.MaxValue)
                            writer.Write ("Property {0} minimum {1}\r", property, minimum);
                        }
                    }

                foreach (string property in properties)
                    {
                    if (Helper.IsPlotable (property))
                        {
                        double maximum = Helper.GetMaximum (exoplanetArray, property);

                        if (maximum > double.MinValue)
                            writer.Write ("Property {0} maximum {1}\r", property, maximum);
                        }
                    }
                }
            }
        }

    }
