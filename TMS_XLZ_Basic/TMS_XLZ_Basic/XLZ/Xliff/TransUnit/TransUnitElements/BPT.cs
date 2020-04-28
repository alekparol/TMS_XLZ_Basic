using System;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Dynamic;

/* BPT class is used to model all the information from <bpt></bpt> tags in trans-unit nodes. Usually the form of the <bpt> node is 
 * as below:
 * <bpt id="x">&lt;attr_1="a_1",...,attr_i="a_i"&gt;</bpt>,
 * where &lt; and &gt; are entities corresponding to "<" and ">",
 * attr_1,...,attr_i are denoting some specifical attribute, 
 * a_1,...,a_i are denoting some specifical value of the attribute. 
 * 
 * 
 * Notes: 
 * - bptID 
 * 
 * Further development: This class could be improved by adding fields corresponding to more document attributes, which could be 
 * covered by the BPT class. For example <bpt> tags contains information:
 * - font="Arial",
 * - asiantextfont="Arial",
 * - complexscriptsbold="on",
 * - bold="on",
 * - hyperlink Id="1",
 * - size="18"*/

namespace TMS_XLZ_Basic
{
    public class BPT
    {

        /* Fields */

        private string bptContent;
        private int bptID;

        private bool parsingSuccess = false; 

        /* Properties */

        public string BptContent
        {
            get
            {
                return bptContent;
            }
        }

        public int BptID
        {
            get
            {
                return bptID;
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

        /* Method that checks if the text between <bpt> tags contain information regarding yellow highlight. */

        public bool IsYellowHighlight()
        {
            if (bptContent.Contains("highlight=\"yellow\""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Constructors */
        public BPT(string matchBPT)
        {
                           
            Regex regexBPT = new Regex("(<bpt.*?(id=\"(\\d+)\")?>(.*?)</bpt>)");
            Match matchesBPT = regexBPT.Match(matchBPT);

            if(matchesBPT.Value != string.Empty)
            {

                parsingSuccess = true;

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
}
