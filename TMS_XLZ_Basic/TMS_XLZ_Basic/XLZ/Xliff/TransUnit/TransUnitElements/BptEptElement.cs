using System;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;
using System.Dynamic;

/* Note: mostly all of the fields and methods in this class is understandable with exception to hasNested and isPaired variables. 
 * They are created due to the fact that the regex expression "(<bpt.*?(id=\"(\\d)\")?>.*?</bpt>)(.*?)(<ept.*?(id=\"(\\d)\")?>.*?</ept>)"
 * does not neccesserily return expected result when <bpt><ept> tags are nested. Like in the example below:
 * 
 * You can review the messaging previously shared about our response to COVID-19 by visiting 
 * <it tilt:origid="1" id="5" pos="close">&lt;/cf&gt;</it><bpt id="2">&lt;hyperlink Id="1" tkn="734"&gt;</bpt>
 * <bpt id="3">&lt;cf style="Hyperlink" font="Arial" asiantextfont="Arial" complexscriptsfont="Arial"&gt;</bpt>
 * https://connect.otis.com/news/Pages/Global-Coronavirus-Update.aspx<ept id="3">&lt;/cf&gt;</ept><ept id="2">
 * &lt;/hyperlink&gt;</ept><it tilt:origid="4" id="6" pos="open">&lt;cf font="Arial" asiantextfont="Arial" complexscriptsfont="Arial"&gt;</it>
 *
 * Here, our regex expression will match the first occurance of our pattern, so the string:
 * 
 * <bpt id="2">&lt;hyperlink Id="1" tkn="734"&gt;</bpt><bpt id="3">&lt;cf style="Hyperlink" font="Arial" 
 * asiantextfont="Arial" complexscriptsfont="Arial"&gt;</bpt>https://connect.otis.com/news/Pages/Global-Coronavirus-Update.aspx
 * <ept id="3">&lt;/cf&gt;</ept>
 * 
 * So the <bpt id="2"> is without a pair. I had an idea:
 * 1. Parse the match in the constructor to the elements Ept and Bpt, 
 * 2. Check if their IDs are the same,
 *  a. If yes,
 *      a.1. proceed normally.
 *  b. If no,
 *      b.1. get the ID of the bptElement, 
 *      b.2. modify the regex expression "(<bpt.*?(id=\"bptID\")?>.*?</bpt>)(.*?)(<ept.*?(id=\"bptID\")?>.*?</ept>)",
 *      b.3. parse the input string with this expression. 
 *      
 *  Note: If there is a <bpt></bpt> tag there must be corresponding <ept></ept> pair. But if there is a <ept></ept> that does not means that
 *  the <bpt></bpt> pair of the same ID can be found in the place preceeding the <ept></ept>. This should be added.
 *  
 *  Note: "</ept><bpt id = \"2\" > &lt; hyperlink Id = &quot;1&quot; tkn=&quot;734&quot;&gt;</bpt><bpt id = \"3\" > &lt; cf style = &quot; Hyperlink&quot; font=&quot;Arial&quot; asiantextfont=&quot;Arial&quot; complexscriptsfont=&quot;Arial&quot;&gt;</bpt>https://connect.otis.com/news/Pages/Global-Coronavirus-Update.aspx<ept id=\"3\">&lt;/cf&gt;</ept><ept id=\"2\">" 
 *  gives a result in which the program says that parsing succeeded. We need a stronger validation on the constructor level.
 */

namespace TMS_XLZ_Basic.XLZ.Xliff.TransUnit.TransUnitElements
{
    public class BptEptElement
    {
        /* Fields */

        private BPT bptElement;
        private EPT eptElement;

        private int elementID;
        private string textBetween;

        private bool hasNestedNodes;
        private bool parsingSuccess = false;
        private bool isPaired = false;

        private BptEptElement nestedElement;

        /* Properties */

        public int ElementID
        {
            get
            {
                return elementID;
            }
        }

        public bool ParsingSuccess
        {
            get
            {
                return parsingSuccess;
            }
        }

        public string TextBetween
        {
            get
            {
                return textBetween;
            }
        }

        public bool IsNested
        {
            get
            {
                return hasNestedNodes;
            }
        }

        public bool IsPaired
        {
            get
            {
                return isPaired;
            }
        }

        public BPT BptElement
        {
            get
            {
                if (bptElement.ParsingSuccess)
                {
                    return bptElement;
                }
                else
                {
                    return null;
                }
            }
        }

        public EPT EptElement
        {
            get
            {
                if (eptElement.ParsingSuccess)
                {
                    return eptElement;
                }
                else
                {
                    return null;
                }
            }
        }

        /* Methods *

        /* Constructors */
        public BptEptElement(string matchBptEpt)
        {

            Regex regexBptEpt = new Regex("(<bpt.*?(id=\"(\\d+)\")?>.*?</bpt>)(.*?)(<ept.*?(id=\"(\\d+)\")?>.*?</ept>)");
            Match matchesBptEpt = regexBptEpt.Match(matchBptEpt);

            if (matchesBptEpt.Value != string.Empty)
            {

                parsingSuccess = true;

                /* Initializing value of bptID with the valuse of the third group in the regex pattern and converting to int32.*/

                string bptElementRaw = matchesBptEpt.Groups[1].Value;
                string eptElementRaw = matchesBptEpt.Groups[5].Value;

                bptElement = new BPT(bptElementRaw);
                eptElement = new EPT(eptElementRaw);

                if (bptElement.BptID == eptElement.EptID)
                {
                    isPaired = true;
                    elementID = bptElement.BptID;

                    textBetween = matchesBptEpt.Groups[4].Value;

                    Match matchesNestedBptEpt = regexBptEpt.Match(textBetween);

                    if (matchesNestedBptEpt.Value != string.Empty)
                    {

                        hasNestedNodes = true;
                        nestedElement = new BptEptElement(matchesNestedBptEpt.Value);

                    }
                }
                else
                {

                    Regex regexBptEptPaired = new Regex("(<bpt.*?(id=\"" + bptElement.BptID + "\")?>.*?</bpt>)(.*?)(<ept.*?(id=\"" + bptElement.BptID + "\")?>.*?</ept>)");
                    matchesBptEpt = regexBptEpt.Match(matchBptEpt);

                    if (matchesBptEpt.Value != string.Empty)
                    {

                        parsingSuccess = true;

                        /* Initializing value of bptID with the valuse of the third group in the regex pattern and converting to int32.*/

                        bptElementRaw = matchesBptEpt.Groups[1].Value;
                        eptElementRaw = matchesBptEpt.Groups[5].Value;

                        bptElement = new BPT(bptElementRaw);
                        eptElement = new EPT(eptElementRaw);

                        if (bptElement.BptID == eptElement.EptID)
                        {
                            isPaired = true;
                            elementID = bptElement.BptID;

                            textBetween = matchesBptEpt.Groups[4].Value;

                            Match matchesNestedBptEpt = regexBptEpt.Match(textBetween);

                            if (matchesNestedBptEpt.Value != string.Empty)
                            {

                                hasNestedNodes = true;
                                nestedElement = new BptEptElement(matchesNestedBptEpt.Value);

                            }

                        }
                    }
                }

                
            }

        }
    }
}
