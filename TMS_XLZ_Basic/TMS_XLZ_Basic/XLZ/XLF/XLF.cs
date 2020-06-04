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
		private DoublyLinkedList doublyLinkedList;

		private bool isParsedCorrectly;


		/* Methods */

		/*public XmlNode GetNodeByID(int transUnitID)
		{
			foreach(XmlNode ent in transUnitList)
			{
				if(Int32.Parse(ent.Attributes["id"].Value) == transUnitID)
				{
					return ent;
				}
			}

			return null;
		}*/

		/*public TransUnit GetTransUnitByID(int transUnitID)
		{
			foreach (TransUnit ent in listOfTransUnitObjects)
			{
				if ((ent.GetTransUnitID()) == transUnitID)
				{
					return ent;
				}
			}

			return null;
		}*/


		/* This method will return the source node of the given trans-unit node. */

		/*private XmlNode GetSourceNode(XmlNode transUnitNode)
		{

			return transUnitNode.SelectSingleNode("./source");

		}*/

		/* This method will return the target node of the given trans-unit node. */

		/*private XmlNode GetTargetNode(XmlNode transUnitNode)
		{

			return transUnitNode.SelectSingleNode("/target");

		}


		/* Constructors */
		/* Validation of the path should be done in the XLZ class. */
		public XLF(string inputFilePath)
		{

			TransUnitData auxiliaryTransUnitData;

			doublyLinkedList = new DoublyLinkedList();
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
					doublyLinkedList.InsertNext(auxiliaryTransUnitData);

				}

				isParsedCorrectly = true;

			}
			
										 
		}

	}
}
