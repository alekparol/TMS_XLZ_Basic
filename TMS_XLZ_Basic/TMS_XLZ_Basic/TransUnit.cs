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

/*TODO: Extending this class according to the http://docs.oasis-open.org/xliff/v1.2/os/xliff-core.html */

namespace TMS_XLZ_Basic
{
    class TransUnit
    {

        /* Fields */

        public string outerXml;
        public string innerXml;

        public XmlNode sourceNode;
        public XmlNode targetNode;

        public bool translatable;
        public int ID;

        public int validationResult;

        /* Methods */

        /* In the Xliff file we can change mostly everything, but if there will be any change in the source or target text,
           the same change should be applied to the corresponding node in the .skl file. 
           For example:
           1. Merging segments.
           2. Deleting segments.
           3. Adding segments.*/

        /* Method that adds some attribute, like maxwidth="1000" size="char" and so on. */
        /* Method that will copy source to target. */
        /* Method that change the segment to be not translatable. */

        /* Function for checking if all fields have been initialized and returning the information in form of integer:
         * - 2 for both target and source
         * - 0 for source
         * - -1 for target 
         * - -3 for nothing.
         * Note: Of course all other fields have to be initialized. */

        public int GetTransUnitValidationResults()
        {
            return validationResult;
        }

        /* Functions for Get source and target Xml nodes.*/

        public XmlNode GetSourceNode(XmlNode transUnitNode)
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

        public string GetSourceInnerXmlWithoutText()
        {
            string sourceText = sourceNode.InnerText;
            string xmlWithoutText = sourceNode.InnerXml.Replace(sourceText, "");

            return xmlWithoutText;
        }

        public string GetTargetInnerXmlWithoutText()
        {
            string targetText = targetNode.InnerText;
            string xmlWithoutText = targetNode.InnerXml.Replace(targetText, "");

            return xmlWithoutText;
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

        public bool IfTranslatable()
        {
            return translatable;
        }

        /* Function that returns ID value for trans-unit node. */

        public int GetTransUnitID()
        {
            return ID;
        }

        /* Constructors */

        public TransUnit(XmlNode transUnitNode)
        {

            /* Initializing ID field. */

            bool success = Int32.TryParse(transUnitNode.Attributes["id"].Value, out int transUnitID);

            if (success)
            {
                ID = -1;
            }
            else
            {
                ID = transUnitID;
            }

            /* Initializing translatable field. */

            if (transUnitNode.Attributes["translate"].Value == "no")
            {
                translatable = false;
            }
            else if(transUnitNode.Attributes["translate"].Value == "yes")
            {
                translatable = true;
            }


            /* Initializing sourceNode and targetNode fields. */

            if(transUnitNode.SelectSingleNode("./source") != null)
            {
                validationResult += 1;
                sourceNode = transUnitNode.SelectSingleNode("./source");
            }
            else
            {
                validationResult -= 2;
            }

            if(transUnitNode.SelectSingleNode("./target") != null)
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
