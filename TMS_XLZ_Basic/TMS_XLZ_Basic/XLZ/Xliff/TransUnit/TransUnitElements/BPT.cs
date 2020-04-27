using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace TMS_XLZ_Basic
{
    class BPT
    {

        /* Fields */

        public string bptContent;
        public int bptID;

        /* Methods */


        /* Constructors */
        public BPT(string matchBPT)
        {

            Regex regexBPT = new Regex("(<bpt.*?(id=\"(\\d)\")?>(.*?)</?bpt>)");
            Match matchesBPT = regexBPT.Match(matchBPT);

            /* Initializing value of bptID with the valuse of the third group in the regex pattern and converting to int32.*/

            bool success = Int32.TryParse(matchesBPT.Groups[3].Value, out int transUnitID);
            if (success)
            {
                bptID = transUnitID;
            }
            else
            {
                bptID = -1;
            }

            bptContent = matchesBPT.Groups[4].Value;

        }

    }
}
