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
    class Target
    {

        /* Fields */

        private XmlNode xmlNode;

        private string outerXml;
        private string innerXml;
        private string innerText;

        private TransUnitElements targetElements;
        private bool parsingSuccess;

        /*Properties*/

        public XmlNode XmlNode
        {
            get
            {
                return xmlNode;
            }
        }


        public string OuterXml
        {
            get
            {
                return outerXml;
            }
        }

        public string InnerXml
        {
            get
            {
                return innerXml;
            }
        }

        public string InnerText
        {
            get
            {
                return innerText;
            }
        }

        public TransUnitElements TargetElements
        {
            get
            {
                return targetElements;
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

        public string GetTargetOuterXmlWithoutText()
        {
            string targetText = xmlNode.InnerText;
            string xmlWithoutText = xmlNode.OuterXml.Replace(targetText, "");

            return xmlWithoutText;
        }

        /* Constructors */

        public Target(XmlNode xmlNodeContainingTarget)
        {

            if (xmlNodeContainingTarget.SelectSingleNode("./target") != null)
            {
                parsingSuccess = true;
                xmlNode = xmlNodeContainingTarget.SelectSingleNode("./target");
            }

            outerXml = xmlNode.OuterXml;
            innerXml = xmlNode.InnerXml;
            innerText = xmlNode.InnerText;

            if (innerXml.Length != 0)
            {
                targetElements = new TransUnitElements(innerXml);
            }

        }
    }
}
