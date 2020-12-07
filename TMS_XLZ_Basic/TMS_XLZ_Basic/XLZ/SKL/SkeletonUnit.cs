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
using System.Dynamic;

namespace TMS_XLZ_Basic
{
    public class SkeletonUnit
    {

        /* Fields */

        public XmlNode formattingNode;
        public XmlNode placeholderNode;

        int ID;

        /* Methods */

        public int GetSkeletonUnitID()
        {
            return ID;
        }

        public XmlNode GetFormattingNode()
        {
            return formattingNode;
        }

        /* Note: There could be placeholderNode and no formattingNode, but not the opposite. 
         * Base node for the object of this kind should be tu-placeholder. */

        public SkeletonUnit(XmlNode skeletonXmlNode)
        {
            placeholderNode = skeletonXmlNode;

            if(skeletonXmlNode.PreviousSibling != null)
            {
                if(skeletonXmlNode.PreviousSibling.Name == "formatting")
            {
                   formattingNode = skeletonXmlNode.PreviousSibling;
            }

            }
            
            bool success = Int32.TryParse(skeletonXmlNode.Attributes["id"].Value, out int transUnitID);

            if (success)
            {
                ID = transUnitID;
            }
            else
            {
                ID = -1;
            }

        }

    }
}
