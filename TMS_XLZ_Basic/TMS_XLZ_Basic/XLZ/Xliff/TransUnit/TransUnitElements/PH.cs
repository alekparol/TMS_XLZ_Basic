using System;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Dynamic;

namespace TMS_XLZ_Basic
{
    public class PH
    {

        /* Fields */

        private string content;
        private int iD;

        private bool parsingSuccess = false;

        /* Properties */

        public string Content
        {
            get
            {
                return content;
            }
        }

        public int ID
        {
            get
            {
                return iD;
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
        public PH(string phString)
        {

            Regex regex = new Regex("(<ph.*?(id=\"(\\d+)\")?>(.*?)</ph>)");
            Match match = regex.Match(phString);

            if (match.Value != string.Empty)
            {

                parsingSuccess = true;

                /* Initializing value of bptID with the valuse of the third group in the regex pattern and converting to int32.*/

                bool success = Int32.TryParse(match.Groups[3].Value, out int transUnitID);

                if (success)
                {
                    iD = transUnitID;
                }
                else
                {
                    iD = -1;
                }

                content = match.Groups[4].Value;
            }

        }

    }
}
