using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS_XLZ_Basic;

namespace TMS_XLZ_Basic_Tests
{
    [TestClass]
    public class BPTUnitTests
    {
        /* Tests for assessing if the string was parsed correctly into BPT object. */
        
        [TestMethod]
        public void BPT_Parsing_Success_Test_1()
        {
            string testBPTRaw = "<bpt id=\"1\"></bpt>";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(true, parsedBPT.ParsingSuccess);

        }

        [TestMethod]
        public void BPT_Parsing_Success_Test_2()
        {
            string testBPTRaw = "<bpt id=\"1\">";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(false, parsedBPT.ParsingSuccess);

        }

        [TestMethod]
        public void BPT_Parsing_Success_Test_3()
        {
            string testBPTRaw = "teststring test<\bpt>";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(false, parsedBPT.ParsingSuccess);

        }

        /* Tests for assessing if the BPT object waw initialized correctly. */

        [TestMethod]
        public void BPT_Initialize_Test_1()
        {
            string testBPTRaw = "<bpt id=\"1\">&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\"&gt;</bpt>";
            string innerText = "&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\"&gt;";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(1, parsedBPT.BptID);
            Assert.AreEqual(innerText, parsedBPT.BptContent);

        }

        [TestMethod]
        public void BPT_Initialize_Test_2()
        {
            string testBPTRaw = "<bpt id=\"1\"></bpt>";
            string innerText = string.Empty;

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(1, parsedBPT.BptID);
            Assert.AreEqual(innerText, parsedBPT.BptContent);

        }

        [TestMethod]
        public void BPT_Initialize_Test_3()
        {
            string testBPTRaw = "<bpt></bpt>";
            string innerText = string.Empty;

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(-1, parsedBPT.BptID);
            Assert.AreEqual(innerText, parsedBPT.BptContent);

        }

        /* Tests for assessing if the IsYellowHighlight() methods works correctly. */

        [TestMethod]
        public void BPT_YellowHighlight_Test_1()
        {
            string testBPTRaw = "<bpt id=\"1\">&lt;cf bold=\"on\" complexscriptsbold=\"on\" highlight=\"yellow\"&gt;</bpt>";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(true, parsedBPT.IsYellowHighlight());

        }

        [TestMethod]
        public void BPT_YellowHighlight_Test_2()
        {
            string testBPTRaw = "<bpt id=\"1\">&lt;cf bold=\"on\" complexscriptsbold=\"on\"&gt;</bpt>";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(false, parsedBPT.IsYellowHighlight());

        }
    }
}
