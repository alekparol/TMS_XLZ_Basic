using System;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Dynamic;

namespace TMS_XLZ_Basic
{
    public class PhElement
    {

        /* Fields */

        private string phContent;
        private int phID;

        /*private int firstIndex;
        private int lastIndex;*/

        private bool parsingSuccess = false;

        /* Properties */

        public string PhContent
        {
            get
            {
                return phContent;
            }
        }

        public int PhID
        {
            get
            {
                return phID;
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
        public PhElement(string matchPH)
        {

            Regex regexPH = new Regex("(<ph.*?(id=\"(\\d+)\")?>(.*?)</ph>)");
            Match matchesPH = regexPH.Match(matchPH);

            if (matchesPH.Value != string.Empty)
            {

                parsingSuccess = true;

                /* Initializing value of bptID with the valuse of the third group in the regex pattern and converting to int32.*/

                bool success = Int32.TryParse(matchesPH.Groups[3].Value, out int transUnitID);

                if (success)
                {
                    phID = transUnitID;
                }
                else
                {
                    phID = -1;
                }

                phContent = matchesPH.Groups[4].Value;
            }

        }

    }
}
