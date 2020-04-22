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

namespace TMS_XLZ_Basic
{
    class TransUnit
    {

        /* Fields */

        public XmlNode sourceNode;
        public XmlNode targetNode;

        public bool translatable;
        public int ID;


        /* Methods */

        /* In the Xliff file we can change mostly everything, but if there will be any change in the source or target text,
           the same change should be applied to the corresponding node in the .skl file. 
           For example:
           1. Merging segments.
           2. Deleting segments.
           3. Adding segments.*/

        /* Method that adds some attribute, like maxwidth="1000" size="char" and so on. */ 

        /* Method that change the segment to be not translatable. */

        public XmlNode GetSourceNode()
        {
            return sourceNode;
        }

        public XmlNode GetTargetNode()
        {
            return targetNode;
        }

        public string GetSourceText()
        {
            return sourceNode.InnerText;
        }

        public string GetTargetText()
        {
            return targetNode.InnerText;
        }

        /* Method that will copy source to target. */

        public void ChangeTranslatable()
        {
            translatable = !translatable;
        }



    }
}
