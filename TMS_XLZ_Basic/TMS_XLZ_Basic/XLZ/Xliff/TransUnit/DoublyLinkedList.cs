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
    public class DoublyLinkedList
    {
        /* Fields */

        private TransUnitNode head;
        private TransUnitNode tail;

        private TransUnitNode firstNode;

        private int count; 

        /* Properties */

        public TransUnitNode FirstNode
        {
            get
            {
                return firstNode;
            }
        }

        public TransUnitNode GetCurrentNode
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

                TransUnitNode currentNode = this.firstNode;

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

                TransUnitNode currentNode = this.firstNode;

                for (int i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextSibling;
                }

                currentNode = value;
            }
        }

        /* Methods */

        /*Methods that we need:
         * - TransUnitNode InsertNext(TransUnitData newData)
         * - TransUnitNode InsertPrevious(TransUnitData newData)
         * - TransUnitNode InsertAtIndex(TransUnitData newData, int index)
         * - TransUnitNode GetNodeByID(int iD)
         * - 
         * 
         **/

        public TransUnitNode InsertNext(TransUnitData newData)
        {

            TransUnitNode newTransUnitNode = new TransUnitNode(newData);

            newTransUnitNode.PreviousSibling = head;
            newTransUnitNode.NextSibling = null;

            if(head != null)
            {
                if(head.NextSibling != null)
                {
                    newTransUnitNode.NextSibling = head.NextSibling;
                }
                head.NextSibling = newTransUnitNode;
            }

            head = newTransUnitNode;

            if(firstNode == null)
            {
                firstNode = newTransUnitNode;
            }

            count++;
            return newTransUnitNode;

        }

        public TransUnitNode InsertPrevious(TransUnitData newData)
        {

            TransUnitNode newTransUnitNode = new TransUnitNode(newData);

            if(head != null)
            {
                if (head.PreviousSibling != null)
                {
                    head.PreviousSibling.NextSibling = newTransUnitNode;

                    newTransUnitNode.PreviousSibling = head.PreviousSibling;
                    newTransUnitNode.NextSibling = head;

                    head.PreviousSibling = newTransUnitNode;
                }
            }            
            else
            {
                head = newTransUnitNode;
                if(firstNode == null)
                {
                    firstNode = head;
                }
            }
          
            count++;
            return newTransUnitNode;

        }

        public int GetIndexOf(TransUnitData searchData)
        {

            int index = 0;
            TransUnitNode counter = this.FirstNode;

            while (counter != null)
            {
                if (((counter.Data != null) && (searchData == counter.Data)) ||
                ((counter.Data == null) && (searchData == null)))
                {
                    return index;
                }

                index++;
                counter = counter.NextSibling;
            }

            return -1;
        }

        public int GetIndexOf(TransUnitNode searchNode)
        {
            return GetIndexOf(searchNode.Data);
        }

        /* Index of the node in the list should be n-1 where n is the ID of the node's data. But for now we should take them separately
         * and then use this information and both functions to validate the list. 
         * */

        public TransUnitNode GetNodeByID(int iD)
        {
            TransUnitNode counter = firstNode;

            while (counter != null)
            {
                if (counter.Data.ID == iD)
                {
                    return counter;
                }

                counter = counter.NextSibling;
            }

            return null;
        }



        public void InsertAtIndex(TransUnitData newItemData, int index)
        {
            
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Out of range exception.");
            }

            head = this[index].PreviousSibling;
            InsertNext(newItemData);

        }

        /*public void Remove(object item)
        {
            int currentIndex = 0;
            DoublyLinkedListNode currentItem = this.head;
            DoublyLinkedListNode prevItem = null;
            while (currentItem != null)
            {
                if ((currentItem.Element != null &&
                currentItem.Element.Equals(item)) ||
                (currentItem.Element == null) && (item == null))
                {
                    break;
                }
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }
            if (currentItem != null)
            {
                count--;
                if (count == 0)
                {
                    this.head = null;
                }
                else if (prevItem == null)
                {
                    this.head = currentItem.Next;
                    this.head.Previous = null;
                }
                else if (currentItem == tail)
                {
                    currentItem.Previous.Next = null;
                    this.tail = currentItem.Previous;
                }
                else
                {
                    currentItem.Previous.Next = currentItem.Next;
                    currentItem.Next.Previous = currentItem.Previous;
                }
            }
        }*/

        public TransUnitNode Delete()
        {
            TransUnitNode temp = head;

            if (head != null)
            {
                head = head.PreviousSibling;
                if (head != null)
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
   
        public void Add(TransUnitData item)
        {
            if (this.head == null)
            {
                this.head = new TransUnitNode(item);
                this.tail = this.head;
            }
            else
            {
                TransUnitNode newItem = new TransUnitNode(item, tail);

                /*I think here should be "head" to be consistent with our interpretation of the doubly linked list. */
                this.head = newItem;
            }

            count++;
        }



        /*public void Remove(object item)
        {
            int currentIndex = 0;
            DoublyLinkedListNode currentItem = this.head;
            DoublyLinkedListNode prevItem = null;
            while (currentItem != null)
            {
                if ((currentItem.Element != null &&
                currentItem.Element.Equals(item)) ||
                (currentItem.Element == null) && (item == null))
                {
                    break;
                }
                prevItem = currentItem;
                currentItem = currentItem.Next;
                currentIndex++;
            }
            if (currentItem != null)
            {
                count--;
                if (count == 0)
                {
                    this.head = null;
                }
                else if (prevItem == null)
                {
                    this.head = currentItem.Next;
                    this.head.Previous = null;
                }
                else if (currentItem == tail)
                {
                    currentItem.Previous.Next = null;
                    this.tail = currentItem.Previous;
                }
                else
                {
                    currentItem.Previous.Next = currentItem.Next;
                    currentItem.Next.Previous = currentItem.Previous;
                }
            }

            public void RemoveAt(int index)
            {
                if (index >= this.count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Out of range!");
                }

                int currentIndex = 0;
                DoublyLinkedListNode currentItem = this.head;
                DoublyLinkedListNode prevItem = null;
                while (currentIndex < index)
                {
                    prevItem = currentItem;
                    currentItem = currentItem.Next;
                    currentIndex++;
                }
                if (this.count == 0)
                {
                    this.head = null;
                }
                else if (prevItem == null)
                {
                    this.head = currentItem.Next;
                    this.head.Previous = null;
                }
                else if (index == count - 1)
                {
                    prevItem.Next = currentItem.Next;
                    tail = prevItem;
                    currentItem = null;
                }
                else
                {
                    prevItem.Next = currentItem.Next;
                    currentItem.Next.Previous = prevItem;
                }
                count--;
            }



            public bool Contains(object element)
            {
                int index = indexOf(element);
                bool contains = (index != -1);
                return contains;
            }*/

            public void Clear()
            {
                this.head = null;
                this.tail = null;
                this.count = 0;
            }

            /* Constructors */

            public DoublyLinkedList()
             {
                head = null;
                tail = null;

                firstNode = null;

                count = 0;
            }



    }
}
