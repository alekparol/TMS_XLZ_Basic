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
using TMS_XLZ_Basic.XLZ.Xliff;

namespace TMS_XLZ_Basic_Tests
{
    [TestClass]
    public class TransUnitData_Tests
    {

        public string xliffPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\content.xlf";


        [TestMethod]
        public void TransUnitData_Creation_Test_1()
        {

            DoublyLinkedList testList = new DoublyLinkedList();

            Assert.AreEqual(0, testList.Count);
            //Assert.IsNull(testList.FirstNode);

        }
    }
}
