using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS_XLZ_Basic;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TMS_XLZ_Basic_Tests.XLZ_Tests.Skeleton_Tests
{
    [TestClass]
    public class SkeletonUnit_Tests
    {

        public string sklPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\C# Script Block all except yellow highlight\Blocked by the existing script\skeleton.skl";

        /*
         * Case: Constructor without any argument is invoked. 
         * Expected Result: TransUnitNode object with all fields set as null, will be created. 
         * Actual Result: As expected. 
         */

        [TestMethod]
        public void SkeletonUnit_Test_1()
        {
            // Initialization. 
            XmlDocument doc = new XmlDocument();
            doc.Load(sklPath);

            XmlNode skl = doc.GetElementsByTagName("tu-placeholder").Item(0);

            SkeletonUnit sklunit = new SkeletonUnit(skl);

            // Assertions set. 
            Assert.AreEqual(1, sklunit.GetSkeletonUnitID());
            Assert.IsNotNull(sklunit.GetFormattingNode());
            Assert.AreEqual("", sklunit.GetFormattingNode().InnerText);

        }
    }
}
