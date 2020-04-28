using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS_XLZ_Basic;

namespace TMS_XLZ_Basic_Tests
{
    [TestClass]
    public class EPTUnitTests
    {
        /* Tests for assessing if the string was parsed correctly into EPT object. */
        
        [TestMethod]
        public void EPT_Parsing_Success_Test_1()
        {
            string testEPTRaw = "<ept id=\"1\"></ept>";
           
            EPT parsedEPT = new EPT(testEPTRaw);

            Assert.AreEqual(true, parsedEPT.ParsingSuccess);

        }

        [TestMethod]
        public void EPT_Parsing_Success_Test_2()
        {
            string testEPTRaw = "<ept id=\"1\">";

            EPT parsedEPT = new EPT(testEPTRaw);

            Assert.AreEqual(false, parsedEPT.ParsingSuccess);

        }

        [TestMethod]
        public void EPT_Parsing_Success_Test_3()
        {
            string testEPTRaw = "teststring test</ept>";

            EPT parsedEPT = new EPT(testEPTRaw);

            Assert.AreEqual(false, parsedEPT.ParsingSuccess);

        }

        /* Tests for assessing if the BPT object waw initialized correctly. */

        [TestMethod]
        public void EPT_Initialize_Test_1()
        {
            string testEPTRaw = "<ept id=\"1\">&lt;/cf&gt;</ept>";
            string innerText = "&lt;/cf&gt;";

            EPT parsedEPT = new EPT(testEPTRaw);

            Assert.AreEqual(1, parsedEPT.EptID);
            Assert.AreEqual(innerText, parsedEPT.EptContent);

        }

        [TestMethod]
        public void EPT_Initialize_Test_2()
        {
            string testEPTRaw = "<ept id=\"1\"></ept>";
            string innerText = string.Empty;

            EPT parsedEPT = new EPT(testEPTRaw);

            Assert.AreEqual(1, parsedEPT.EptID);
            Assert.AreEqual(innerText, parsedEPT.EptContent);

        }

        [TestMethod]
        public void EPT_Initialize_Test_3()
        {
            string testEPTRaw = "<ept></ept>";
            string innerText = string.Empty;

            EPT parsedEPT = new EPT(testEPTRaw);

            Assert.AreEqual(-1, parsedEPT.EptID);
            Assert.AreEqual(innerText, parsedEPT.EptContent);

        }
    }
}
