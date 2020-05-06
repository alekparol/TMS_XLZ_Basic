using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.CodeDom.Compiler;
using TMS_XLZ_Basic;
using TMS_XLZ_Basic.XLZ.Xliff.TransUnit.TransUnitElements;


namespace TMS_XLZ_Basic_Tests
{


    [TestClass]
    public class BptEptElementUnitTests
    {
        /* Tests for assessing if the string was parsed correctly into BPT object. */

        public string testString0 = "<bpt id=\"1\">&lt;</bpt>Otis<ept id=\"1\">&lt;/cf&gt;</ept>";
        public string testString001 = "<bpt id=\"1\">&lt;</bpt>Otis<ept id=\"2\">&lt;/cf&gt;</ept>";
        public string testString01 = "<bpt id=\"1\">&lt;</bpt>Otis <bpt id=\"2\">&rt;</bpt>and<ept id=\"2\"></ept><ept id=\"1\">&lt;/cf&gt;</ept>";
        public string testString02 = "<bpt id=\"1\">&lt;</bpt>Otis <bpt id=\"2\">&rt;</bpt>and<ept id=\"2\"></ept><ept id=\"1\">&lt;/cf&gt;</ept>";
        public string testString1 = "<bpt id=\"1\">&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\" size=\"9\" complexscriptssize=\"9\"&gt;</bpt>Otis Proprietary &amp; Confidential – for internal distribution only<ept id=\"1\">&lt;/cf&gt;</ept>";
        public string testString2 = "<bpt id=\"2\">&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\" complexscriptsbold=\"on\"&gt;</bpt>Action re<ept id=\"2\">&lt;/cf&gt;</ept><bpt id=\"3\">&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\" complexscriptsbold=\"on\" highlight=\"yellow\"&gt;</bpt>quire<ept id=\"3\">&lt;/cf&gt;</ept><ph id=\"4\">&lt;bookmarkStart number=\"0\" w:name=\"_GoBack\"/&gt;</ph><ph id=\"5\">&lt;bookmarkEnd number=\"0\"/&gt;</ph>";

        /* Looking for the minimal string which is well parsed. */

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_1()
        {
            string testBptEptRaw = "a";
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsFalse(parsedBptEpt.ParsingSuccess);

        }

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_2()
        {
            string testBptEptRaw = "<bpt id=\"1\"><ept id=\"1\">";
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsFalse(parsedBptEpt.ParsingSuccess);

        }

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_3()
        {
            string testBptEptRaw = "<bpt id=\"1\"></bpt><ept id=\"1\">"; 
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsFalse(parsedBptEpt.ParsingSuccess);

        }

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_4()
        {
            string testBptEptRaw = "<bpt id=\"1\"></bpt><ept id=\"1\"></ept>";
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);

        }

        /*Checking BPT element creation - using: 1) paired, 2) non-paired and 3) nested string. */

        [TestMethod]
        public void BptEptElement_ElementCreation_BPT_Test_1()
        {
            string testBptEptRaw = testString0;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);

            Assert.IsTrue(parsedBptEpt.BptElement.ParsingSuccess);
            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);

            Assert.AreEqual("&lt;", parsedBptEpt.BptElement.BptContent);
        }

        [TestMethod]
        public void BptEptElement_ElementCreation_BPT_Test_2()
        {
            string testBptEptRaw = testString001;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);

            Assert.IsTrue(parsedBptEpt.BptElement.ParsingSuccess);
            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);

            Assert.AreEqual("&lt;", parsedBptEpt.BptElement.BptContent);
        }

        [TestMethod]
        public void BptEptElement_ElementCreation_BPT_Test_3()
        {
            string testBptEptRaw = testString01;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);

            Assert.IsTrue(parsedBptEpt.BptElement.ParsingSuccess);
            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);

            Assert.AreEqual("&lt;", parsedBptEpt.BptElement.BptContent);
        }

        /*Checking EPT element creation - using: 1) paired, 2) non-paired and 3) nested string. */

        [TestMethod]
        public void BptEptElement_ElementCreation_EPT_Test_1()
        {
            string testBptEptRaw = testString0;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);

            Assert.IsTrue(parsedBptEpt.EptElement.ParsingSuccess);
            Assert.AreEqual(1, parsedBptEpt.EptElement.EptID);

            Assert.AreEqual("&lt;/cf&gt;", parsedBptEpt.EptElement.EptContent);

        }

        [TestMethod]
        public void BptEptElement_ElementCreation_EPT_Test_2()
        {
            string testBptEptRaw = testString001;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);

            Assert.IsTrue(parsedBptEpt.EptElement.ParsingSuccess);
            Assert.AreEqual(2, parsedBptEpt.EptElement.EptID);

            Assert.AreEqual("&lt;/cf&gt;", parsedBptEpt.EptElement.EptContent);
        }

        [TestMethod]
        public void BptEptElement_ElementCreation_EPT_Test_3()
        {
            string testBptEptRaw = testString01;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);

            Assert.IsTrue(parsedBptEpt.EptElement.ParsingSuccess);
            Assert.AreEqual(1, parsedBptEpt.EptElement.EptID);

            Assert.AreEqual("&lt;/cf&gt;", parsedBptEpt.EptElement.EptContent);
        }

        /*Checking pairing*/

        [TestMethod]
        public void BptEptElement_Pairing_Test_1()
        {
            string testBptEptRaw = testString001;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);
            Assert.AreEqual(2, parsedBptEpt.EptElement.EptID);

            Assert.IsFalse(parsedBptEpt.IsPaired);

        }

        [TestMethod]
        public void BptEptElement_Pairing_Test_2()
        {
            string testBptEptRaw = testString0;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);
            Assert.AreEqual(1, parsedBptEpt.EptElement.EptID);

            Assert.IsTrue(parsedBptEpt.IsPaired);

        }

        /*Checking element's ID of 1) Not well formed <bpt><ept> element, 2) well formed, 3) nested.*/

        [TestMethod]
        public void BptEptElement_ElementID_Test_1()
        {
            string testBptEptRaw = testString001;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);
            Assert.AreEqual(2, parsedBptEpt.EptElement.EptID);

            Assert.IsFalse(parsedBptEpt.IsPaired);
            Assert.AreEqual(0,parsedBptEpt.ElementID);

        }

        [TestMethod]
        public void BptEptElement_ElementID_Test_2()
        {
            string testBptEptRaw = testString0;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);
            Assert.AreEqual(1, parsedBptEpt.EptElement.EptID);

            Assert.IsTrue(parsedBptEpt.IsPaired);
            Assert.AreEqual(1, parsedBptEpt.ElementID);

        }

        [TestMethod]
        public void BptEptElement_ElementID_Test_3()
        {
            string testBptEptRaw = testString01;
            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);
            Assert.AreEqual(1, parsedBptEpt.EptElement.EptID);

            Assert.IsTrue(parsedBptEpt.IsPaired);
            Assert.AreEqual(1, parsedBptEpt.ElementID);

            Assert.IsTrue(parsedBptEpt.IsNested);
            Assert.AreEqual(2, parsedBptEpt.NestedElement.ElementID);

        }

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_0_0_0_1()
        {
            string testBptEptRaw = testString02;

            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);
            Assert.AreNotEqual(null, parsedBptEpt.BptElement);
            Assert.AreNotEqual(null, parsedBptEpt.EptElement);

            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);
            Assert.AreEqual(1, parsedBptEpt.EptElement.EptID);

            Assert.IsTrue(parsedBptEpt.IsPaired);
            Assert.AreEqual(1, parsedBptEpt.ElementID);

            Assert.IsTrue(parsedBptEpt.IsNested);
            Assert.AreEqual(2, parsedBptEpt.NestedElement.ElementID);

        }

        

    }
}
