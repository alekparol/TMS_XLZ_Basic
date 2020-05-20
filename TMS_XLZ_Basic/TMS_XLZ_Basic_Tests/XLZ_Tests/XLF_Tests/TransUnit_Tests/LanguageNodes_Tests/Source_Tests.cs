using System.CodeDom.Compiler;
using TMS_XLZ_Basic;
using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Text.RegularExpressions;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Schema;

namespace TMS_XLZ_Basic_Tests.XLZ_Tests.Xliff_Tests
{
    [TestClass]
    public class Source_Tests
    {

        public string xliffPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\content.xlf";


        [TestMethod]
        public void Source_Smoke_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[0]);

            Assert.IsNotNull(source);
            Assert.IsTrue(source.ParsingSuccess);
            
        }

        [TestMethod]
        public void Source_Smoke_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[0]);

            Assert.AreEqual("<AlternateContent><Choice/>", source.InnerText);
            Assert.AreEqual("<bpt id=\"1\">&lt;AlternateContent&gt;</bpt><ph id=\"2\">&lt;Choice/&gt;</ph>", source.InnerXml);

            Assert.AreEqual("<source><bpt id=\"1\">&lt;AlternateContent&gt;</bpt><ph id=\"2\">&lt;Choice/&gt;</ph></source>", source.OuterXml);

        }

        /*Testing ParsingSuccess property on the Trans-Unit node without <source> tags.*/

        [TestMethod]
        public void Source_Parsing_Success_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[12]);
            Assert.AreEqual(false, source.ParsingSuccess);

        }

        /*Testing ParsingSuccess property on the Trans-Unit node without </source> tag or <source> is useless, as this is checked
         *by the XmlDocument.Load() and exception is thrown as the file is not well formed xml.
         *Therefore also testing those methods and classes on the XLF document where some trans-unit node does not contain closing or 
         *starting tags of <bpt>,<ept>,<it>,<ph> elements is useless.*/

        /*Testing ParsingSuccess property on the Trans-Unit node without <source> tags and with <target> tags.*/

        [TestMethod]
        public void Source_Parsing_Success_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[12]);
            Assert.AreEqual(false, source.ParsingSuccess);

        }

        /*Testing SourceElements field on the source node which contains one <bpt> tag.*/

        [TestMethod]
        public void Source_BPT_Elements_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[0]);
            Assert.AreEqual(1, source.SourceElements.listOfBpt.Count);

        }

        /*Testing SourceElements field on the source node which does not contain <bpt> tags.*/

        [TestMethod]
        public void Source_BPT_Elements_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[2]);
            Assert.AreEqual(0, source.SourceElements.listOfBpt.Count);

        }

        /*Testing SourceElements field on the source node which contains mutliple <bpt> tags.*/

        [TestMethod]
        public void Source_BPT_Elements_Test_3()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[24]);
            Assert.AreEqual(6, source.SourceElements.listOfBpt.Count);

        }

        /*Testing SourceElements field on the source node which contains one <ept> tag.*/

        [TestMethod]
        public void Source_EPT_Elements_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[2]);
            Assert.AreEqual(1, source.SourceElements.listOfEpt.Count);

        }

        /*Testing SourceElements field on the source node which does not contain <ept> tags.*/

        [TestMethod]
        public void Source_EPT_Elements_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[1]);
            Assert.AreEqual(0, source.SourceElements.listOfEpt.Count);

        }

        /*Testing SourceElements field on the source node which contains mutliple <ept> tags.*/

        [TestMethod]
        public void Source_EPT_Elements_Test_3()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[24]);
            Assert.AreEqual(6, source.SourceElements.listOfEpt.Count);

        }

        /*Testing SourceElements field on the source node which contains one <ph> tag.*/

        [TestMethod]
        public void Source_PH_Elements_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[0]);
            Assert.AreEqual(1, source.SourceElements.listOfPh.Count);

        }

        /*Testing SourceElements field on the source node which does not contain <ph> tags.*/

        [TestMethod]
        public void Source_PH_Elements_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[1]);
            Assert.AreEqual(0, source.SourceElements.listOfEpt.Count);

        }

        /*Testing SourceElements field on the source node which contains mutliple <ept> tags.*/

        [TestMethod]
        public void Source_PH_Elements_Test_3()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[23]);
            Assert.AreEqual(2, source.SourceElements.listOfPh.Count);

        }

        /*Testing SourceElements field on the source node which contains one <it> tag.*/

        [TestMethod]
        public void Source_IT_Elements_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[11]);
            Assert.AreEqual(2, source.SourceElements.listOfIt.Count);

        }

        /*Testing SourceElements field on the source node which does not contain <it> tags.*/

        [TestMethod]
        public void Source_IT_Elements_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[10]);
            Assert.IsNull(source.SourceElements.listOfIt);

        }

        /*Testing SourceElements field on the source node which contains mutliple <it> tags.*/

        [TestMethod]
        public void Source_IT_Elements_Test_3()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Source source = new Source(transUnitList[24]);
            Assert.AreEqual(2, source.SourceElements.listOfIt.Count);

        }

        /*Tests of Source as an extension of the XmlNode class. */

        [TestMethod]
        public void Source_XmlNode_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            XmlNode xmlNode = transUnitList[0];
            XmlNode correspondingChild = xmlNode.SelectSingleNode("./source");

            Source source = new Source(xmlNode);

            Assert.AreEqual(correspondingChild.InnerText, source.InnerText);
            Assert.AreEqual(correspondingChild.InnerXml, source.InnerXml);
            Assert.AreEqual(correspondingChild.OuterXml, source.OuterXml);

        }
    }
}
