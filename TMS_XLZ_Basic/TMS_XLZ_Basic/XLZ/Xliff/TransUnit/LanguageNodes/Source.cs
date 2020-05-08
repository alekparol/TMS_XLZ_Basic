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

        private XmlNode xmlNode;

        private string outerXml;
        private string innerXml;
        private string innerText;

        private TransUnitElements sourceElements;
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

        public TransUnitElements SourceElements
        {
            get
            {
                return sourceElements;
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

        public string GetSourceOuterXmlWithoutText()
        {
            string sourceText = xmlNode.InnerText;
            string xmlWithoutText = xmlNode.OuterXml.Replace(sourceText, "");

            return xmlWithoutText;
        }

        /* Constructors */

        public Source(XmlNode xmlNodeContainingSource)
        {

            if (xmlNodeContainingSource.SelectSingleNode("./source") != null)
            {
                parsingSuccess = true;
                xmlNode = xmlNodeContainingSource.SelectSingleNode("./source");
            }

            outerXml = xmlNode.OuterXml;
            innerXml = xmlNode.InnerXml;
            innerText = xmlNode.InnerText;

            if(innerXml.Length != 0)
            {
                sourceElements = new TransUnitElements(innerXml);
            }

        }
    }
}
