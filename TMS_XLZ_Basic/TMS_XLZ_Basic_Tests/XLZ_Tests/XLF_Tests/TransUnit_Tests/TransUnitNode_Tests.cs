using TMS_XLZ_Basic;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;


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
    public class TransUnitNode_Tests
    {

        public string xliffPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\content.xlf";

        /*
         * Case: Constructor without any argument is invoked. 
         * Expected Result: TransUnitNode object with all fields set as null, will be created. 
         * Actual Result: As expected. 
         */

        [TestMethod]
        public void TransUnitData_Creation_WithoutData_Test_1()
        {
            // Initialization. 
            TransUnitNode testNode = new TransUnitNode();

            // Assertions set.
            Assert.IsNull(testNode.Data);
            Assert.IsNull(testNode.PreviousSibling);
            Assert.IsNull(testNode.NextSibling);

        }

        /*
         * Case: Constructor with TransUnitData object is invoked. 
         * Expected Result: TransUnitNode object with data equal to the TransUnitData object is created. 
         * Actual Result: As expected. 
         */

        [TestMethod]
        public void TransUnitData_Creation_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
           
            TransUnitData testData = new TransUnitData(transUnitList[0]);
            TransUnitNode testNode = new TransUnitNode(testData);

            // Assertions set. 
            Assert.AreEqual(testData, testNode.Data);
            Assert.IsNull(testNode.PreviousSibling);
            Assert.IsNull(testNode.NextSibling);

        }

        /*
         * Case: Constructor with TransUnitData object equal to null is invoked. 
         * Expected Result: TransUnitNode object with data equal to the TransUnitData object is created (null data). 
         * Actual Result: Not as expected. 
         */

        [TestMethod]
        public void TransUnitData_Creation_Test_2()
        {
            // Initialization. 
            TransUnitData testData = null; 
            TransUnitNode testNode = new TransUnitNode(testData);

            // Assertions set.
            Assert.IsNull(testNode.Data);
            Assert.IsNull(testNode.PreviousSibling);
            Assert.IsNull(testNode.NextSibling);

        }

        /*
         * Case: Clearing the node created by a constructor with TransUnitData object. 
         * Expected Result: TransUnitNode object after this operations should have all fields set as null. 
         * Actual Result: As expected. 
         */

        [TestMethod]
        public void TransUnitData_Clear_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData testData = new TransUnitData(transUnitList[0]);
            TransUnitNode testNode = new TransUnitNode(testData);

            testNode.Clear();

            // Assertions set. 
            Assert.IsNull(testNode.Data);
            Assert.IsNull(testNode.PreviousSibling);
            Assert.IsNull(testNode.NextSibling);

        }

        /*
         * Case: Clearing the node created by a constructor with TransUnitData object and set PreviousSibling and NextSibling. 
         * Expected Result: TransUnitNode object after this operations should have all fields set as null. 
         * Actual Result: As expected. 
         */

        [TestMethod]
        public void TransUnitData_Clear_Test_2()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);

            TransUnitNode firstTestNode = new TransUnitNode(firstTestData);
            TransUnitNode secondTestNode = new TransUnitNode(secondTestData);
            TransUnitNode thirdTestNode = new TransUnitNode(thirdTestData);

            // Setting Relations Between Nodes.
            firstTestNode.NextSibling = secondTestNode;

            secondTestNode.PreviousSibling = firstTestNode;
            secondTestNode.NextSibling = thirdTestNode;

            thirdTestNode.PreviousSibling = secondTestNode;

            secondTestNode.Clear();

            // Assertions set. 
            Assert.IsNull(secondTestNode.Data);
            Assert.IsNull(secondTestNode.PreviousSibling);
            Assert.IsNull(secondTestNode.NextSibling);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode is invoked. Previous node is equal to some nonempty node created 
         * using the first constructor and some not null TransUnitData object. 
         * Expected Result: TransUnitNode object with data equal to the TransUnitData object is created and the previous node will be set to the node 
         * which was passed as the second argument. 
         * Actual Result: As expected. 
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPrevious_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            
            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);

            TransUnitNode firstTestNode = new TransUnitNode(firstTestData);
            TransUnitNode secondTestNode = new TransUnitNode(secondTestData, firstTestNode);

            // Assertions set.
            Assert.AreEqual(firstTestData, firstTestNode.Data);
            Assert.AreEqual(secondTestNode, firstTestNode.NextSibling);
            Assert.IsNull(firstTestNode.PreviousSibling);

            Assert.AreEqual(secondTestData, secondTestNode.Data);
            Assert.AreEqual(firstTestNode, secondTestNode.PreviousSibling);
            Assert.IsNull(secondTestNode.NextSibling);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode is invoked. Previous node is equal to null object. 
         * Expected Result: TransUnitNode object with data equal to the TransUnitData object is created and the previous node will be set to the node 
         * which was passed as the second argument. 
         * Actual Result: Not as expected. 
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPrevious_Test_2()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);

            TransUnitNode firstTestNode = null;
            TransUnitNode secondTestNode = new TransUnitNode(secondTestData, firstTestNode);

            // Assertions set.
            Assert.AreEqual(transUnitList[1], secondTestNode.Data);
            Assert.IsNull(secondTestNode.PreviousSibling);
            Assert.IsNull(secondTestNode.NextSibling);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode is invoked. Previous node is equal to empty TransUnidNode object 
         * created with the constructor without argument passed. 
         * Expected Result: TransUnitNode object with data equal to the TransUnitData object is created and the previous node will be set to the node 
         * which was passed as the second argument. 
         * Actual Result: As expected. 
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPrevious_Test_3()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);

            TransUnitNode firstTestNode = new TransUnitNode();
            TransUnitNode secondTestNode = new TransUnitNode(secondTestData, firstTestNode);

            // Assertions set.
            Assert.AreEqual(secondTestData, secondTestNode.Data);
            Assert.AreEqual(firstTestNode, secondTestNode.PreviousSibling);
            Assert.IsNull(secondTestNode.NextSibling);

            Assert.IsNull(firstTestNode.Data);
            Assert.AreEqual(secondTestNode, firstTestNode.NextSibling);
            Assert.IsNull(firstTestNode.PreviousSibling);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode is invoked. Previous node is equal to some TransUnidNode object 
         * created with the constructor with TransUnitData passed and TransUnitData of the actual node is null. 
         * Expected Result: TransUnitNode object with data equal to the TransUnitData object is created and the previous node will be set to the node 
         * which was passed as the second argument. 
         * Actual Result: As expected. 
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPrevious_Test_4()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData firstTestData = new TransUnitData(transUnitList[1]);
            TransUnitData secondTestData = null;

            TransUnitNode firstTestNode = new TransUnitNode(firstTestData);
            TransUnitNode secondTestNode = new TransUnitNode(secondTestData, firstTestNode);

            // Assertions set.
            Assert.AreEqual(secondTestNode, firstTestNode.NextSibling);
            Assert.AreEqual(firstTestData, firstTestNode.Data);
            Assert.IsNull(firstTestNode.PreviousSibling);

            Assert.AreEqual(firstTestNode, secondTestNode.PreviousSibling);
            Assert.IsNull(secondTestNode.NextSibling);
            Assert.IsNull(secondTestNode.Data);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode is invoked. Previous TransUnitNode is created in a standard way
         * using constructor with a TransUnitData argument. The special thing about it is that the previousNode is in some relations with two other 
         * TransUnitNodes - first of them is PreviousSibling and second of them is NextSibling. So new node is created using TransUnitData and the node
         * which is already NextSibling of some node and PreviousSibling of the other node.
         * Expected Result: TransUnitNode object with data equal to the TransUnitData object is created and the previous node will be set to the node 
         * which was passed as the second argument. And therefore new node will become NextSibling of the previous Node and previous NextSibling will 
         * have null value in the PreviousSibling field - therefore new node will replace the previous NextSibling of the previous node. 
         * Actual Result: As expected. 
         * 
         * Note: This case is when NextSibling of the previousNode has no other connection, but in the case when this connection occurs, it has to be 
         * limited from the level of Doubly Linked List. 
         * Note: Maybe the next node should be cleaned up? 
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPrevious_Test_5()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);
            TransUnitData fourthTestData = new TransUnitData(transUnitList[3]);

            TransUnitNode firstTestNode = new TransUnitNode(firstTestData);
            TransUnitNode secondTestNode = new TransUnitNode(secondTestData);
            TransUnitNode thirdTestNode = new TransUnitNode(thirdTestData);

            // Setting Relations Between Nodes.
            firstTestNode.NextSibling = secondTestNode;

            secondTestNode.PreviousSibling = firstTestNode;
            secondTestNode.NextSibling = thirdTestNode;

            thirdTestNode.PreviousSibling = secondTestNode;

            TransUnitNode fourthTestNode = new TransUnitNode(fourthTestData, secondTestNode);

            // Assertions set.
            Assert.AreEqual(secondTestNode, firstTestNode.NextSibling);
            Assert.AreEqual(firstTestNode, secondTestNode.PreviousSibling);

            Assert.AreEqual(fourthTestNode, secondTestNode.NextSibling);
            Assert.AreEqual(secondTestNode, fourthTestNode.PreviousSibling);

            Assert.IsNull(thirdTestNode.PreviousSibling);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode and TransUnitNode nextNode is invoked.
         * Expected Result: TransUnitNode object with data equal to the TransUnitData and PreviousSibling equal to the previousNode and NextSibling 
         * equal to the nextNode is created.
         * Actual Result: As expected. 
         *
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPreviousNext_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);

            // Setting Relations Between Nodes.
            TransUnitNode firstTestNode = new TransUnitNode(firstTestData);
            TransUnitNode secondTestNode = new TransUnitNode(secondTestData);
            TransUnitNode thirdTestNode = new TransUnitNode(thirdTestData, firstTestNode, secondTestNode);

            // Assertions set.
            Assert.AreEqual(thirdTestData, thirdTestNode.Data);
            Assert.AreEqual(firstTestNode, thirdTestNode.PreviousSibling);
            Assert.AreEqual(secondTestNode, thirdTestNode.NextSibling);
            
            Assert.AreEqual(firstTestData, firstTestNode.Data);
            Assert.IsNull(firstTestNode.PreviousSibling);
            Assert.AreEqual(thirdTestNode, firstTestNode.NextSibling);
        
            Assert.AreEqual(secondTestData, secondTestNode.Data);
            Assert.AreEqual(thirdTestNode, secondTestNode.PreviousSibling);
            Assert.IsNull(secondTestNode.NextSibling);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode and TransUnitNode nextNode is invoked whereas previousNode and 
         * nextNode are euqal to null.
         * Expected Result: TransUnitNode object with data equal to the TransUnitData and PreviousSibling equal to the previousNode and NextSibling 
         * equal to the nextNode is created.
         * Actual Result: Not as expected. 
         *
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPreviousNext_Test_2()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);

            // Assertions set.
            TransUnitNode firstTestNode = null;
            TransUnitNode secondTestNode = null;
            TransUnitNode thirdTestNode = new TransUnitNode(thirdTestData, firstTestNode, secondTestNode);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode and TransUnitNode nextNode is invoked whereas previousNode and 
         * nextNode are created as empty nodes.
         * Expected Result: TransUnitNode object with data equal to the TransUnitData and PreviousSibling equal to the previousNode and NextSibling 
         * equal to the nextNode is created.
         * Actual Result: As expected. 
         *
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPreviousNext_Test_3()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);

            TransUnitNode firstTestNode = new TransUnitNode();
            TransUnitNode secondTestNode = new TransUnitNode();
            TransUnitNode thirdTestNode = new TransUnitNode(thirdTestData, firstTestNode, secondTestNode);

            // Assertions set.
            Assert.AreEqual(thirdTestData, thirdTestNode.Data);
            Assert.AreEqual(firstTestNode, thirdTestNode.PreviousSibling);
            Assert.AreEqual(secondTestNode, thirdTestNode.NextSibling);

            Assert.IsNull(firstTestNode.Data);
            Assert.IsNull(firstTestNode.PreviousSibling);
            Assert.AreEqual(thirdTestNode, firstTestNode.NextSibling);

            Assert.IsNull(secondTestNode.Data);
            Assert.AreEqual(thirdTestNode, secondTestNode.PreviousSibling);
            Assert.IsNull(secondTestNode.NextSibling);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode and TransUnitNode nextNode is invoked whereas previousNode is 
         * created in a standard way and nextNode is created using TransUnitData and previousNode.
         * Expected Result: TransUnitNode object with data equal to the TransUnitData and PreviousSibling equal to the previousNode and NextSibling 
         * equal to the nextNode is created.
         * Actual Result: As expected. 
         *
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPreviousNext_Test_4()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);

            // Setting Relations Between Nodes.
            TransUnitNode firstTestNode = new TransUnitNode(firstTestData);
            TransUnitNode secondTestNode = new TransUnitNode(secondTestData, firstTestNode);
            TransUnitNode thirdTestNode = new TransUnitNode(thirdTestData, firstTestNode, secondTestNode);

            // Assertions set.
            Assert.AreEqual(thirdTestData, thirdTestNode.Data);
            Assert.AreEqual(firstTestNode, thirdTestNode.PreviousSibling);
            Assert.AreEqual(secondTestNode, thirdTestNode.NextSibling);

            Assert.AreEqual(firstTestData, firstTestNode.Data);
            Assert.IsNull(firstTestNode.PreviousSibling);
            Assert.AreEqual(thirdTestNode, firstTestNode.NextSibling);

            Assert.AreEqual(secondTestData, secondTestNode.Data);
            Assert.AreEqual(thirdTestNode, secondTestNode.PreviousSibling);
            Assert.IsNull(secondTestNode.NextSibling);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode and TransUnitNode nextNode is invoked whereas previousNode and 
         * nextNode have not null PreviousSibling and NextSibling fields.
         * Expected Result: TransUnitNode object with data equal to the TransUnitData and PreviousSibling equal to the previousNode and NextSibling 
         * equal to the nextNode is created.
         * Actual Result: As expected. 
         *
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPreviousNext_Test_5()
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

            // Setting Relations Between Nodes.
            TransUnitNode firstTestNode = new TransUnitNode(firstTestData);
            TransUnitNode secondTestNode = new TransUnitNode(secondTestData, firstTestNode);
            TransUnitNode thirdTestNode = new TransUnitNode(thirdTestData, firstTestNode, secondTestNode);
            TransUnitNode fourthTestNode = new TransUnitNode(fourthTestData, thirdTestNode, secondTestNode);
            TransUnitNode fifthTestNode = new TransUnitNode(fifthTestData, fourthTestNode, secondTestNode);

            // Assertions set.
            Assert.AreEqual(firstTestData, firstTestNode.Data);
            Assert.IsNull(firstTestNode.PreviousSibling);
            Assert.AreEqual(thirdTestNode, firstTestNode.NextSibling);
            
            Assert.AreEqual(secondTestData, secondTestNode.Data);
            Assert.AreEqual(fifthTestNode, secondTestNode.PreviousSibling);
            Assert.IsNull(secondTestNode.NextSibling);

            Assert.AreEqual(thirdTestData, thirdTestNode.Data);
            Assert.AreEqual(firstTestNode, thirdTestNode.PreviousSibling);
            Assert.AreEqual(fourthTestNode, thirdTestNode.NextSibling);

            Assert.AreEqual(fourthTestData, fourthTestNode.Data);
            Assert.AreEqual(thirdTestNode, fourthTestNode.PreviousSibling);
            Assert.AreEqual(fifthTestNode, fourthTestNode.NextSibling);

            Assert.AreEqual(fifthTestData, fifthTestNode.Data);
            Assert.AreEqual(fourthTestNode, fifthTestNode.PreviousSibling);
            Assert.AreEqual(secondTestNode, fifthTestNode.NextSibling);

        }

        /*
         * Case: Constructor with TransUnitData object and TransUnidNode previousNode and TransUnitNode nextNode is invoked whereas previousNode is the
         * second node in the count and NextNode is the first node in the count, so the constructor is invoked with reversed values.
         * Expected Result: TransUnitNode object with data equal to the TransUnitData and PreviousSibling and NextSibling reversed. Consider the case in
         * the test:
         * 1. previousNode is the secondTransUnitNode which PreviousSibling is firstTransUnitNode and NextSibling is null.
         * 2. nextNode is the fristTransUnitNode which PreviousSibling is null and NextSibling is secondTransUnitNode. 
         * 3. previousNode should have PreviousSibling equal to the nextNode PreviousSibling and NextSibling equal to created node.
         * 4. nextNode should have PreviousSibling equal to the created node and NextSibling equal to the previousNode's NextSibling.
         * THIS IS TO BE IMPLEMENTED
         * Actual Result: Not as expected. 
         *
         */

        [TestMethod]
        public void TransUnitData_Creation_WithPreviousNext_Test_6()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            TransUnitData firstTestData = new TransUnitData(transUnitList[0]);
            TransUnitData secondTestData = new TransUnitData(transUnitList[1]);
            TransUnitData thirdTestData = new TransUnitData(transUnitList[2]);

            // Setting Relations Between Nodes.
            TransUnitNode firstTestNode = new TransUnitNode(firstTestData);
            TransUnitNode secondTestNode = new TransUnitNode(secondTestData, firstTestNode);
            TransUnitNode thirdTestNode = new TransUnitNode(thirdTestData, secondTestNode, firstTestNode);

            // Assertions set.
            Assert.AreEqual(firstTestData, firstTestNode.Data);
            Assert.AreEqual(thirdTestNode, firstTestNode.PreviousSibling);
            Assert.AreEqual(secondTestNode, firstTestNode.NextSibling);

            Assert.IsNull(firstTestNode);

            Assert.AreEqual(secondTestData, secondTestNode.Data);
            Assert.AreEqual(firstTestNode, secondTestNode.PreviousSibling);

            Assert.IsNull(secondTestNode.PreviousSibling);
            Assert.AreEqual(thirdTestNode, secondTestNode.NextSibling);

            Assert.AreEqual(thirdTestData, thirdTestNode.Data);
            Assert.AreEqual(secondTestNode, thirdTestNode.PreviousSibling);
            Assert.AreEqual(firstTestNode, thirdTestNode.NextSibling);

        }
    }
}
