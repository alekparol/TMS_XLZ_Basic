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
    public class TransUnitNode
    {

        /* Fields */

        private TransUnitData data;

        private TransUnitNode nextSibling;
        private TransUnitNode previousSibling;

        /*Properties*/

        public TransUnitData Data
        {
            get
            {
                return data; 
            }
            set
            {
                data = value;
            }
        }

        public TransUnitNode NextSibling
        {
            get
            {
                return nextSibling;
            }
            set
            {
                nextSibling = value;
            }
        }

        public TransUnitNode PreviousSibling
        {
            get
            {
                return previousSibling;
            }
            set
            {
                previousSibling = value;
            }
        }


        /* Methods */


        /* Constructors */

        public TransUnitNode(TransUnitData transUnitData)
        {

            data = transUnitData;

            nextSibling = null;
            previousSibling = null;

        }

        public TransUnitNode(TransUnitData transUnitData, TransUnitNode previousNode)
        {
            data = transUnitData;

            nextSibling = null;
            previousSibling = previousNode;

            previousNode.NextSibling = this;

        }

    }
}