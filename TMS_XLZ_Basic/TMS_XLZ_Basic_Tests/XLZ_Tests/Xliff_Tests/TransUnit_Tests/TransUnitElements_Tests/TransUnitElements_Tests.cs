using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.CodeDom.Compiler;
using TMS_XLZ_Basic;

using TMS_XLZ_Basic.XLZ.Xliff.TransUnit.TransUnitElements;


namespace TMS_XLZ_Basic_Tests
{


    [TestClass]
    public class TransUnitElements_Tests
    {
        public string TestString0 = "Otis Proprietary &amp; Confidential – for internal distribution only";
        public string TestString1 = "<bpt id=\"1\">&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\" size=\"9\" complexscriptssize=\"9\"&gt;</bpt>Otis Proprietary &amp; Confidential – for internal distribution only<ept id=\"1\">&lt;/cf&gt;</ept>";
        public string TestString2 = "<bpt id=\"1\">&lt;cf cstyle=\"CharacterStyle/$ID/[No character style]\" color=\"Color/C=0 M=0 Y=0 K=100\" style=\"Medium\" size=\"14\" leading=\"unit:10\" font=\"string:Diodrum\"&gt;</bpt>Properties Overview  <ph id=\"2\">&lt;afr story=\"ub35\" id=\"ub32\"/&gt;</ph><ept id=\"1\">&lt;/cf&gt;</ept>";


        [TestMethod]
        public void First_Test_1()
        {
            string testBptEptRaw = "<source><bpt id=\"1\">&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\" size=\"9\" complexscriptssize=\"9\"&gt;</bpt>Otis Proprietary &amp; Confidential – for internal distribution only<ept id=\"1\">&lt;/cf&gt;</ept></source>";
            TransUnitElements tr = new TransUnitElements(testBptEptRaw);

            Assert.AreEqual(1, tr.listOfBpt.Count);
            Assert.AreEqual(1, tr.listOfEpt.Count);

            Assert.AreEqual(1, tr.listOfBptEptElements.Count);
            Assert.AreEqual("Otis Proprietary &amp; Confidential – for internal distribution only", tr.listOfBptEptElements[0].TextBetween);
        }

        [TestMethod]
        public void TransUnitElements_Parsing_Test_1()
        {
            
            TransUnitElements elementConstructor = new TransUnitElements(TestString1);

            Assert.AreEqual(1, elementConstructor.listOfBptEptElements.Count);
            Assert.AreEqual(0, elementConstructor.listOfItElements.Count);
            Assert.AreEqual(0, elementConstructor.listOfPhElements.Count);

            Assert.AreEqual(0, elementConstructor.listBptNotPairedIDs.Count);
            Assert.AreEqual(0, elementConstructor.listEptNotPairedIDs.Count);

            Assert.AreEqual("Otis Proprietary &amp; Confidential – for internal distribution only", elementConstructor.listOfBptEptElements[0].TextBetween);
            Assert.AreEqual("&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\" size=\"9\" complexscriptssize=\"9\"&gt;", elementConstructor.listOfBptEptElements[0].BptElement.Content);
            Assert.AreEqual("&lt;/cf&gt;", elementConstructor.listOfBptEptElements[0].EptElement.Content);

        }

        [TestMethod]
        public void TransUnitElements_Parsing_Test_2()
        {

            TransUnitElements elementConstructor = new TransUnitElements(TestString0);

            Assert.AreEqual(0, elementConstructor.listOfBptEptElements.Count);
            Assert.AreEqual(0, elementConstructor.listOfItElements.Count);
            Assert.AreEqual(0, elementConstructor.listOfPhElements.Count);

            Assert.AreEqual(0, elementConstructor.listBptNotPairedIDs.Count);
            Assert.AreEqual(0, elementConstructor.listEptNotPairedIDs.Count);

        }

    }
}
