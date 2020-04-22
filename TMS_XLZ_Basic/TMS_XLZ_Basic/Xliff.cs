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

namespace TMS_XLZ_Basic
{
    class Xliff
    {

		/* Fields */

		public XmlNodeList transUnitList;

		//public XmlNodeList transUnitTranslationYesList;
		//public XmlNodeList transUnitTranslationNoList;

		public XmlNodeList sourceNodesList;
		public XmlNodeList targetNodesList;

		/* Methods */

		/* This method will return ID of the segment which could be different than its order on the transUnitList. */

		public int GetTransUnitID(int transUnitListElementNumber)
		{

			bool success = Int32.TryParse(transUnitList[transUnitListElementNumber].Attributes["id"].Value,out int transUnitID);
			
			if(success)
			{
				return -1;
			}
			else
			{
				return transUnitID;
			}

		}

		public int GetTransUnitID(XmlNode transUnitNode)
		{
			bool success = Int32.TryParse(transUnitNode.Attributes["id"].Value, out int transUnitID);

			if (success)
			{
				return -1;
			}
			else
			{
				return transUnitID;
			}
		}

		public XmlNode GetTransUnitByID(int transUnitID)
		{
			foreach(XmlNode ent in transUnitList)
			{
				if(Int32.Parse(ent.Attributes["id"].Value) == transUnitID)
				{
					return ent;
				}
			}

			return null;
		}

		/* This method will check the value of the attribute "translate" in the trans-unit node. */ 

		public bool IfTransUnitIsTranslatable(int transUnitID)
		{
			if(transUnitList.Item(transUnitID).Attributes["translate"].Value == "no")
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		/* This method will return the source node of the given trans-unit node. */

		public XmlNode GetSourceNode(XmlNode transUnitNode)
		{
			/* Check if everything is on its place - transunitnode is named trans-unit, and if it has any child nodes.*/

			return transUnitNode.SelectSingleNode("/source");

		}

		/* This method will return the target node of the given trans-unit node. */

		public XmlNode GetTargetNode(XmlNode transUnitNode)
		{
			/* Check if everything is on its place - transunitnode is named trans-unit, and if it has any child nodes.*/

			return transUnitNode.SelectSingleNode("/target");

		}


		/* This method will return the inner text of the source node. */

		public string GetSourceText(int transUnitID)
		{

			XmlNode sourceNode = GetSourceNode(transUnitList.Item(transUnitID));
			return sourceNode.InnerText;

		}

		/* This method will return the inner text of the target node. */

		public string GetTargetText(int transUnitID)
		{

			XmlNode targetNode = GetTargetNode(transUnitList.Item(transUnitID));
			return targetNode.InnerText;

		}

		public Xliff(XmlDocument inputFile)
		{
			transUnitList = inputFile.GetElementsByTagName("trans-unit");
			/*List<XmlNode> transUnitTranslationNoList = new List<XmlNode>();
			List<XmlNode> transUnitTranslationYesList = new List<XmlNode>();
			foreach(XmlNode en in transUnitList)
			{
				int i = GetTransUnitID(en);
				if(IfTransUnitIsTranslatable(i))
				{
					transUnitTranslationNoList.Add(en);
				}
				else
				{
					transUnitTranslationYesList.Add(en);
				}
			}*/
										 
		}

	}
}
