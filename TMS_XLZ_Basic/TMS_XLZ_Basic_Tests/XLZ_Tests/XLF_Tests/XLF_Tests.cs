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
     * is also null. */

    [TestClass]
    public class XLF_Tests
    {

        public string xliffPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\content.xlf";
        public string xliffPath2 = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\Nowy folder\content.xlf";
        [TestMethod]
        public void XLF_Constructor_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            /* Set of Assertions. */

            Assert.IsTrue(testXLF.IsParsedCorrectly);
            Assert.AreNotEqual(0, testXLF.TransUnitDataList.Count);
            Assert.AreNotEqual(0, testXLF.TransUnitDoublyLinkedList.Count);

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Test_1()
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
        public void XLF_GetTransUnitNodeByID_Test_2()
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
        public void XLF_GetTransUnitNodeByID_Test_3()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode;

            /* Set of Assertions. */

            for(int i = 1; i < testXLF.TransUnitDoublyLinkedList.Count; i++)
            {
                auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(i);

                if (auxiliaryTransUnitNode == null)
                {
                    Assert.AreEqual(0, i);
                }

                Assert.AreEqual(i, auxiliaryTransUnitNode.Data.ID);

            }

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Test_3_13()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode;

            /* Set of Assertions. */

            //auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(13);
            TransUnitData auxiliaryTransUnitData = testXLF.TransUnitDataList.First(x => x.ID == 13);
            
            Assert.AreEqual(13, auxiliaryTransUnitData.ID);

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Test_4()
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
                    Assert.AreEqual(0, i);
                }

                Assert.AreEqual(i, auxiliaryTransUnitNode.Data.ID);

            }

        }

        [TestMethod]
        public void XLF_GetTransUnitNodeByID_Test_5()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            int doublyLinnkedListCount = testXLF.TransUnitDataList.Count;

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(doublyLinnkedListCount);

            /* Set of Assertions. */

            //Assert.AreEqual(1, doublyLinnkedListCount);
            Assert.IsTrue(testXLF.TransUnitDataList.Where(x => x.ID == testXLF.TransUnitDataList.Count).Count() == 1);

        }

        /* Testing the GetTransUnitDataByID() is unneccessary as this method takes the previous and return the Data. */

        [TestMethod]
        public void XLF_GetPreviousTranslatableNode_Test_1()
        {

            /* Initialization. */

            XmlDocument xlfDocument = new XmlDocument();
            xlfDocument.Load(xliffPath);
            XLF testXLF = new XLF(xlfDocument);

            TransUnitNode auxiliaryTransUnitNode = testXLF.GetTransUnitNodeByID(10);

            /* Set of Assertions. */

            Assert.IsTrue(auxiliaryTransUnitNode.Data.IsTranslatable);

            TransUnitNode previousTranslatableNode = testXLF.GetPreviousTranslatableNode(auxiliaryTransUnitNode.Data);
            Assert.IsTrue(previousTranslatableNode.Data.IsTranslatable);

        }

    }
}
