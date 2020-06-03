using TMS_XLZ_Basic;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS_XLZ_Basic.XLZ.Xliff;
using System;
using System.IO;


/*TODO: Add tests for: 
 *- Creation with null value data for the previous node;
 *- Creation with null value data for the new node and not null data with previous node;
 *- Creation with a previous node which has not null references to next or previous nodes; 
 * 
 */

/*TODO: Add tests for: 
 *- Creation with null value data for the previous node;
 *- Creation with null value data for the new node and not null data with previous node;
 *- Creation with a previous node which has not null references to next or previous nodes; 
 * 
 */

namespace TMS_XLZ_Basic_Tests
{
    [TestClass]
    public class DLL_Tests
    {

        public string xliffPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\content.xlf";

        /*
         * Case: Constructor without any argument is invoked. 
         * Expected Result: TransUnitNode object with all fields set as null, will be created. 
         * Actual Result: As expected. 
         */

        [TestMethod]
        public void DLL_InsertNext_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData testData = new TransUnitData(transUnitList[0]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(testData);

            // Assertions set.
            Assert.AreEqual(1, doublyLinkedList.Count);
            Assert.AreEqual(testData, doublyLinkedList.Head.Data);
            Assert.AreEqual(testData, doublyLinkedList.Tail.Data);
            
        }

        [TestMethod]
        public void DLL_InsertNext_Test_2()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertNext(secondTestData);

            // Assertions set.
            Assert.AreEqual(2, doublyLinkedList.Count);
            Assert.AreEqual(secondTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(firstTestData, doublyLinkedList.Tail.Data);

        }

        [TestMethod]
        public void DLL_InsertNext_Test_3()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertNext(secondTestData);
            doublyLinkedList.InsertNext(thirdTestData);

            // Assertions set.
            Assert.AreEqual(3, doublyLinkedList.Count);
            Assert.AreEqual(thirdTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(firstTestData, doublyLinkedList.Tail.Data);

        }

        [TestMethod]
        public void DLL_InsertPrevioius_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData testData = new TransUnitData(transUnitList[0]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertPrevious(testData);

            // Assertions set.
            Assert.AreEqual(1, doublyLinkedList.Count);
            Assert.AreEqual(testData, doublyLinkedList.Head.Data);
            Assert.AreEqual(testData, doublyLinkedList.Tail.Data);

        }

        [TestMethod]
        public void DLL_InsertPrevious_Test_2()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertPrevious(firstTestData);
            doublyLinkedList.InsertPrevious(secondTestData);

            // Assertions set.
            Assert.AreEqual(2, doublyLinkedList.Count);
            Assert.AreEqual(firstTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(secondTestData, doublyLinkedList.Tail.Data);

        }

        [TestMethod]
        public void DLL_InsertPrevious_Test_3()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertPrevious(firstTestData);
            doublyLinkedList.InsertPrevious(secondTestData);
            doublyLinkedList.InsertPrevious(thirdTestData);

            // Assertions set.
            Assert.AreEqual(3, doublyLinkedList.Count);
            Assert.AreEqual(firstTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(secondTestData, doublyLinkedList.Tail.Data);

        }

        [TestMethod]
        public void DLL_InsertNextPrevious_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertNext(secondTestData);
            doublyLinkedList.InsertPrevious(thirdTestData);

            // Assertions set.
            Assert.AreEqual(3, doublyLinkedList.Count);
            Assert.AreEqual(secondTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(firstTestData, doublyLinkedList.Tail.Data);

        }

        [TestMethod]
        public void DLL_InsertNextPrevious_Test_2()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertPrevious(firstTestData);
            doublyLinkedList.InsertNext(secondTestData);
            doublyLinkedList.InsertNext(thirdTestData);

            // Assertions set.
            Assert.AreEqual(3, doublyLinkedList.Count);
            Assert.AreEqual(thirdTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(firstTestData, doublyLinkedList.Tail.Data);

        }

        [TestMethod]
        public void DLL_InsertNextPrevious_Test_3()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertPrevious(secondTestData);
            doublyLinkedList.InsertNext(thirdTestData);

            // Assertions set.
            Assert.AreEqual(3, doublyLinkedList.Count);
            Assert.AreEqual(thirdTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(secondTestData, doublyLinkedList.Tail.Data);

        }


        [TestMethod]
        public void DLL_InsertNextPrevious_Test_4()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertPrevious(firstTestData);
            doublyLinkedList.InsertPrevious(secondTestData);
            doublyLinkedList.InsertNext(thirdTestData);

            // Assertions set.
            Assert.AreEqual(3, doublyLinkedList.Count);
            Assert.AreEqual(thirdTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(secondTestData, doublyLinkedList.Tail.Data);

        }


        [TestMethod]
        public void DLL_InsertNextPrevious_Test_5()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertPrevious(secondTestData);
            doublyLinkedList.InsertPrevious(thirdTestData);

            // Assertions set.
            Assert.AreEqual(3, doublyLinkedList.Count);
            Assert.AreEqual(firstTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(secondTestData, doublyLinkedList.Tail.Data);

        }


        [TestMethod]
        public void DLL_InsertNextPrevious_Test_6()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertPrevious(firstTestData);
            doublyLinkedList.InsertNext(secondTestData);
            doublyLinkedList.InsertPrevious(thirdTestData);

            // Assertions set.
            Assert.AreEqual(3, doublyLinkedList.Count);
            Assert.AreEqual(secondTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(firstTestData, doublyLinkedList.Tail.Data);

        }

        [TestMethod]
        public void DLL_GetIndexOf_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);

            // Assertions set.
            Assert.AreEqual(0, doublyLinkedList.GetIndexOf(firstTestData));

        }

        [TestMethod]
        public void DLL_GetIndexOf_Test_2()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);

            // Assertions set.
            Assert.AreEqual(-1, doublyLinkedList.GetIndexOf(secondTestData));

        }

        [TestMethod]
        public void DLL_GetIndexOf_Test_3()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(secondTestData);
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertNext(firstTestData);

            // Assertions set.
            Assert.AreEqual(1, doublyLinkedList.GetIndexOf(firstTestData));

        }

        [TestMethod]
        public void DLL_GetIndexOf_Test_4()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);
            TransUnitData fourthTestData = new TransUnitData(transUnitList[3]);
            TransUnitData fifthTestData = new TransUnitData(transUnitList[4]);


            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertNext(secondTestData);
            doublyLinkedList.InsertPrevious(thirdTestData);
            doublyLinkedList.InsertNext(fourthTestData);
            doublyLinkedList.InsertPrevious(fifthTestData);

            // Assertions set.
            Assert.AreEqual(0, doublyLinkedList.GetIndexOf(firstTestData));
            Assert.AreEqual(2, doublyLinkedList.GetIndexOf(secondTestData));
            Assert.AreEqual(1, doublyLinkedList.GetIndexOf(thirdTestData));
            Assert.AreEqual(3, doublyLinkedList.GetIndexOf(fifthTestData));
            Assert.AreEqual(4, doublyLinkedList.GetIndexOf(fourthTestData));

        }

        [TestMethod]
        public void DLL_GetIndexOf_Test_5()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);

            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);

            // Assertions set.
            Assert.AreEqual(-1, doublyLinkedList.GetIndexOf(secondTestData));

        }

        [TestMethod]
        public void DLL_InsertAtIndex_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);

            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertNext(secondTestData);
            doublyLinkedList.InsertAtIndex(thirdTestData, 1);

            // Assertions set.
            Assert.AreEqual(1, doublyLinkedList.GetIndexOf(thirdTestData));
            Assert.AreEqual(firstTestData, doublyLinkedList[1].PreviousSibling.Data);
            Assert.AreEqual(secondTestData, doublyLinkedList[1].NextSibling.Data);

        }

        [TestMethod]
        public void DLL_InsertAtIndex_Test_2()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);

            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);

            // Assertions set.
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => doublyLinkedList.InsertAtIndex(secondTestData, 3));

        }

        [TestMethod]
        public void DLL_InsertAtIndex_Test_3()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);

            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertAtIndex(firstTestData, 0);

            // Assertions set.
            Assert.AreEqual(1, doublyLinkedList.Count);
            Assert.AreEqual(firstTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(firstTestData, doublyLinkedList.Tail.Data);

        }

        [TestMethod]
        public void DLL_InsertAtIndex_Test_4()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);

            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertAtIndex(secondTestData, 1);

            // Assertions set.
            Assert.AreEqual(2, doublyLinkedList.Count);
            Assert.AreEqual(secondTestData, doublyLinkedList[1].Data);
            Assert.AreEqual(secondTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(firstTestData, doublyLinkedList.Head.PreviousSibling.Data);
            Assert.AreEqual(null, doublyLinkedList.Head.NextSibling);

        }

        [TestMethod]
        public void DLL_Remove_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);

            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertNext(secondTestData);
            doublyLinkedList.InsertNext(thirdTestData);

            doublyLinkedList.Remove();

            // Assertions set.
            Assert.AreEqual(2, doublyLinkedList.Count);
            Assert.AreEqual(secondTestData, doublyLinkedList.Head.Data);
            Assert.AreEqual(null, doublyLinkedList.Head.NextSibling);
            Assert.AreEqual(-1, doublyLinkedList.GetIndexOf(thirdTestData));

        }

        [TestMethod]
        public void DLL_Remove_Test_2()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);

            DLL doublyLinkedList = new DLL();
            doublyLinkedList.InsertNext(firstTestData);
            doublyLinkedList.InsertNext(secondTestData);
            doublyLinkedList.InsertNext(thirdTestData);

            doublyLinkedList.Remove();
            doublyLinkedList.Remove();
            doublyLinkedList.Remove();

            // Assertions set.
            Assert.AreEqual(0, doublyLinkedList.Count);
            Assert.IsNull(doublyLinkedList.Head);
            Assert.IsNull(doublyLinkedList.Tail);

        }

    }
}
