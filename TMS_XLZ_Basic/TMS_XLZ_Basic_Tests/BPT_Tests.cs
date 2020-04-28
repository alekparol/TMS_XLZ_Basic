using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS_XLZ_Basic;

namespace TMS_XLZ_Basic_Tests
{
    [TestClass]
    public class BPTUnitTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            string testBPTRaw = "<bpt id=\"1\">&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\"&gt;</bpt>";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(1, parsedBPT.bptID);
            Assert.AreEqual("&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\"&gt;", parsedBPT.bptContent);

        }

        [TestMethod]
        public void TestMethod2()
        {
            string testBPTRaw = "<bpt id=\"1\"></bpt>";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(1, parsedBPT.bptID);
            Assert.AreEqual(string.Empty, parsedBPT.bptContent);

        }

        [TestMethod]
        public void TestMethod3()
        {
            string testBPTRaw = "<bpt></bpt>";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(parsedBPT.bptID, 0);
            Assert.AreEqual(parsedBPT.bptContent, string.Empty);

        }

        [TestMethod]
        public void TestMethod4()
        {
            string testBPTRaw = "<bpt id=\"1\">&lt;cf bold=\"on\" complexscriptsbold=\"on\" highlight=\"yellow\"&gt;</bpt>";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(true, parsedBPT.IsYellowHighlight());

        }

        [TestMethod]
        public void TestMethod5()
        {
            string testBPTRaw = "<bpt id=\"1\">&lt;cf bold=\"on\" complexscriptsbold=\"on\"&gt;</bpt>";

            BPT parsedBPT = new BPT(testBPTRaw);

            Assert.AreEqual(false, parsedBPT.IsYellowHighlight());

        }
    }
}
