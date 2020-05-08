using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS_XLZ_Basic;

namespace TMS_XLZ_Basic_Tests
{
    [TestClass]
    public class IT_Tests
    {
        /* Tests for assessing if the string was parsed correctly into IT object. */

        [TestMethod]
        public void IT_Parsing_Success_Test_1()
        {
            string testITRaw = "<it id=\"1\"></it>";

            IT parsedIT = new IT(testITRaw);

            Assert.AreEqual(true, parsedIT.ParsingSuccess);

        }

        [TestMethod]
        public void IT_Parsing_Success_Test_2()
        {
            string testITRaw = "<it id=\"1\">";

            IT parsedIT = new IT(testITRaw);

            Assert.AreEqual(false, parsedIT.ParsingSuccess);

        }

        [TestMethod]
        public void IT_Parsing_Success_Test_3()
        {
            string testITRaw = "teststring test</it>";

            IT parsedIT = new IT(testITRaw);

            Assert.AreEqual(false, parsedIT.ParsingSuccess);

        }

        /* Tests for assessing if the IT object waw initialized correctly. */

        [TestMethod]
        public void IT_Initialize_Test_1()
        {
            string testITRaw = "<it id=\"1\">&lt;afr story=\"ub35\" id=\"ub32\"/&gt;</it>";
            string innerText = "&lt;afr story=\"ub35\" id=\"ub32\"/&gt;";

            IT parsedIT = new IT(testITRaw);

            Assert.AreEqual(1, parsedIT.ID);
            Assert.AreEqual(innerText, parsedIT.Content);

        }

        [TestMethod]
        public void IT_Initialize_Test_2()
        {
            string testITRaw = "<it id=\"1\"></it>";
            string innerText = string.Empty;

            IT parsedIT = new IT(testITRaw);

            Assert.AreEqual(1, parsedIT.ID);
            Assert.AreEqual(innerText, parsedIT.Content);

        }

        [TestMethod]
        public void IT_Initialize_Test_3()
        {
            string testITRaw = "<it></it>";
            string innerText = string.Empty;

            IT parsedIT = new IT(testITRaw);

            Assert.AreEqual(-1, parsedIT.ID);
            Assert.AreEqual(innerText, parsedIT.Content);

        }
    }
}
