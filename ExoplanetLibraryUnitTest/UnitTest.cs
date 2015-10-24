using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ExoplanetLibrary;

namespace ExoplanetLibraryUnitTest
    {
    [TestClass]
    public class UnitTest
        {
        [TestMethod]
        public void TestMethod ()
            {
            ArrayList ExoplanetArray = null;

            ReadCSV.Read ("C:\\ProgramData\\Exoplanet Library\\kepler.csv");
            ReadXML.Read ("C:\\ProgramData\\Exoplanet Library\\kepler.xml", ref ExoplanetArray);
            WriteCSV.Write ("C:\\ProgramData\\Exoplanet Library\\test.csv", ExoplanetArray);
            }
        }
    }
