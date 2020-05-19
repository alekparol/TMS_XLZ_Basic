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
    public class Target_Tests
    {

        public string xliffPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\content.xlf";


        [TestMethod]
        public void Target_Smoke_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[0]);

            Assert.IsNotNull(target);
            Assert.IsTrue(target.ParsingSuccess);

        }

        [TestMethod]
        public void Target_Smoke_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[0]);

            Assert.AreEqual("<AlternateContent><Choice/>", target.InnerText);
            Assert.AreEqual("<bpt id=\"1\">&lt;AlternateContent&gt;</bpt><ph id=\"2\">&lt;Choice/&gt;</ph>", target.InnerXml);

            Assert.AreEqual("<target><bpt id=\"1\">&lt;AlternateContent&gt;</bpt><ph id=\"2\">&lt;Choice/&gt;</ph></target>", target.OuterXml);

        }

        /*Testing ParsingSuccess property on the Trans-Unit node without <target> tags.*/

        [TestMethod]
        public void Target_Parsing_Success_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[12]);
            Assert.AreEqual(false, target.ParsingSuccess);

        }

        /*Testing ParsingSuccess property on the Trans-Unit node without </target> tag or <target> is useless, as this is checked
         *by the XmlDocument.Load() and exception is thrown as the file is not well formed xml.
         *Therefore also testing those methods and classes on the XLF document where some trans-unit node does not contain closing or 
         *starting tags of <bpt>,<ept>,<it>,<ph> elements is useless.*/

        /*Testing ParsingSuccess property on the Trans-Unit node without <target> tags and with <target> tags.*/

        [TestMethod]
        public void Target_Parsing_Success_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[12]);
            Assert.AreEqual(false, target.ParsingSuccess);

        }

        /*Testing TargetElements field on the target node which contains one <bpt> tag.*/

        [TestMethod]
        public void Target_BPT_Elements_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[0]);
            Assert.AreEqual(1, target.TargetElements.listOfBpt.Count);

        }

        /*Testing TargetElements field on the target node which does not contain <bpt> tags.*/

        [TestMethod]
        public void Target_BPT_Elements_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[2]);
            Assert.AreEqual(0, target.TargetElements.listOfBpt.Count);

        }

        /*Testing TargetElements field on the target node which contains mutliple <bpt> tags.*/

        [TestMethod]
        public void Target_BPT_Elements_Test_3()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[24]);
            Assert.AreEqual(6, target.TargetElements.listOfBpt.Count);

        }

        /*Testing TargetElements field on the target node which contains one <ept> tag.*/

        [TestMethod]
        public void Target_EPT_Elements_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[2]);
            Assert.AreEqual(1, target.TargetElements.listOfEpt.Count);

        }

        /*Testing TargetElements field on the target node which does not contain <ept> tags.*/

        [TestMethod]
        public void Target_EPT_Elements_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[1]);
            Assert.AreEqual(0, target.TargetElements.listOfEpt.Count);

        }

        /*Testing TargetElements field on the target node which contains mutliple <ept> tags.*/

        [TestMethod]
        public void Target_EPT_Elements_Test_3()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[24]);
            Assert.AreEqual(6, target.TargetElements.listOfEpt.Count);

        }

        /*Testing TargetElements field on the target node which contains one <ph> tag.*/

        [TestMethod]
        public void Target_PH_Elements_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[0]);
            Assert.AreEqual(1, target.TargetElements.listOfPh.Count);

        }

        /*Testing TargetElements field on the target node which does not contain <ph> tags.*/

        [TestMethod]
        public void Target_PH_Elements_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[1]);
            Assert.AreEqual(0, target.TargetElements.listOfEpt.Count);

        }

        /*Testing TargetElements field on the target node which contains mutliple <ept> tags.*/

        [TestMethod]
        public void Target_PH_Elements_Test_3()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[23]);
            Assert.AreEqual(2, target.TargetElements.listOfPh.Count);

        }

        /*Testing TargetElements field on the target node which contains one <it> tag.*/

        [TestMethod]
        public void Target_IT_Elements_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[11]);
            Assert.AreEqual(1, target.TargetElements.listOfIt.Count);

        }

        /*Testing TargetElements field on the target node which does not contain <it> tags.*/

        [TestMethod]
        public void Target_IT_Elements_Test_2()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[10]);
            Assert.AreEqual(0, target.TargetElements.listOfIt.Count);

        }

        /*Testing TargetElements field on the target node which contains mutliple <it> tags.*/

        [TestMethod]
        public void Target_IT_Elements_Test_3()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");

            Target target = new Target(transUnitList[24]);
            Assert.AreEqual(2, target.TargetElements.listOfIt.Count);

        }

        /*Tests of Target as an extension of the XmlNode class. */

        [TestMethod]
        public void Target_XmlNode_Test_1()
        {

            XmlDocument doc = new XmlDocument();
            doc.Load(xliffPath);

            XmlNodeList transUnitList = doc.GetElementsByTagName("trans-unit");
            XmlNode xmlNode = transUnitList[0];
            XmlNode correspondingChild = xmlNode.SelectSingleNode("./target");

            Target target = new Target(xmlNode);

            Assert.AreEqual(correspondingChild.InnerText, target.InnerText);
            Assert.AreEqual(correspondingChild.InnerXml, target.InnerXml);
            Assert.AreEqual(correspondingChild.OuterXml, target.OuterXml);

        }
    }
}