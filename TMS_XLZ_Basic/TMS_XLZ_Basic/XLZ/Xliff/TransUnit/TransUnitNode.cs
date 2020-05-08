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
    class TransUnitNode
    {

        /* Fields */

        private TransUnitData data;

        private TransUnitNode nextSibling;
        private TransUnitNode previousSibling;

        /*Properties*/



        /* Methods */

        /* Constructors */

        public TransUnitNode(XmlNode transUnitNode)
        {

            data = new TransUnitData(transUnitNode);

            nextSibling = new TransUnitNode(transUnitNode.NextSibling);
            previousSibling = new TransUnitNode(transUnitNode.PreviousSibling);

        }

    }
}