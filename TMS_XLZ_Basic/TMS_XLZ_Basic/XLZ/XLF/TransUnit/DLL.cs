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

/*TODO: Make this doubly linked list to be that universal to work with Xliff as well as with Skl and XLZ. */

/*Note: Thinking if the head node should be rechanged after any operation to it's initial state.*/

namespace TMS_XLZ_Basic.XLZ.Xliff
{
    public class DLL
    {
        /* Fields */

        private TransUnitNode head;
        private TransUnitNode tail;

        private int count;

        /* Properties */

        public TransUnitNode Tail
        {
            get
            {
                return tail;
            }
        }

        public TransUnitNode Head
        {
            get
            {
                return head;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public TransUnitNode this[int index]
        {
            get
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Out of range exception.");
                }

                TransUnitNode currentNode = this.tail;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextSibling;
                }

                return currentNode;
            }
            set
            {
                if (index >= count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Out of range exception.");
                }

                TransUnitNode currentNode = this.tail;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextSibling;
                }

                currentNode = value;
            }
        }

        /* Methods */

        public TransUnitNode InsertNext(TransUnitData newNodeData)
        {

            TransUnitNode newNode;

            if (head != null)
            {
                newNode = new TransUnitNode(newNodeData, head);

                if(head.NextSibling == null)
                {
                    head = newNode;
                }

            }
            else
            {
                newNode = new TransUnitNode(newNodeData);
                head = newNode;
            }            

            if (tail == null)
            {
                tail = newNode;
            }

            count++;

            return newNode;

        }

        public TransUnitNode InsertPrevious(TransUnitData newNodeData)
        {

            TransUnitNode newNode;

            if (head != null)
            {
                if (head.PreviousSibling != null)
                {
                    newNode = new TransUnitNode(newNodeData, head.PreviousSibling);
                }
                else
                {
                    newNode = new TransUnitNode(newNodeData);

                    newNode.NextSibling = head;
                    head.PreviousSibling = newNode;

                    tail = newNode;
                }
            }
            else
            {
                newNode = new TransUnitNode(newNodeData);

                tail = newNode;
                head = newNode;
            }
            

            count++;

            return newNode;

        }


        public void Clear()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        /* Constructors */

        public DLL()
        {
            head = null;
            tail = null;

            count = 0;
        }



    }
}
