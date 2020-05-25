using TMS_XLZ_Basic;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS_XLZ_Basic.XLZ.Xliff;


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
        public void DLL_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData testData = new TransUnitData(transUnitList[0]);


            DLL newDLL = new DLL();
            TransUnitNode firstNode = newDLL.InsertPrevious(testData);
            TransUnitNode secondNode = newDLL.InsertPrevious(testData);
            TransUnitNode thirdNode = newDLL.InsertPrevious(testData);
            TransUnitNode fourthNode = newDLL.InsertPrevious(testData);

            // Assertions set.
            Assert.AreEqual(4, newDLL.Count);
            Assert.AreEqual(testData, newDLL.Tail.Data);
            Assert.AreEqual(testData, newDLL.Head.Data);

        }

        [TestMethod]
        public void DLL_Test_2()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            TransUnitData testData = new TransUnitData(transUnitList[0]);


            DLL newDLL = new DLL();
            TransUnitNode firstNode = newDLL.InsertNext(testData);
            TransUnitNode secondNode = newDLL.InsertNext(testData);
            TransUnitNode thirdNode = newDLL.InsertNext(testData);
            TransUnitNode fourthNode = newDLL.InsertNext(testData);

            // Assertions set.
            Assert.AreEqual(4, newDLL.Count);
            Assert.AreEqual(testData, newDLL.Tail.Data);
            Assert.AreEqual(testData, newDLL.Head.Data);

        }

    }
}
