using System;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Dynamic;

namespace TMS_XLZ_Basic
{
    public class EPT
    {

        /* Fields */

        private string eptContent;
        private int eptID;

        private int firstIndex;
        private int lastIndex;

        private bool parsingSuccess = false;

        /* Properties */

        public string EptContent
        {
            get
            {
                return eptContent;
            }
        }

        public int EptID
        {
            get
            {
                return eptID;
            }
        }

        public int FirstIndex
        {
            get
            {
                return firstIndex;
            }
        }

        public int LastIndex
        {
            get
            {
                return lastIndex;
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
        public EPT(string matchEPT)
        {

            Regex regexEPT = new Regex("(<ept.*?(id=\"(\\d+)\")?>(.*?)</ept>)");
            Match matchesEPT = regexEPT.Match(matchEPT);

            if (matchesEPT.Value != string.Empty)
            {

                parsingSuccess = true;

                firstIndex = matchesEPT.Value.IndexOf("<");
                lastIndex = matchesEPT.Value.LastIndexOf(">");

                /* Initializing value of bptID with the valuse of the third group in the regex pattern and converting to int32.*/

                bool success = Int32.TryParse(matchesEPT.Groups[3].Value, out int transUnitID);

                if (success)
                {
                    eptID = transUnitID;
                }
                else
                {
                    eptID = -1;
                }

                eptContent = matchesEPT.Groups[4].Value;
            }

        }

    }
}
