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

            /* This regex will match:
             * - <ept></ept> tags in content.xlf,
             * - <bpt></bpt> tags in content.xlf,
             * - <ph></ph> tags in content.xlf
             * And all the content which is in the scope of those tags and their attributes as well.*/
            Regex rx = new Regex("(<ept.*?>.*</?ept.*?>)|(<bpt.*?>.*</?bpt.*?>)|(<ph.*?>.*</?ph.*?>)");

            Console.WriteLine(sourceXliff.transUnitTranslationYesList[0].transUnitNode.LastChild.InnerXml);
            Console.WriteLine(targetXliff.transUnitTranslationYesList[0].transUnitNode.FirstChild.InnerXml);

            Console.WriteLine(sourceXliff.transUnitTranslationYesList[0].GetSourceInnerXmlWithoutText());
            Console.WriteLine(targetXliff.transUnitTranslationYesList[0].GetSourceInnerXmlWithoutText());

            XmlDocument sourceSKL = new XmlDocument();
            XmlDocument targetSKL = new XmlDocument();

            sourceSKL.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\de-de\\source\\skeleton.skl");
            targetSKL.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\de-de\\target\\skeleton.skl");

            Skeleton sourceSkeleton = new Skeleton(sourceSKL);
            Skeleton targetSkeleton = new Skeleton(targetSKL);

            //Console.WriteLine(sourceSkeleton.skeletonUnitsList[0].formattingNode.InnerText);
            //Console.WriteLine(targetSkeleton.skeletonUnitsList[0].formattingNode.InnerText);

            XmlElement targetNode;

            for (int i = 0; i < sourceXliff.transUnitTranslationYesList.Count; i++)
            {

                int ID = sourceXliff.transUnitTranslationYesList[i].GetTransUnitID();
                targetNode = sourceXLF.CreateElement("target");

                if (sourceXliff.GetTransUnitByID(ID).GetSourceInnerXmlWithoutText() ==
                    targetXliff.GetTransUnitByID(ID).GetSourceInnerXmlWithoutText())
                {
                    if (sourceSkeleton.GetSkeletonUnitByID(ID).formattingNode != null &&
                    targetSkeleton.GetSkeletonUnitByID(ID).formattingNode != null)
                    {
                        if (sourceSkeleton.GetSkeletonUnitByID(ID).formattingNode.InnerText ==
                            targetSkeleton.GetSkeletonUnitByID(ID).formattingNode.InnerText)
                        {

                            targetNode.InnerXml = targetXliff.transUnitTranslationYesList[i].GetSourceXml();

                            sourceXliff.transUnitTranslationYesList[i].transUnitNode.AppendChild(targetNode);

                        }
                    }
                    else
                    {

                        if (sourceSkeleton.GetSkeletonUnitByID(ID).formattingNode == null &&
                            targetSkeleton.GetSkeletonUnitByID(ID).formattingNode == null)
                        {

                            targetNode.InnerXml = targetXliff.transUnitTranslationYesList[i].GetSourceXml();

                            sourceXliff.transUnitTranslationYesList[i].transUnitNode.AppendChild(targetNode);

                        }

                    }
                }     
                        
            }

            /*XmlElement targetNode;

            for(int i = 0; i < sourceXliff.transUnitTranslationYesList.Count; i++)
            {          
                targetNode = sourceXLF.CreateElement("target");
                targetNode.InnerXml = targetXliff.transUnitTranslationYesList[i].GetSourceXml();

                sourceXliff.transUnitTranslationYesList[i].transUnitNode.AppendChild(targetNode);
            }*/

            sourceXLF.Save("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\content.xlf");


			Thread.Sleep(7000);



        }
    }
}
