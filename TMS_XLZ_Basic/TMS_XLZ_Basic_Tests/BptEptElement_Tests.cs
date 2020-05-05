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
        public string testString01 = "<bpt id=\"1\">&lt;</bpt>Otis <bpt id=\"2\">&rt;</bpt>and<ept id=\"2\"></ept><ept id=\"1\">&lt;/cf&gt;</ept>";
        public string testString1 = "<bpt id=\"1\">&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\" size=\"9\" complexscriptssize=\"9\"&gt;</bpt>Otis Proprietary &amp; Confidential – for internal distribution only<ept id=\"1\">&lt;/cf&gt;</ept>";

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_0_0_0_1()
        {
            string testBptEptRaw = testString01;

            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);
            Assert.AreNotEqual(null, parsedBptEpt.BptElement);
            Assert.AreNotEqual(null, parsedBptEpt.EptElement);

            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);
            Assert.AreEqual(1, parsedBptEpt.EptElement.EptID);

            Assert.IsTrue(parsedBptEpt.IsPaired);
            Assert.AreEqual(1, parsedBptEpt.ElementID);

        }

        

    }
}
