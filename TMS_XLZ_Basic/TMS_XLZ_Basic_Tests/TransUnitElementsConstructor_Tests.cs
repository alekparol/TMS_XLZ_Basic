using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.CodeDom.Compiler;
using TMS_XLZ_Basic;
using TMS_XLZ_Basic.XLZ.Xliff.TransUnit.TransUnitElements;


namespace TMS_XLZ_Basic_Tests
{


    [TestClass]
    public class TransUnitElementsConstructor_Tests
    {

        [TestMethod]
        public void First_Test_1()
        {
            string testBptEptRaw = "<source><bpt id=\"1\">&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\" size=\"9\" complexscriptssize=\"9\"&gt;</bpt>Otis Proprietary &amp; Confidential – for internal distribution only<ept id=\"1\">&lt;/cf&gt;</ept></source>";
            TransUnitElementsConstructor tr = new TransUnitElementsConstructor(testBptEptRaw);

            Assert.AreEqual(1, tr.listOfBpt.Count);
            Assert.AreEqual(1, tr.listOfEpt.Count);

            Assert.AreEqual(1, tr.listOfBptEptElements.Count);
            Assert.AreEqual("Otis Proprietary &amp; Confidential – for internal distribution only", tr.listOfBptEptElements[0].TextBetween);
        }

    }
}
