using TMS_XLZ_Basic;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TMS_XLZ_Basic.XLZ.Xliff;
using System;
using System.IO;

namespace TMS_XLZ_Basic_Tests.XLZ_Tests.XLF_Tests
{
    [TestClass]
    public class XLF_Tests
    {

        public string xliffPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\content.xlf";

        [TestMethod]
        public void XLF_Test_1()
        {

            XLF testXLF = new XLF(xliffPath);

        }

    }
}
