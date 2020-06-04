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

/*TODO: Make this doubly linked list to be that universal to work with Xliff as well as with Skl and XLZ.
 *TODO: Change InsertNext(), InsertPrevious() etc. to return TransUnitNode, not to be void methods.
 *TODO: InsertAtIndex should return TransUnitNode as InsertNext and InsertPrevious do. 
 *TODO: Methods like GetPreviousTranslatableNode or so, should be created within XLF class for DLL to be most universal and for us to reuse it in 
 *SKL and in XLZ classes. 
 *TODO: Use this[index] set in cases when it can shorten the code.*/

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
                if (index > count || index < 0)
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
                if (index > count || index < 0)
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

                if (head.NextSibling == null)
                {
                    newNode = new TransUnitNode(newNodeData, head);
                    head = newNode;
                }
                else
                {
                    newNode = new TransUnitNode(newNodeData, head, head.NextSibling);
                    while(head.NextSibling != null)
                    {
                        head = head.NextSibling;
                    }
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
                    newNode = new TransUnitNode(newNodeData, head.PreviousSibling, head);
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

        /* Returns first occurance of the search data */
        public int GetIndexOf(TransUnitData searchData)
        {
            int index = 0;
            TransUnitNode searchNode = tail;

            for(int i = 0; i < count; i++)
            {
                if(searchNode != null)
                {
                    if (searchNode.Data == searchData)
                    {
                        return index;
                    }

                    searchNode = searchNode.NextSibling;
                    index++;
                }
            }

            return -1;

        }

        public int GetIndexOf(TransUnitNode searchNode)
        {
            return GetIndexOf(searchNode.Data);
        }

        public void InsertAtIndex(TransUnitData newItemData, int index)
        {

            TransUnitNode temporaryHead = head;

            if (index > count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Out of range exception.");
            }
            
            if (this[index] != null)
            {
                if (this[index].PreviousSibling != null)
                {
                    this.head = this[index].PreviousSibling;
                    this.InsertNext(newItemData);

                    head = temporaryHead;
                }
                else
                {
                    this.head = this[index];
                    this.InsertPrevious(newItemData);

                    head = temporaryHead;
                }
            }
            else
            {
                this.InsertNext(newItemData);
            }          
        }

        /*public TransUnitNode Remove()
        {

            TransUnitNode temp = head;

            if (head != null)
            {
                head.PreviousSibling.NextSibling = head.NextSibling;
                head = temp.PreviousSibling;

                count--;
            }

            return temp;

        }*/

        public TransUnitNode Remove()
        {

            TransUnitNode transUnitNode = head;

            if (head != null)
            {
                
                if (head.PreviousSibling != null && head.NextSibling != null)
                {

                    head.NextSibling.PreviousSibling = head.PreviousSibling;
                    head.PreviousSibling.NextSibling = head.NextSibling;

                    while(head.NextSibling != null)
                    {
                        head = head.NextSibling;
                    }
                    
                    count--;

                }
                else if (head.PreviousSibling != null && head.NextSibling == null)
                {

                    head.PreviousSibling.NextSibling = head.NextSibling;
                    head = head.PreviousSibling;

                    count--;

                }
                else if (head.PreviousSibling == null && head.NextSibling != null)
                {

                    head.NextSibling.PreviousSibling = head.PreviousSibling;
                    tail = head;

                    while (head.NextSibling != null)
                    {
                        head = head.NextSibling;
                    }

                    count--;

                }
                else
                {

                    head = null;
                    tail = null;

                    count--;

                }

            }

            return transUnitNode;
        }

        public TransUnitNode RemoveAtIndex(int index)
        {

            TransUnitNode transUnitNode;
            TransUnitNode temp = head;

            if (this[index] != null)
            {
                if (this[index] != head)
                {
                    head = this[index];
                    transUnitNode = this.Remove();

                    head = temp;
                    return transUnitNode;
                }
                else
                {
                    transUnitNode = this.Remove();
                    return transUnitNode;

                }

            }
            else
            {
                return null;
            }

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
