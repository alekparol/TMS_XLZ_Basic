using System;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Dynamic;
using System.Collections.Generic;

/* BPT class is used to model all the information from <bpt></bpt> tags in trans-unit nodes. Usually the form of the <bpt> node is 
 * as below:
 * <bpt id="x">&lt;attr_1="a_1",...,attr_i="a_i"&gt;</bpt>,
 * where &lt; and &gt; are entities corresponding to "<" and ">",
 * attr_1,...,attr_i are denoting some specifical attribute, 
 * a_1,...,a_i are denoting some specifical value of the attribute. 
 * 
 * All <bpt> tags have corresponding <ept> tags - correspondence is denoted by the same Id attribute's value. 
 * But it is worth to mention that those pairs doesn't have to be placed within the boundries of one trans-unit node. 
 * We can find a lot of examples where whole content of a one trans-unit node is between <bpt> tags or <ept> tags. 
 * In those cases, mostly those trans-unit nodes are not translatable. But there also some examples where <bpt> appears in the end of
 * the trans-unit node and there is no corresponding <ept> tag within the same trans-unit node. But few segments after, we can find 
 * <ept> tag with the same ID. such case might exists when two sentences splitted into two translation segments, have the same formatting
 * so the formatting tag <bpt> starts before the beginning of the first segment and ends after the end of the second segment.
 * 
 * Example from content.xlf file is like below:
 * <trans-unit translate="yes" id="23">
 *      <source><bpt id="1">&lt;cf cstyle="CharacterStyle/$ID/[No character style]" color="Color/C=0 M=0 Y=0 K=100" style="Regular" size="9" leading="unit:11" font="string:Diodrum"&gt;</bpt>Without compromising performance, the new DuPont™ Delrin® 300CPE adds:</source><target logoport:matchpercent="0" state="translated"><bpt id="1">&lt;cf cstyle="CharacterStyle/$ID/[No character style]" color="Color/C=0 M=0 Y=0 K=100" style="Regular" size="9" leading="unit:11" font="string:Diodrum"&gt;</bpt>Ohne Abstriche in der Leistung zu machen, bietet Ihnen das neue DuPont™ Delrin® 300CPE zusätzlich:</target>
 * </trans-unit>
 * <trans-unit translate="no" id="24">
 *      <source> </source>
 * </trans-unit>
 * <trans-unit translate="no" id="25">
 *      <source><ept id="1">&lt;/cf&gt;</ept></source>
 * </trans-unit>
 * 
 * 
 * Further development: This class could be improved by adding fields corresponding to more document attributes, which could be 
 * covered by the BPT class. For example <bpt> tags contains information:
 * - font="Arial",
 * - style="Medium",
 * - cstyle="CharacterStyle/$ID/[No character style]",
 * - color="Color/C=0 M=0 Y=0 K=100"
 * - leading="unit:10"
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

        /* Method that checks if the text between <bpt> tags contain information regarding yellow highlight. */

        public bool IsYellowHighlight()
        {
            if (content.Contains("highlight=\"yellow\""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* Constructors */
        public BPT(string bptString)
        {
                           
            Regex regex = new Regex("(<bpt.*?(id=\"(\\d+)\")?>(.*?)</bpt>)");
            Match match = regex.Match(bptString);

            if(match.Value != string.Empty)
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
