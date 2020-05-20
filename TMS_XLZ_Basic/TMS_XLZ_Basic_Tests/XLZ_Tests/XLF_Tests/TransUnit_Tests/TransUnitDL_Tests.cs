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
    public class TransUnitDL_Tests
    {

        public string xliffPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\content.xlf";


        [TestMethod]
        public void TransUnitDL_Creation_Test_1()
        {

            DoublyLinkedList testList = new DoublyLinkedList();

            Assert.AreEqual(0, testList.Count);
            Assert.IsNull(testList.FirstNode);

        }

        [TestMethod]
        public void TransUnitDL_InsertNext_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            DoublyLinkedList testList = new DoublyLinkedList();

            List<TransUnitData> transUnitDataList = new List<TransUnitData>();
            TransUnitData auxiliaryData;

            foreach(XmlNode transUnit in transUnitList)
            {
                auxiliaryData = new TransUnitData(transUnit);
                transUnitDataList.Add(auxiliaryData);
            }

            testList.InsertNext(transUnitDataList[0]);

            Assert.AreEqual(1, testList.Count);
            Assert.AreEqual(transUnitDataList[0], testList.FirstNode.Data);

            Assert.AreEqual(transUnitDataList[0], testList.GetCurrentNode.Data);
            Assert.AreEqual(transUnitDataList[0], testList[0].Data);

        }

        [TestMethod]
        public void TransUnitDL_InsertNext_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            DoublyLinkedList testList = new DoublyLinkedList();

            List<TransUnitData> transUnitDataList = new List<TransUnitData>();
            TransUnitData auxiliaryData;

            foreach (XmlNode transUnit in transUnitList)
            {
                auxiliaryData = new TransUnitData(transUnit);
                transUnitDataList.Add(auxiliaryData);
            }

            testList.InsertNext(transUnitDataList[0]);
            testList.InsertNext(transUnitDataList[1]);

            Assert.AreEqual(2, testList.Count);
            Assert.AreEqual(transUnitDataList[0], testList.FirstNode.Data);

            Assert.AreEqual(transUnitDataList[1], testList.GetCurrentNode.Data);
            Assert.AreEqual(transUnitDataList[0], testList[0].Data);
            Assert.AreEqual(transUnitDataList[1], testList[1].Data);

        }

        [TestMethod]
        public void TransUnitDL_InsertNext_Test_3()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            DoublyLinkedList testList = new DoublyLinkedList();

            List<TransUnitData> transUnitDataList = new List<TransUnitData>();
            TransUnitData auxiliaryData;

            foreach (XmlNode transUnit in transUnitList)
            {
                auxiliaryData = new TransUnitData(transUnit);
                transUnitDataList.Add(auxiliaryData);
            }

            testList.InsertNext(transUnitDataList[5]);
            testList.InsertNext(transUnitDataList[0]);
            testList.InsertNext(transUnitDataList[3]);
            testList.InsertNext(transUnitDataList[2]);
            testList.InsertNext(transUnitDataList[5]);
            testList.InsertNext(transUnitDataList[1]);

            Assert.AreEqual(6, testList.Count);

            Assert.AreEqual(transUnitDataList[5], testList.FirstNode.Data);
            Assert.AreEqual(transUnitDataList[1], testList.GetCurrentNode.Data);

            Assert.AreEqual(transUnitDataList[5], testList[0].Data);
            Assert.AreEqual(transUnitDataList[0], testList[1].Data);
            Assert.AreEqual(transUnitDataList[3], testList[2].Data);
            Assert.AreEqual(transUnitDataList[2], testList[3].Data);
            Assert.AreEqual(transUnitDataList[5], testList[4].Data);
            Assert.AreEqual(transUnitDataList[1], testList[5].Data);

        }

        [TestMethod]
        public void TransUnitDL_InsertPrevious_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            DoublyLinkedList testList = new DoublyLinkedList();

            List<TransUnitData> transUnitDataList = new List<TransUnitData>();
            TransUnitData auxiliaryData;

            foreach (XmlNode transUnit in transUnitList)
            {
                auxiliaryData = new TransUnitData(transUnit);
                transUnitDataList.Add(auxiliaryData);
            }


            testList.InsertPrevious(transUnitDataList[2]);

            Assert.AreEqual(1, testList.Count);

            Assert.AreEqual(transUnitDataList[2], testList.FirstNode.Data);
            Assert.AreEqual(transUnitDataList[2], testList.GetCurrentNode.Data);

            Assert.AreEqual(transUnitDataList[2], testList[0].Data);

        }


        [TestMethod]
        public void TransUnitDL_InsertPrevious_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            DoublyLinkedList testList = new DoublyLinkedList();

            List<TransUnitData> transUnitDataList = new List<TransUnitData>();
            TransUnitData auxiliaryData;

            foreach (XmlNode transUnit in transUnitList)
            {
                auxiliaryData = new TransUnitData(transUnit);
                transUnitDataList.Add(auxiliaryData);
            }

            testList.InsertNext(transUnitDataList[0]);
            testList.InsertNext(transUnitDataList[1]);
            testList.InsertPrevious(transUnitDataList[2]);

            Assert.AreEqual(3, testList.Count);

            Assert.AreEqual(transUnitDataList[0], testList.FirstNode.Data);
            Assert.AreEqual(transUnitDataList[1], testList.GetCurrentNode.Data);
            
            Assert.AreEqual(transUnitDataList[0], testList[0].Data);
            Assert.AreEqual(transUnitDataList[2], testList[1].Data);
            Assert.AreEqual(transUnitDataList[1], testList[2].Data);

        }

        [TestMethod]
        public void First_Test_01()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstData = new TransUnitData(transUnitList[0]);
            TransUnitData secondData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdData = new TransUnitData(transUnitList[2]);

            DoublyLinkedList list = new DoublyLinkedList();
            TransUnitNode nd = list.InsertNext(firstData);
            Assert.IsNull(nd.PreviousSibling);

            list.InsertNext(secondData);

            Assert.AreEqual(firstData.ID, list.FirstNode.Data.ID);
            Assert.AreEqual(secondData.ID, list.FirstNode.NextSibling.Data.ID);

            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(list[1].Data.ID, secondData.ID);

            list.InsertPrevious(thirdData);
            Assert.AreEqual(thirdData.ID, list.FirstNode.NextSibling.Data.ID);
        }

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
