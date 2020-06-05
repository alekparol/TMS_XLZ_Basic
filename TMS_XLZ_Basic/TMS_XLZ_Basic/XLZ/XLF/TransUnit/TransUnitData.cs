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
    public class TransUnitData
    {

        /* Fields */

        private XmlNode xmlNode;

        private Source sourceNode;
        private Target targetNode;

        private string generalID;
        private int iD;
        private bool isTranslatable;

        private bool parsingSuccess;
        private bool isNotWellFormed;

        /*Properties*/

        public Source SourceNode
        {
            get
            {
                return sourceNode;
            }
        }

        public Target TargetNode
        {
            get
            {
                return targetNode;
            }
        }

        public string GeneralID
        {
            get
            {
                return generalID;
            }
        }

        public int ID
        {
            get
            {
                return iD;
            }
        }

        public bool IsTranslatable
        {
            get
            {
                return isTranslatable;
            }
        }

        public bool IsWellFormed
        {
            get
            {
                return !isNotWellFormed;
            }
        }

        public bool DoesHaveNumericalID
        {
            get
            {
                if (this.iD != -1 && this.generalID != string.Empty)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /* Methods */

        /*Changing Translatable value*/

        public void NotForTranslation()
        {
            xmlNode.Attributes["translate"].Value = "no";
        }

        public void ForTranslation()
        {
            xmlNode.Attributes["translate"].Value = "yes";
        }

        public void TranslationNegation()
        {
            if(isTranslatable)
            {
                NotForTranslation();
            }
            else if(!isTranslatable)
            {
                ForTranslation();
            }
        }

        /* Function that returns ID value for trans-unit node. */

        public string GetInnerXmlWithoutText(XmlNode sourceOrTargetNode)
        {

            string unionOfMatches = "";
            string innerTextOfTheNode = sourceOrTargetNode.InnerXml;

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
            return GetInnerXmlWithoutText(sourceNode.XmlNode);
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
            return GetInnerTextWithoutXml(sourceNode.XmlNode);
        }    

         public string GetTargetInnerXmlWithoutText()
         {
             return GetInnerXmlWithoutText(targetNode.XmlNode);
         }

         public string GetTargetInnerTextWithoutXml()
         {
             return GetInnerTextWithoutXml(targetNode.XmlNode);
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

        /* Constructors */

        public TransUnitData(XmlNode transUnitNode)
        {

            xmlNode = transUnitNode;

            sourceNode = new Source(transUnitNode);
            targetNode = new Target(transUnitNode);

            if (sourceNode != null || targetNode != null)
            {

                if (transUnitNode.Attributes["id"] != null) generalID = transUnitNode.Attributes["id"].Value;

                bool success = Int32.TryParse(transUnitNode.Attributes["id"].Value, out int transUnitID);
                if (success)
                {
                    iD = transUnitID;
                }
                else
                {
                    iD = -1;
                }


                if (transUnitNode.Attributes["translate"].Value == "no")
                {
                    isTranslatable = false;
                }
                else if (transUnitNode.Attributes["translate"].Value == "yes")
                {
                    isTranslatable = true;
                }
                else
                {
                    isNotWellFormed = true;
                }

            }         

        }

    }
}