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

namespace TMS_XLZ_Basic.XLZ.Xliff
{
    public class DoublyLinkedList
    {
        /* Fields */

        private TransUnitNode head;

        private TransUnitNode firstNode;
        private TransUnitNode lastNode; 

        /* Properties */

        public TransUnitNode FirstNode
        {
            get
            {
                return firstNode;
            }
        }

        /* Methods */

        public TransUnitNode InsertNext(TransUnitData newData)
        {

            TransUnitNode newTransUnitNode = new TransUnitNode(newData);

            newTransUnitNode.PreviousSibling = head;
            newTransUnitNode.NextSibling = head.NextSibling;

            if(head != null)
            {
                head.NextSibling = newTransUnitNode;
            }

            head = newTransUnitNode;

            if(firstNode == null)
            {
                firstNode = newTransUnitNode;
            }

            return newTransUnitNode;

        }

        public TransUnitNode Delete()
        {
            TransUnitNode temp = head;

            if(head != null)
            {
                head = head.PreviousSibling;
                if(head != null)
                {
                    head.NextSibling = temp.NextSibling;
                }
            }

            return temp;
        }

        public TransUnitNode GetPreviousTranslatableNode(TransUnitNode referrenceNode)
        {
            while(referrenceNode.PreviousSibling != null)
            {
                if(referrenceNode.PreviousSibling.Data.IsTranslatable)
                {
                    return referrenceNode.PreviousSibling;
                }

                referrenceNode = referrenceNode.PreviousSibling;
            }
            
            return null;
        }

        /* Constructors */

        public DoublyLinkedList()
        {
            head = null;

            firstNode = null;
            lastNode = null;
        }



    }
}
