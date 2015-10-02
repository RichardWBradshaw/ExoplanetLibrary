using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using System.Collections;
using System.Data;

namespace ExoplanetLibrary
    {
    class ReadVOT : CExoplanet
        {
        static XmlReader Reader_ = null;
        static XmlReader Reader
            {
            get
                {
                return Reader_;
                }
            set
                {
                Reader_ = value;
                }
            }

        static public int Read ( string votFileName )//;//, ref ArrayList exoplanets )
            {
            //ValidationErrors = "";

            //exoplanets = new ArrayList ( );

            if ( System.IO.File.Exists ( votFileName ) )
                {
                //FileStream fileStream = null;
                XmlReaderSettings settings = new XmlReaderSettings ( );

                //SetVersion ( votFileName );
                //SetValidation ( fileStream, settings );

                Reader = XmlReader.Create ( votFileName );//, settings );

                while ( Reader.Read ( ) )
                    {
                    CExoplanet exoplanet = new CExoplanet ( );

                    //Reader.MoveToFirstAttribute ( );

                    ReadWhatever ( "RESOURCE");
                    ReadWhatever ( "DESCRIPTION" );
                    ReadWhatever ( "INFO" );
                    ReadWhatever ( "INFO" );
                    ReadWhatever ( "COOSYS" );

                    ReadTable ( );

                    //ReadData ( );
                    }
                }

            return 0;
            }

        static void ReadWhatever ( string whatever)
            {
            Reader.ReadToFollowing ( whatever );

            while ( Reader.MoveToNextAttribute ( ) )
                {
                switch ( Reader.Name )
                    {
                    default:
                        break;
                    }
                }
            }

        static void ReadTable ( )
            {
            Reader.ReadToFollowing ( "DESCRIPTION" );

            while ( Reader.ReadToFollowing ( "FIELD" ) )
                {
                while ( Reader.MoveToNextAttribute ( ) )
                    {
                    switch ( Reader.Name )
                        {
                        case "ID":
                        case "name":
                        case "datatype":
                        case "arraysize":
                        case "unit":
                        case "ucd":
                            break;

                        case "DATA":
                            ReadData ( );
                            break;

                        default:
                            break;
                        }
                    }
                }

            //Reader.ReadToFollowing ( "DATA" );
            //ReadData ( );
            }

        static void ReadData ( )
            {
            //Reader.ReadToFollowing ( "DATA" );

            while ( Reader.ReadToFollowing ( "TABLEDATA" ) )
                {
                while ( Reader.MoveToNextAttribute ( ) )
                    {
                    switch ( Reader.Name )
                        {
                        default:
                            break;
                        }
                    }
                }
            }



        private static void DemonstrateReadWriteXMLDocumentWithReader()
            {
            System.Data.DataTable table = CreateTestTable ("XmlDemo");
            PrintValues (table, "Original table");

            // Write the schema and data to XML in a memory stream.
            System.IO.MemoryStream xmlStream = new System.IO.MemoryStream ();
            table.WriteXml (xmlStream, XmlWriteMode.WriteSchema);

            // Rewind the memory stream.
            xmlStream.Position = 0;

            System.IO.StreamReader reader = new System.IO.StreamReader (xmlStream);
            DataTable newTable = new DataTable ();
            newTable.ReadXml (reader);

            // Print out values in the table.
            PrintValues (newTable, "New table");
            }

        private static DataTable CreateTestTable(string tableName)
            {
            // Create a test DataTable with two columns and a few rows.
            DataTable table = new DataTable (tableName);
            DataColumn column = new DataColumn ("id", typeof (System.Int32));
            column.AutoIncrement = true;
            table.Columns.Add (column);

            column = new DataColumn ("item", typeof (System.String));
            table.Columns.Add (column);

            // Add ten rows.
            DataRow row;
            for (int i = 0; i <= 9; i++)
                {
                row = table.NewRow ();
                row ["item"] = "item " + i;
                table.Rows.Add (row);
                }

            table.AcceptChanges ();
            return table;
            }

        private static void PrintValues(DataTable table, string label)
            {
            Console.WriteLine (label);
            foreach (DataRow row in table.Rows)
                {
                foreach (DataColumn column in table.Columns)
                    {
                    Console.Write ("\t{0}", row [column]);
                    }
                Console.WriteLine ();
                }
            }
        }
    }
