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
using TMS_XLZ_Basic.XLZ.Xliff;

namespace TMS_XLZ_Basic
{
    public class XLF
    {

		/* Fields */

		private XmlDocument xlfDocument;

		private XmlNodeList transUnitList;

		private List<TransUnitData> transUnitDataList;
		private DoublyLinkedList transUnitDoublyLinkedList;

		private bool isParsedCorrectly;

		/* Properties */

		public XmlNodeList TransUnitList
		{
			get
			{
				return transUnitList;
			}
		}

		public List<TransUnitData> TransUnitDataList
		{
			get
			{
				return transUnitDataList;
			}
		}

		public DoublyLinkedList TransUnitDoublyLinkedList
		{
			get
			{
				return transUnitDoublyLinkedList;
			}
		}

		public bool IsParsedCorrectly
		{
			get
			{
				return isParsedCorrectly;
			}
		}

		/* Methods */

		public TransUnitNode GetTransUnitNode(int index)
		{
			return transUnitDoublyLinkedList[index];
		}

		public TransUnitData GetTransUnitData(int index)
		{
			return transUnitDoublyLinkedList[index].Data;
		}

		public TransUnitNode GetTransUnitNodeByID(int id)
		{

			TransUnitNode auxiliaryTransUnitNode = transUnitDoublyLinkedList.Tail;

			while(auxiliaryTransUnitNode != null)
			{
				if (auxiliaryTransUnitNode.Data.ID == id)
				{
					return auxiliaryTransUnitNode;
				}

				auxiliaryTransUnitNode = auxiliaryTransUnitNode.NextSibling;

			}

			return null;
		}

		public TransUnitData GetTransUnitDataByID(int id)
		{
			return GetTransUnitNodeByID(id).Data;
		}


		public TransUnitNode GetPreviousTranslatableNode(TransUnitData searchedData)
		{
			
			int searchedDataIndex = transUnitDoublyLinkedList.GetIndexOf(searchedData);
			TransUnitNode searchedNode = transUnitDoublyLinkedList[searchedDataIndex];

			TransUnitNode auxiliaryNode = null;

			if (searchedNode != transUnitDoublyLinkedList.Tail)
			{
				
				while (auxiliaryNode != null)
				{
					auxiliaryNode = searchedNode.PreviousSibling;

					if (auxiliaryNode.Data.IsTranslatable)
					{
						return auxiliaryNode;
					}
				}
			}

			return auxiliaryNode;

		}


		public TransUnitNode GetNextTranslatableNode(TransUnitData searchedData)
		{

			int searchedDataIndex = transUnitDoublyLinkedList.GetIndexOf(searchedData);
			TransUnitNode searchedNode = transUnitDoublyLinkedList[searchedDataIndex];

			TransUnitNode auxiliaryNode = null;

			if (searchedNode != transUnitDoublyLinkedList.Head)
			{

				while (auxiliaryNode != null)
				{
					auxiliaryNode = searchedNode.NextSibling;

					if (auxiliaryNode.Data.IsTranslatable)
					{
						return auxiliaryNode;
					}
				}
			}

			return auxiliaryNode;

		}

		/* Constructors */
		/* Validation of the path should be done in the XLZ class. */
		public XLF(string inputFilePath)
		{

			TransUnitData auxiliaryTransUnitData;

			transUnitDoublyLinkedList = new DoublyLinkedList();
			transUnitDataList = new List<TransUnitData>();

			xlfDocument = new XmlDocument();
			xlfDocument.Load(inputFilePath);

			if (xlfDocument.DocumentType.Value == "xliff")
			{

				transUnitList = xlfDocument.GetElementsByTagName("trans-unit");
				if (transUnitList.Count > 0) isParsedCorrectly = true;

				foreach(XmlNode transUnit in transUnitList)
				{
					auxiliaryTransUnitData = new TransUnitData(transUnit);

					/* TODO: Addd condition for well parsedness. */
					transUnitDoublyLinkedList.InsertNext(auxiliaryTransUnitData);

				}

				isParsedCorrectly = true;

			}
			
										 
		}

	}
}
