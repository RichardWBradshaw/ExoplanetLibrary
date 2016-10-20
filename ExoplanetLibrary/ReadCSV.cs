using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ExoplanetLibrary
    {
    public class ReadCSV
        {
        public ReadCSV ()
            {
            }

        static private string Version_ = Constant.Version3;
        static private string Version
            {
            get { return Version_; }
            set { Version_ = value; }
            }

        static private bool IsCommaDelimited_ = true;
        static private bool IsCommaDelimited
            {
            get { return IsCommaDelimited_; }
            set { IsCommaDelimited_ = value; }
            }

        static private int NumberOfStrings_ = 0;
        static private int NumberOfStrings
            {
            get { return NumberOfStrings_; }
            set { NumberOfStrings_ = value; }
            }

        static private string ValidationErrors_ = string.Empty;
        static private string ReadErrors
            {
            get { return ValidationErrors_; }
            set { ValidationErrors_ = value; }
            }

        static private string [] Extensions_ = { ".csv", ".dat", ".tab" };
        static private string [] Extensions
            {
            get { return Extensions_; }
            }

        static public bool IsCSV (string fileName)
            {
            for (int index = 0; index < Extensions.Length; ++index)
                if (fileName.EndsWith (Extensions [index]))
                    return true;

            return false;
            }

        static public string ReplaceExtension (string fileName)
            {
            for (int index = 0; index < Extensions.Length; ++index)
                if (fileName.EndsWith (Extensions [index]))
                    return fileName.Replace (Extensions [index], ".xml");

            return fileName;
            }

        static public int Read (string csvFileName)
            {
            if (File.Exists (csvFileName))
                {
                XmlWriter writer = null;
                XmlWriterSettings settings = null;

                settings = new XmlWriterSettings ();

                settings.IndentChars = "\t";
                settings.NewLineHandling = NewLineHandling.Entitize;
                settings.Indent = true;
                settings.NewLineChars = "\n";

                string xmlFileName = string.Empty;

                if (csvFileName.EndsWith (".txt"))      // needs_work write a helper function
                    xmlFileName = csvFileName.Replace (".txt", ".xml");
                else if (csvFileName.EndsWith (".dat"))
                    xmlFileName = csvFileName.Replace (".dat", ".xml");
                else if (csvFileName.EndsWith (".tab"))
                    xmlFileName = csvFileName.Replace (".tab", ".xml");
                else
                    xmlFileName = csvFileName.Replace (".csv", ".xml");

                ReadErrors = string.Empty;

                writer = XmlWriter.Create (xmlFileName, settings);

                writer.WriteStartElement ("Exoplanets");
                writer.WriteAttributeString ("version", Version);

                TextReader reader = null;

                using (reader = File.OpenText (csvFileName))
                    {
                    string line = null;

                    for (;;)
                        {
                        if (( line = reader.ReadLine () ) != null)
                            {
                            if (IsDefinition (line))
                                {
                                }
                            else if (IsComment (line))
                                {
                                }
                            else
                                WriteExoplanet (writer, line);
                            }
                        else
                            break;
                        }
                    }

                writer.WriteEndElement ();
                writer.Close ();
                }

            if (ReadErrors.Length > 0)
                MessageBox.Show (ReadErrors, "Format errors in " + csvFileName);

            return 0;
            }

        static private bool IsComment (string line)
            {
            return line.StartsWith ("#") ? true : false;
            }

        static private bool IsDefinition (string line)
            {
            bool isDefinition = false;

            if (line.StartsWith ("# name"))         // Exoplanet.eu
                {
                line = line.Replace ("# ", string.Empty);
                isDefinition = true;
                }
            else if (line.StartsWith ("A,AUPPER"))  // Exoplanets.org
                isDefinition = true;
            else if (line.StartsWith ("rowid,"))    // NASA archive
                isDefinition = true;
            else if (line.StartsWith ("rowid\t"))   // NASA archive
                isDefinition = true;

            if (isDefinition)
                {
                char [] delimiterChars = { ',', '\t' };
                string [] strings = line.Split (delimiterChars);

                Indexer.Initialize ();

                for (int index = 0; index < strings.Length; ++index)
                    Indexer.SetIndex (strings [index], index);

                Version = Constant.LastestVersion;
                NumberOfStrings = strings.Length;
                IsCommaDelimited = line.Contains ("\t") ? false : true;
                }

            return isDefinition;
            }

        static private int WriteExoplanet (XmlWriter writer, string line)
            {
            //
            // kludge: .csv's can contain commas and / or tabs within in the data, these may occur in literals that are in double quotes
            //

            if (IsCommaDelimited == true)
                {
                line = line.Replace ('\t', ' ');
                line = Helper.ReplaceInQuotedDelimitor (line);
                }
            else
                {
                line = line.Replace (',', ';');
                line = Helper.ReplaceInQuotedDelimitor (line);
                }

            char [] delimiterChars = { ',', '\t' };
            string [] strings = line.Split (delimiterChars);

            if (NumberOfStrings == strings.Length)
                {
                Exoplanet exoplanet = new Exoplanet ();

                exoplanet.AssignFromSubstrings (strings);
                exoplanet.CorrectErrors ();
                WriteXML.WriteExoplanet (writer, exoplanet, Version);
                }
            else
                ReadErrors += line + "\r";

            return 0;
            }
        }
    }
