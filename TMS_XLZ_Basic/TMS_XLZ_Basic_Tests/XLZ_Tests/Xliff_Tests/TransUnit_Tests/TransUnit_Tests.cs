using System.CodeDom.Compiler;
using TMS_XLZ_Basic;
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
using System.Threading;
using System.Text.RegularExpressions;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;
using TMS_XLZ_Basic.XLZ.Xliff;

namespace TMS_XLZ_Basic_Tests
{
    [TestClass]
    public class TransUnit_Tests
    {

        public string xliffPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\content.xlf";

        [TestMethod]
        public void First_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstData = new TransUnitData(transUnitList[0]);

            TransUnitNode firstNode = new TransUnitNode(firstData);
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            TransUnitNode firstLinkedNode = doublyLinkedList.InsertNext(firstData);

            TransUnitData secondData = new TransUnitData(transUnitList[1]);
            TransUnitNode secondNode = doublyLinkedList.InsertNext(secondData);

            DoublyLinkedList newlinkedList = new DoublyLinkedList();

            TransUnitData tempData;
            TransUnitNode tempNode;

            foreach(XmlNode node in transUnitList)
            {
                tempData = new TransUnitData(node);
                newlinkedList.InsertNext(tempData);
            }


            Assert.AreEqual(secondNode, firstLinkedNode.NextSibling);
            Assert.AreEqual("<source><bpt id=\"1\">&lt;AlternateContent&gt;</bpt><ph id=\"2\">&lt;Choice/&gt;</ph></source>",
                            newlinkedList.FirstNode.Data.SourceNode.OuterXml);

            

        }
    }
}
