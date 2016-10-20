using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace ExoplanetLibrary
    {
    public class ReadTBL
        {
        public ReadTBL ()
            {
            }

        static private string Version_ = Constant.Version3;
        static private string Version
            {
            get { return Version_; }
            set { Version_ = value; }
            }

        static private int NumberOfStrings_ = 0;
        static private int NumberOfStrings
            {
            get { return NumberOfStrings_; }
            set { NumberOfStrings_ = value; }
            }

        static private int [] Pipes_ = null;
        static private int [] Pipes
            {
            get { return Pipes_; }
            set { Pipes_ = value; }
            }

        static private string ValidationErrors_ = string.Empty;
        static private string ReadErrors
            {
            get { return ValidationErrors_; }
            set { ValidationErrors_ = value; }
            }

        static private string [] Extensions_ = { ".tbl" };
        static private string [] Extensions
            {
            get { return Extensions_; }
            }

        static public bool IsTBL (string fileName)
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

                string xmlFileName = csvFileName.Replace (".tbl", ".xml");

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
                                AssignPipeIndexes (line);
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
            if (line.StartsWith ("\\"))
                return true;
            else if (line.StartsWith ("| "))
                return true;
            else if (line.StartsWith ("|char"))
                return true;
            else
                return false;
            }

        static private bool IsDefinition (string line)
            {
            bool isDefinition = false;

            if (line.StartsWith ("|rowid"))
                {
                line = line.Remove (0, 1);
                char [] delimiterChars = { '|' };
                string [] strings = line.Split (delimiterChars);

                Indexer.Initialize ();

                for (int index = 0; index < strings.Length; ++index)
                    Indexer.SetIndex (strings [index].Trim (), index);

                Version = Constant.LastestVersion;
                NumberOfStrings = strings.Length;
                isDefinition = true;
                }

            return isDefinition;
            }

        static private void AssignPipeIndexes (string line)
            {
            int pipeIndex = 0;

            Pipes = new int [NumberOfStrings + 1];

            for (int index = 0; index < line.Length; ++index)
                if (line [index] == '|')
                    Pipes [pipeIndex++] = index;

            Pipes [pipeIndex] = line.Length - 1;
            }

        static private int WriteExoplanet (XmlWriter writer, string line)
            {
            string [] strings = new string [NumberOfStrings];

            for (int index = 0; index < Pipes.Length - 1; ++index)
                {
                string stringer = line.Substring (Pipes [index] + 1, Pipes [index + 1] - Pipes [index]);
                stringer = stringer.Replace ("null", string.Empty);
                strings [index] = stringer.Trim ();
                }

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
