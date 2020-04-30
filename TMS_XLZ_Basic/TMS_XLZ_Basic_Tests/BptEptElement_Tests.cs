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

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_0_0_0_1()
        {
            string testBptEptRaw = "<bpt id=\"1\">&lt;</bpt>Otis<ept id=\"1\">&lt;/cf&gt;</ept>";

            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);
            Assert.AreNotEqual(null, parsedBptEpt.BptElement);
            Assert.AreNotEqual(null, parsedBptEpt.EptElement);

            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);
            Assert.AreEqual(1, parsedBptEpt.EptElement.EptID);

            Assert.IsTrue(parsedBptEpt.IsPaired);
            Assert.AreEqual(1, parsedBptEpt.ElementID);

        }

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_0_0_1()
        {
            string testBptEptRaw = "<bpt id=\"1\">&lt;</bpt>Otis<ept id=\"2\">&lt;/cf&gt;</ept>";

            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.IsTrue(parsedBptEpt.ParsingSuccess);
            Assert.AreNotEqual(null, parsedBptEpt.BptElement);
            Assert.AreNotEqual(null, parsedBptEpt.EptElement);

            Assert.AreEqual(1, parsedBptEpt.BptElement.BptID);
            Assert.AreEqual(2, parsedBptEpt.EptElement.EptID);

        }

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_0_1()
        {
            string testBptEptRaw = "<bpt id=\"1\">&lt;</bpt><bpt id=\"2\">&lt;</bpt>Otis Proprietary &amp; Confidential – for internal distribution only<ept id=\"2\">&lt;/cf&gt;</ept>";

            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.AreEqual(true, parsedBptEpt.ParsingSuccess);
            Assert.AreEqual(true, parsedBptEpt.IsNested);
            //Assert.AreEqual(2, parsedBptEpt.ElementID);
            Assert.AreEqual("Otis Proprietary &amp; Confidential – for internal distribution only", parsedBptEpt.TextBetween);


        }

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_1()
        {
            string testBptEptRaw = "<bpt id=\"1\">&lt;cf font=&quot;Arial&quot; asiantextfont=&quot;Arial&quot; complexscriptsfont=&quot;Arial&quot; size=&quot;9&quot; complexscriptssize=&quot;9&quot;&gt;</bpt>Otis Proprietary &amp; Confidential – for internal distribution only<ept id=\"1\">&lt;/cf&gt;</ept>";

            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.AreEqual(true, parsedBptEpt.ParsingSuccess);
            Assert.AreEqual(1, parsedBptEpt.ElementID);
            Assert.AreEqual("Otis Proprietary &amp; Confidential – for internal distribution only", parsedBptEpt.TextBetween);


        }

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_2()
        {
            string testBptEptRaw = "</ept><bpt id =\"2\">&lt;hyperlink Id = &quot;1&quot; tkn=&quot;734&quot;&gt;</bpt><bpt id = \"3\" > &lt; cf style = &quot; Hyperlink&quot; font=&quot;Arial&quot; asiantextfont=&quot;Arial&quot; complexscriptsfont=&quot;Arial&quot;&gt;</bpt>https://connect.otis.com/news/Pages/Global-Coronavirus-Update.aspx<ept id=\"3\">&lt;/cf&gt;</ept><ept id=\"2\">";

            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.AreEqual(true, parsedBptEpt.ParsingSuccess);
            Assert.AreEqual(false, parsedBptEpt.IsPaired);        


        }

        [TestMethod]
        public void BptEptElement_Parsing_Success_Test_3()
        {
            string testBptEptRaw = "<bpt id=\"1\">&lt;cf font=&quot;Arial&quot; asiantextfont=&quot;Arial&quot; complexscriptsfont=&quot;Arial&quot; size=&quot;9&quot; complexscriptssize=&quot;9&quot;&gt;</bpt>Otis Proprietary &amp; Confidential – for internal distribution only<bpt id=\"2\">&lt;/cf&gt;</bpt>dd<ept id=\"1\"></ept>";

            BptEptElement parsedBptEpt = new BptEptElement(testBptEptRaw);

            Assert.AreEqual(true, parsedBptEpt.ParsingSuccess);

            Assert.AreEqual(true, parsedBptEpt.IsPaired);



            Assert.AreEqual(1, parsedBptEpt.ElementID);
            Assert.AreEqual(true, parsedBptEpt.IsNested);
            //Assert.AreEqual("Otis Proprietary &amp; Confidential – for internal distribution only", parsedBptEpt.TextBetween);


        }


    }
}
