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
            Console.WriteLine(xliffFile.transUnitList.Item(0).Attributes["id"].Value);
            Console.WriteLine(xliffFile.IfTransUnitIsTranslatable(1));
            Console.WriteLine(xliffFile.GetTransUnitByID(1).InnerText);

			Thread.Sleep(2000);



        }
    }
}
