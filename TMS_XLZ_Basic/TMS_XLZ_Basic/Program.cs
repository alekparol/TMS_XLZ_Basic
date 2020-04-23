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

namespace TMS_XLZ_Basic
{
    class Program
    {
        static void Main(string[] args)
        {

            XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\XLZ C# Scripts\\content.xlf");


            Xliff xliffFile = new Xliff(doc);
            Console.WriteLine(xliffFile.listOfTransUnitObjects.Count);
            XmlNode xmlNode = xliffFile.transUnitList.Item(8);
            Console.WriteLine(xliffFile.transUnitList.Item(0).Attributes["id"].Value);
            Console.WriteLine(xliffFile.IfTransUnitIsTranslatable(1));
            Console.WriteLine(xliffFile.GetTransUnitByID(1).InnerText);
            Console.WriteLine(xliffFile.GetTransUnitByID(1).SelectSingleNode("./source").InnerText);
            Console.WriteLine(xliffFile.GetSourceText(1));
            TransUnit tr1 = xliffFile.CreateTransUnitNode(xmlNode);
            Console.WriteLine(tr1.GetSourceText());
            Console.WriteLine(xmlNode.InnerXml);
            Console.WriteLine(tr1.GetSourceInnerXmlWithoutText());
            //Console.WriteLine(tr1.GetTargetText());


			Thread.Sleep(2000);



        }
    }
}
