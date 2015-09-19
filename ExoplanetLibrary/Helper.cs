using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExoplanetLibrary
    {
    class Helper
        {
        static public string FormatHMS ( string text )
            {
            if ( !string.IsNullOrEmpty ( text ) )
                {
                double hms = Double.Parse ( text );
                double signage = ( hms < 0.0 ) ? -1.0 : 1.0;

                if( hms < 0.0)
                    hms = Math.Abs( hms );

                double hour = ( int )hms;
                double ms = 60.0 * ( hms - hour );
                double minute = ( int )ms;
                double seconds = ( int )( 60.0 * ( ms - minute ) );

                return string.Format ( "{0}:{1}:{2}", signage * hour, minute, seconds );
                }

            return text;
            }

        static public bool ParseHMS ( string text, out double hms )
            {
            hms = 0.0;

            if ( !string.IsNullOrEmpty ( text ) )
                {
                char[ ] delimiterChars = { ':' };
                string[ ] strings = text.Split ( delimiterChars );

                if ( strings.Length == 3 )
                    {
                    hms = double.Parse ( strings[0] ) + double.Parse ( strings[1] ) / 60.0 + double.Parse ( strings[2] ) / 3600.0;
                    return true;
                    }
                }

            return false;
            }
        }
    }
