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

/* When the document is XML with CDATA, nodes don't have "ID" fields filled by number but it is "cdata x.x". */

namespace TMS_XLZ_Basic
{
    class Program
    {
        static void Main(string[] args)
        {

            /*XmlDocument doc = new XmlDocument();
            doc.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\source\\content.xlf");


            Xliff xliffFile = new Xliff(doc);

            Console.WriteLine(xliffFile.transUnitTranslationNoList.Count);
            Console.WriteLine(xliffFile.transUnitTranslationYesList.Count);

            TransUnit tr1 = xliffFile.transUnitTranslationYesList[1];
            Console.WriteLine(tr1.GetTransUnitID());
            Console.WriteLine(tr1.GetTransUnitValidationResults());

            Console.WriteLine(xliffFile.listOfTransUnitObjects.Count);
            XmlNode xmlNode = xliffFile.transUnitList.Item(8);
            Console.WriteLine(xliffFile.transUnitList.Item(0).Attributes["id"].Value);
            Console.WriteLine(xliffFile.GetNodeByID(1).InnerText);
            Console.WriteLine(xliffFile.GetNodeByID(1).SelectSingleNode("./source").InnerText);*/

            XmlDocument sourceXLF = new XmlDocument();
            XmlDocument targetXLF = new XmlDocument();

            sourceXLF.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\de-de\\source\\content.xlf");
            targetXLF.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\de-de\\target\\content.xlf");

            Xliff sourceXliff = new Xliff(sourceXLF);
            Xliff targetXliff = new Xliff(targetXLF);

            Console.WriteLine(sourceXliff.transUnitTranslationYesList[0].GetSourceXml());
            Console.WriteLine(targetXliff.transUnitTranslationYesList[0].GetSourceXml());

            XmlElement targetNode;

            for(int i = 0; i < sourceXliff.transUnitTranslationYesList.Count; i++)
            {
                targetNode = sourceXLF.CreateElement("target");
                targetNode.InnerXml = targetXliff.transUnitTranslationYesList[i].GetSourceXml();

                sourceXliff.transUnitTranslationYesList[i].transUnitNode.AppendChild(targetNode);
            }

            /*int auxillaryID;
            string auxillaryNodeString;

            TransUnit auxillaryTransUnit;

            XmlNode sourceNode;
            XmlElement auxillaryNode;*/

            /*foreach(TransUnit entity in targetXliff.transUnitTranslationYesList)
            {

                auxillaryID = entity.GetTransUnitID();

                auxillaryNode = sourceXLF.CreateElement("target");
                auxillaryTransUnit = targetXliff.GetTransUnitByID(auxillaryID);

                auxillaryNode.InnerXml = auxillaryTransUnit.GetSourceXml();

                sourceNode = sourceXLF.GetElementById(auxillaryID.ToString());
                sourceNode.AppendChild(auxillaryNode);

            }*/

            sourceXLF.Save("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\content.xlf");


			Thread.Sleep(7000);



        }
    }
}
