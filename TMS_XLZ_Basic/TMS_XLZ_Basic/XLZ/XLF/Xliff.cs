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
    class Xliff
    {

		/* Fields */

		private XmlDocument baseDocument;

		private XmlNodeList transUnitList;
		private DLL doublyLinkedList; 


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

		public Xliff(XmlDocument inputFile)
		{
			/*baseDocument = inputFile;

			transUnitList = inputFile.GetElementsByTagName("trans-unit");

			listOfTransUnitObjects = new List<TransUnit>();
			TransUnit auxillaryTransUnit;

			foreach(XmlNode en in transUnitList)
			{
				auxillaryTransUnit = new TransUnit(en);
				listOfTransUnitObjects.Add(auxillaryTransUnit);
				auxillaryTransUnit = null;
			}

			transUnitTranslationYesList = new List<TransUnit>();
			transUnitTranslationNoList = new List<TransUnit>();

			foreach (TransUnit en in listOfTransUnitObjects)
			{
				if(en.IsTranslatable())
				{
					transUnitTranslationYesList.Add(en);
				}
				else
				{
					transUnitTranslationNoList.Add(en);
				}
			}*/
										 
		}

	}
}
