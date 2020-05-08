using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS_XLZ_Basic;

namespace TMS_XLZ_Basic_Tests
{
    [TestClass]
    public class PH_Tests
    {
        /* Tests for assessing if the string was parsed correctly into PH object. */

        [TestMethod]
        public void PH_Parsing_Success_Test_1()
        {
            string testPHRaw = "<ph id=\"1\"></ph>";

            PH parsedPH = new PH(testPHRaw);

            Assert.AreEqual(true, parsedPH.ParsingSuccess);

        }

        [TestMethod]
        public void PH_Parsing_Success_Test_2()
        {
            string testPHRaw = "<ph id=\"1\">";

            PH parsedPH = new PH(testPHRaw);

            Assert.AreEqual(false, parsedPH.ParsingSuccess);

        }

        [TestMethod]
        public void PH_Parsing_Success_Test_3()
        {
            string testPHRaw = "teststring test</ph>";

            PH parsedPH = new PH(testPHRaw);

            Assert.AreEqual(false, parsedPH.ParsingSuccess);

        }

        /* Tests for assessing if the PH object waw initialized correctly. */

        [TestMethod]
        public void PH_Initialize_Test_1()
        {
            string testPHRaw = "<ph id=\"1\">&lt;afr story=\"ub35\" id=\"ub32\"/&gt;</ph>";
            string innerText = "&lt;afr story=\"ub35\" id=\"ub32\"/&gt;";

            PH parsedPH = new PH(testPHRaw);

            Assert.AreEqual(1, parsedPH.ID);
            Assert.AreEqual(innerText, parsedPH.Content);

        }

        [TestMethod]
        public void PH_Initialize_Test_2()
        {
            string testPHRaw = "<ph id=\"1\"></ph>";
            string innerText = string.Empty;

            PH parsedPH = new PH(testPHRaw);

            Assert.AreEqual(1, parsedPH.ID);
            Assert.AreEqual(innerText, parsedPH.Content);

        }

        [TestMethod]
        public void PH_Initialize_Test_3()
        {
            string testPHRaw = "<ph></ph>";
            string innerText = string.Empty;

            PH parsedPH = new PH(testPHRaw);

            Assert.AreEqual(-1, parsedPH.ID);
            Assert.AreEqual(innerText, parsedPH.Content);

        }
    }
}
