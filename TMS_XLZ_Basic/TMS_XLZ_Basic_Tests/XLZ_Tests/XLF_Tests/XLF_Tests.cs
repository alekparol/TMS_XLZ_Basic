using TMS_XLZ_Basic;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS_XLZ_Basic.XLZ.Xliff;
using System;
using System.IO;
using System.Linq;

namespace TMS_XLZ_Basic_Tests.XLZ_Tests.XLF_Tests
{

    /* NOTE: I found out that XLF documents do not necessarily contains trans-unit segments with ID field filled with a number. Sometimes, for example we 
     * can find segments like: 
     <trans-unit translate="yes" id="document.xml.3">
				<source>https://connect.otis.com/Documents/Yammer Etiquette and Use Guide_Final.pdf</source>
	 </trans-unit>
     * Also after inquiery, it look like the segment 
     <trans-unit translate="no" id="13">
		        <target>gt</target>
	 </trans-unit>
     * is also null. EDIT: This was solved by deleting isNotWellFormed and parsingSuccess intiliatization in TransUnitData class.*/

    [TestClass]
    public class XLF_Tests
    {

        public string xliffPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\content.xlf";
        public string xliffPath2 = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\Nowy folder\content.xlf";
        public string xliffPath3 = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\Nowy folder2\content.xlf";

        [TestMethod]
        public void XLF_Constructor_Xliff1_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            /* Set of Assertions. */

            Assert.IsTrue(testXLF.IsParsedCorrectly); // As count of trans unit is different that count of doulbyLinkedList and because one of the elements is null. 
            Assert.AreEqual(169, testXLF.TransUnitDataList.Count);
            Assert.AreEqual(169, testXLF.TransUnitDoublyLinkedList.Count);

        }

        [TestMethod]
        public void XLF_Constructor_Xliff2_Test_2()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath2);
            XLF testXLF = new XLF(xlfDocument);

            /* Set of Assertions. */

            Assert.IsTrue(testXLF.IsParsedCorrectly);
            Assert.AreEqual(169, testXLF.TransUnitDataList.Count);
            Assert.AreEqual(169, testXLF.TransUnitDoublyLinkedList.Count);

        }

        [TestMethod]
        public void XLF_Constructor_Xliff3_Test_3()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath3);
            XLF testXLF = new XLF(xlfDocument);

            /* Set of Assertions. */

            Assert.IsTrue(testXLF.IsParsedCorrectly);
            Assert.AreEqual(125, testXLF.TransUnitDataList.Count);
            Assert.AreEqual(125, testXLF.TransUnitDoublyLinkedList.Count);

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff1_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(1);

            /* Set of Assertions. */

            Assert.AreEqual(1, auxiliaryTransUnitNode.Data.ID);
            
        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff1_Test_2()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(0);

            /* Set of Assertions. */

            Assert.IsNull(auxiliaryTransUnitNode);

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff1_Test_3()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            int doublyLinkedListCount = testXLF.TransUnitDoublyLinkedList.Count;
            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNode(106);

            /* Set of Assertions. */

            Assert.AreEqual("document.xml.3", auxiliaryTransUnitNode.Data.GeneralID);
            Assert.AreEqual(-1, auxiliaryTransUnitNode.Data.ID);
            //Assert.IsNotNull(auxiliaryTransUnitNode);
            //Assert.AreEqual(doublyLinkedListCount, auxiliaryTransUnitNode.Data.ID);
            //Assert.AreEqual(testXLF.TransUnitDoublyLinkedList.Head, auxiliaryTransUnitNode);

        }


        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff1_Test_4()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode;

            /* Set of Assertions. */

            for (int i = 1; i < testXLF.TransUnitDoublyLinkedList.Count; i++)
            {
                auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(i);

                if (auxiliaryTransUnitNode == null)
                {
                    Assert.Fail("Trans Unit node of id = {0} is null.", i);
                }
                Assert.AreEqual(i, auxiliaryTransUnitNode.Data.ID);
            }
        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff2_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath2);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(1);

            /* Set of Assertions. */

            Assert.AreEqual(1, auxiliaryTransUnitNode.Data.ID);

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff2_Test_2()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath2);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(0);

            /* Set of Assertions. */

            Assert.IsNull(auxiliaryTransUnitNode);

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff2_Test_3()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath2);
            XLF testXLF = new XLF(xlfDocument);

            int doublyLinkedListCount = testXLF.TransUnitDoublyLinkedList.Count;
            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(doublyLinkedListCount);

            /* Set of Assertions. */

            Assert.IsNotNull(auxiliaryTransUnitNode);
            Assert.AreEqual(doublyLinkedListCount, auxiliaryTransUnitNode.Data.ID);
            Assert.AreEqual(testXLF.TransUnitDoublyLinkedList.Head, auxiliaryTransUnitNode);

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff2_Test_4()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath2);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode;

            /* Set of Assertions. */

            for (int i = 1; i < testXLF.TransUnitDoublyLinkedList.Count; i++)
            {
                auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(i);

                if (auxiliaryTransUnitNode == null)
                {
                    Assert.Fail("Trans Unit node of id = {0} is null.", i);
                }
                Assert.AreEqual(i, auxiliaryTransUnitNode.Data.ID);
            }
        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff3_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath3);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(1);

            /* Set of Assertions. */

            Assert.AreEqual(1, auxiliaryTransUnitNode.Data.ID);

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff3_Test_2()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath3);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(0);

            /* Set of Assertions. */

            Assert.IsNull(auxiliaryTransUnitNode);

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff3_Test_3()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath3);
            XLF testXLF = new XLF(xlfDocument);

            int doublyLinkedListCount = testXLF.TransUnitDoublyLinkedList.Count;
            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(doublyLinkedListCount);

            /* Set of Assertions. */

            Assert.IsNotNull(auxiliaryTransUnitNode);
            Assert.AreEqual(doublyLinkedListCount, auxiliaryTransUnitNode.Data.ID);
            Assert.AreEqual(testXLF.TransUnitDoublyLinkedList.Head, auxiliaryTransUnitNode);

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Xliff3_Test_4()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath3);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode;

            /* Set of Assertions. */

            for (int i = 1; i < testXLF.TransUnitDoublyLinkedList.Count; i++)
            {
                auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(i);

                if (auxiliaryTransUnitNode == null)
                {
                    Assert.Fail("Trans Unit node of id = {0} is null.", i);
                }
                Assert.AreEqual(i, auxiliaryTransUnitNode.Data.ID);
            }
        }

        [TestMethod]
        public void XLF_GetPreviousTranslatableNode_Xliff1_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(10);
            TransUnitNode previousTranslatableNode = testXLF.GetPreviousTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsTrue(previousTranslatableNode.Data.IsTranslatable);
            Assert.AreEqual(9, previousTranslatableNode.Data.ID);

        }

        [TestMethod]
        public void XLF_GetPreviousTranslatableNode_Xliff1_Test_2()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(8);
            TransUnitNode previousTranslatableNode = testXLF.GetPreviousTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsNull(previousTranslatableNode);

        }

        [TestMethod]
        public void XLF_GetPreviousTranslatableNode_Xliff2_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath2);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(10);
            TransUnitNode previousTranslatableNode = testXLF.GetPreviousTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsTrue(previousTranslatableNode.Data.IsTranslatable);
            Assert.AreEqual(9, previousTranslatableNode.Data.ID);

        }

        [TestMethod]
        public void XLF_GetPreviousTranslatableNode_Xliff2_Test_2()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath2);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(8);
            TransUnitNode previousTranslatableNode = testXLF.GetPreviousTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsNull(previousTranslatableNode);

        }

        [TestMethod]
        public void XLF_GetPreviousTranslatableNode_Xliff3_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath3);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(10);
            TransUnitNode previousTranslatableNode = testXLF.GetPreviousTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsTrue(previousTranslatableNode.Data.IsTranslatable);
            Assert.AreEqual(1, previousTranslatableNode.Data.ID);

        }

        [TestMethod]
        public void XLF_GetPreviousTranslatableNode_Xliff3_Test_2()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath3);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(1);
            TransUnitNode previousTranslatableNode = testXLF.GetPreviousTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsNull(previousTranslatableNode);

        }

        [TestMethod]
        public void XLF_GetPreviousTranslatableNode_Universal_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = null;
            TransUnitNode previousTranslatableNode = testXLF.GetPreviousTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsNull(previousTranslatableNode);

        }

        [TestMethod]
        public void XLF_GetNextTranslatableNode_Xliff1_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(10);
            TransUnitNode nextTranslatableNode = testXLF.GetNextTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsTrue(nextTranslatableNode.Data.IsTranslatable);
            Assert.AreEqual(12, nextTranslatableNode.Data.ID);

        }

        [TestMethod]
        public void XLF_GetNextTranslatableNode_Xliff1_Test_2()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(165);
            TransUnitNode nextTranslatableNode = testXLF.GetNextTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsNull(nextTranslatableNode);

        }

        [TestMethod]
        public void XLF_GetNextTranslatableNode_Xliff2_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath2);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(10);
            TransUnitNode nextTranslatableNode = testXLF.GetNextTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsTrue(nextTranslatableNode.Data.IsTranslatable);
            Assert.AreEqual(12, nextTranslatableNode.Data.ID);

        }

        [TestMethod]
        public void XLF_GetNextTranslatableNode_Xliff2_Test_2()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath2);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(165);
            TransUnitNode nextTranslatableNode = testXLF.GetNextTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsNull(nextTranslatableNode);

        }

        [TestMethod]
        public void XLF_GetNextTranslatableNode_Xliff3_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath3);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(1);
            TransUnitNode nextTranslatableNode = testXLF.GetNextTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsTrue(nextTranslatableNode.Data.IsTranslatable);
            Assert.AreEqual(10, nextTranslatableNode.Data.ID);

        }

        [TestMethod]
        public void XLF_GetNextTranslatableNode_Xliff1_Test_3()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath3);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(125);
            TransUnitNode nextTranslatableNode = testXLF.GetNextTranslatableNode(auxiliaryTransUnitNode);

            /* Set of Assertions. */

            Assert.IsNull(nextTranslatableNode);

        }


    }
}
