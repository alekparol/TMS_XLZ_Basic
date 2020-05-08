using System;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Dynamic;

namespace TMS_XLZ_Basic
{
    public class ItElement
    {

        /* Fields */

        private string itContent;
        private int itID;

        /*private int firstIndex;
        private int lastIndex;*/

        private bool parsingSuccess = false;

        /* Properties */

        public string ItContent
        {
            get
            {
                return itContent;
            }
        }

        public int ItID
        {
            get
            {
                return itID;
            }
        }

        public bool ParsingSuccess
        {
            get
            {
                return parsingSuccess;
            }
        }

        /* Methods */

        /* Constructors */
        public ItElement(string matchIT)
        {

            Regex regexIT = new Regex("(<it.*?(id=\"(\\d+)\")?>(.*?)</it>)");
            Match matchesIT = regexIT.Match(matchIT);

            if (matchesIT.Value != string.Empty)
            {

                parsingSuccess = true;

                /* Initializing value of bptID with the valuse of the third group in the regex pattern and converting to int32.*/

                bool success = Int32.TryParse(matchesIT.Groups[3].Value, out int transUnitID);

                if (success)
                {
                    itID = transUnitID;
                }
                else
                {
                    itID = -1;
                }

                itContent = matchesIT.Groups[4].Value;
            }

        }

    }
}
