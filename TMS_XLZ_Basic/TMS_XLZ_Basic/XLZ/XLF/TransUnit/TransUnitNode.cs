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


/*Note: Decide what should be done when a node has null data - we should allow this or not?
 *Note: Decide what should be done when a node is created with a previous node which already have next node - replacement? Breaking the chain?*/

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

        public void Clear()
        {

            this.data = null;

            this.nextSibling = null;
            this.previousSibling = null; 

        }


        /* Constructors */

        public TransUnitNode()
        {
            data = null;

            nextSibling = null;
            previousSibling = null;

        }

        public TransUnitNode(TransUnitData transUnitData)
        {

            data = transUnitData;

            nextSibling = null;
            previousSibling = null;

        }

        public TransUnitNode(TransUnitData transUnitData, TransUnitNode previousNode)
        {

            if (previousNode.NextSibling != null)
            {
                previousNode.NextSibling.previousSibling = null;
                previousNode.NextSibling = null;

            }

            data = transUnitData;

            nextSibling = null;
            previousSibling = previousNode;

            previousNode.NextSibling = this;

        }

        public TransUnitNode(TransUnitData transUnitData, TransUnitNode previousNode, TransUnitNode nextNode)
        {

            data = transUnitData;

            nextSibling = nextNode;
            previousSibling = previousNode;

            previousNode.NextSibling = this;
            nextNode.PreviousSibling = this; 

        }

    }
}