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
using TMS_XLZ_Basic.XLZ.Xliff.TransUnit.TransUnitElements;

namespace TMS_XLZ_Basic
{
    class Source
    {

        /* Fields */

        private XmlNode sourceNode;
        private XmlNode targetNode;

        private TransUnitElements transUnitElements;

        public string outerXml;
        public string innerXml;

        public int ID;
        public bool translatable;

        public int validationResult;

        /*Properties*/



        /* Methods */

        public int GetTransUnitValidationResults()
        {
            return validationResult;
        }

        /* Functions for Get source and target Xml nodes.*/

        public XmlNode GetSourceNode()
        {
            return sourceNode;
        }

        public XmlNode GetTargetNode()
        {
            return targetNode;
        }

        /* Functions for Get source and target Xml nodes' text. */

        public string GetSourceText()
        {
            return sourceNode.InnerText;
        }

        public string GetTargetText()
        {
            return targetNode.InnerText;
        }

        /* Functions for Get source and target Xml nodes' Xml code. */

        public string GetSourceXml()
        {
            return sourceNode.InnerXml;
        }

        public string GetTargetXml()
        {
            return targetNode.InnerXml;
        }

        /* Functions for Get source and target Xml nodes' inner Xml code without translatable text. */

        public string GetInnerXmlWithoutText(XmlNode sourceOrTargetNode)
        {

            string unionOfMatches = "";
            string innerTextOfTheNode = sourceOrTargetNode.InnerXml;

            /* This regex will match:
            * - <ept></ept> tags in content.xlf,
            * - <bpt></bpt> tags in content.xlf,
            * - <ph></ph> tags in content.xlf
            * And all the content which is in the scope of those tags and their attributes as well.*/

            Regex rx = new Regex("(<ept.*?>.*</?ept.*?>)|(<bpt.*?>.*</?bpt.*?>)|(<ph.*?>.*</?ph.*?>)|(<it.*?>.*</?it.*?>)");
            MatchCollection matches = rx.Matches(innerTextOfTheNode);

            foreach (Match en in matches)
            {
                unionOfMatches = unionOfMatches + en.Value;
            }

            return unionOfMatches;
        }

        public string GetSourceInnerXmlWithoutText()
        {
            return GetInnerXmlWithoutText(sourceNode);
        }

        public string GetTargetInnerXmlWithoutText()
        {
            return GetInnerXmlWithoutText(targetNode);
        }

        public string GetInnerTextWithoutXml(XmlNode sourceOrTargetNode)
        {

            string setminusOfMatches = "";
            string innerTextOfTheNode = sourceOrTargetNode.InnerXml;

            Regex rx = new Regex("(<ept.*?>.*</?ept.*?>)|(<bpt.*?>.*</?bpt.*?>)|(<ph.*?>.*</?ph.*?>)");
            setminusOfMatches = rx.Replace(innerTextOfTheNode, string.Empty);


            return setminusOfMatches;

        }

        public string GetSourceInnerTextWithoutXml()
        {
            return GetInnerTextWithoutXml(sourceNode);
        }

        public string GetTargetInnerTextWithoutXml()
        {
            return GetInnerTextWithoutXml(targetNode);
        }

        /* Functions for Get source and target Xml nodes' outer Xml code without translatable text. */

        public string GetSourceOuterXmlWithoutText()
        {
            string sourceText = sourceNode.InnerText;
            string xmlWithoutText = sourceNode.OuterXml.Replace(sourceText, "");

            return xmlWithoutText;
        }

        public string GetTargetOuterXmlWithoutText()
        {
            string targetText = targetNode.InnerText;
            string xmlWithoutText = targetNode.OuterXml.Replace(targetText, "");

            return xmlWithoutText;
        }

        /* Function that returns boolean value responsible for translation. */

        public bool IsTranslatable()
        {
            return translatable;
        }

        /* Function that returns ID value for trans-unit node. */

        public int GetTransUnitID()
        {
            return ID;
        }

        /* Experimental methods */

        public void GetBPT()
        {

        }

        public void GetEPT()
        {

        }

        public void GetPH()
        {

        }

        public void GetTextBPTID(int BPTID)
        {
            /*<bpt id="x"></bpt>We are talking abouth this text<ept id="x"></ept>*/
        }

        /* Constructors */

        public Source(XmlNode transUnitNode)
        {

            /* Initializing transUnitNode field. */


            /* Initializing previous syblings fields. */

            /* Initializing ID field. */

            bool success = Int32.TryParse(transUnitNode.Attributes["id"].Value, out int transUnitID);

            if (success)
            {
                ID = transUnitID;
            }
            else
            {
                ID = -1;
            }

            /* Initializing translatable field. */

            if (transUnitNode.Attributes["translate"].Value == "no")
            {
                translatable = false;
            }
            else if (transUnitNode.Attributes["translate"].Value == "yes")
            {
                translatable = true;
            }


            /* Initializing sourceNode and targetNode fields. */

            if (transUnitNode.SelectSingleNode("./source") != null)
            {
                validationResult += 1;
                sourceNode = transUnitNode.SelectSingleNode("./source");
            }
            else
            {
                validationResult -= 2;
            }

            if (transUnitNode.SelectSingleNode("./target") != null)
            {
                validationResult += 1;
                targetNode = transUnitNode.SelectSingleNode("./target");
            }
            else
            {
                validationResult -= 1;
            }

            outerXml = transUnitNode.OuterXml;
            innerXml = transUnitNode.InnerXml;
        }
    }
}
