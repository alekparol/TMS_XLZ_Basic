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
using System;
using System.IO;
using System.IO.Compression;
using System.Dynamic;

/* When the document is XML with CDATA, nodes don't have "ID" fields filled by number but it is "cdata x.x". */

/* This regex will match:
             * - <ept></ept> tags in content.xlf,
             * - <bpt></bpt> tags in content.xlf,
             * - <ph></ph> tags in content.xlf
             * And all the content which is in the scope of those tags and their attributes as well.
              Regex rx = new Regex("(<ept.*?>.*</?ept.*?>)|(<bpt.*?>.*</?bpt.*?>)|(<ph.*?>.*</?ph.*?>)");*/

namespace TMS_XLZ_Basic
{
    class Program
    {
        static void Main(string[] args)
        {

            /* 0. Test program.
             * 
             * XmlDocument doc = new XmlDocument();
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

            /* 1. Copying source from one XLZ to the other. 

            XmlDocument sourceXLF = new XmlDocument();
            XmlDocument targetXLF = new XmlDocument();

            sourceXLF.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\de-de\\source\\content.xlf");
            targetXLF.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\de-de\\target\\content.xlf");

            Xliff sourceXliff = new Xliff(sourceXLF);
            Xliff targetXliff = new Xliff(targetXLF);

            Regex rx = new Regex("(<ept.*?>.*</?ept.*?>)|(<bpt.*?>.*</?bpt.*?>)|(<ph.*?>.*</?ph.*?>)");

            Console.WriteLine(sourceXliff.transUnitTranslationYesList[0].transUnitNode.LastChild.InnerXml);
            Console.WriteLine(targetXliff.transUnitTranslationYesList[0].transUnitNode.FirstChild.InnerXml);

            Console.WriteLine(sourceXliff.transUnitTranslationYesList[0].GetSourceInnerXmlWithoutText());
            Console.WriteLine(targetXliff.transUnitTranslationYesList[0].GetSourceInnerXmlWithoutText());

            Console.WriteLine(sourceXliff.transUnitTranslationYesList[0].GetSourceInnerTextWithoutXml()); 
            Console.WriteLine(targetXliff.transUnitTranslationYesList[0].GetSourceInnerTextWithoutXml());

            XmlDocument sourceSKL = new XmlDocument();
            XmlDocument targetSKL = new XmlDocument();

            sourceSKL.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\de-de\\source\\skeleton.skl");
            targetSKL.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\de-de\\target\\skeleton.skl");

            Skeleton sourceSkeleton = new Skeleton(sourceSKL);
            Skeleton targetSkeleton = new Skeleton(targetSKL);

          


            //Console.WriteLine(sourceSkeleton.skeletonUnitsList[0].formattingNode.InnerText);
            //Console.WriteLine(targetSkeleton.skeletonUnitsList[0].formattingNode.InnerText);

            XmlElement targetNode;

            for (int i = 0; i < sourceSkeleton.skeletonUnitsList.Count; i++)
            {
                if (sourceSkeleton.skeletonUnitsList[i].formattingNode != null &&
                    targetSkeleton.skeletonUnitsList[i].formattingNode != null)
                {
                    if(sourceSkeleton.skeletonUnitsList[i].formattingNode.InnerText != 
                       targetSkeleton.skeletonUnitsList[i].formattingNode.InnerText)
                    {
                        /* Then we search through the target skeleton for the formatting node which is the same. 
                         * If the node is the same:
                         * 1) We should get skeletonUnit ID, 
                         * 2) With this ID we can get corresponding transUnit,
                         * 3) TransUnit inner text we save to the auxillary string variable, 
                         * 4) This string we concatate to the previous transUnit which is translatable,
                         * 5) Then we copy the formatting of the skeletonUnit from the step 1), to the skeletonUnit 
                         * of the index [i] on the list. 
                         * 6) The same thing we do for the corresponding transUnit.*/
            /*for(int j = i; j < targetSkeleton.skeletonUnitsList.Count; j++)
            {
                if (targetSkeleton.skeletonUnitsList[j].formattingNode != null)
                {
                    if (sourceSkeleton.skeletonUnitsList[i].formattingNode.InnerText ==
                        targetSkeleton.skeletonUnitsList[j].formattingNode.InnerText)
                    {
                        int skeletonUnitID = targetSkeleton.skeletonUnitsList[j].GetSkeletonUnitID();
                        TransUnit correspondingTransUnit = targetXliff.GetTransUnitByID(skeletonUnitID);

                        string auxillaryString = correspondingTransUnit.GetSourceText();

                        TransUnit previousTranslatableTransUnit = new TransUnit(correspondingTransUnit.transUnitNode.PreviousSibling.PreviousSibling);
                        previousTranslatableTransUnit.innerXml += auxillaryString;

                        targetSkeleton.skeletonUnitsList[j].formattingNode.InnerText = targetSkeleton.skeletonUnitsList[i].formattingNode.InnerText;
                        targetXliff.transUnitList[j].InnerText = targetXliff.transUnitList[i].InnerText;
                    }
                }

            }
        }
    }
}*/

            /*targetSKL.Save("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\skeleton.skl");


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
            sourceXLF.Save("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Translate with the source\\content.xlf");
             */

            /*XmlElement targetNode;

            for(int i = 0; i < sourceXliff.transUnitTranslationYesList.Count; i++)
            {          
                targetNode = sourceXLF.CreateElement("target");
                targetNode.InnerXml = targetXliff.transUnitTranslationYesList[i].GetSourceXml();

                sourceXliff.transUnitTranslationYesList[i].transUnitNode.AppendChild(targetNode);
            }*/

            /* 2. Block Yellow Highlight.
             * Description: blocking other way that TMS scripts - it will block all segments, if whole segment is highlighted, 
             * and it will block only a phrase if only a phrase is highlighted, using tilt tag. 
             * <ph equiv-text="World Safety Day" tilt:type="do-not-translate" id="2">World Safety Day</ph>.
             * Id thing is related to number of <*.?id=\d+.*?> tags in the segment. So firstly we need to check what is the maximal id there
             * and then add one.
             *    */

            /* Of course the initial part should be changed to work on the XLZ files, not content.xlf. */
            //XmlDocument doc = new XmlDocument();
            //doc.Load("C:\\Users\\Aleksander.Parol\\Desktop\\GLT_Engineering\\Documentation\\Script\\C# Script Block all except yellow highlight\\Blocked by the existing script\\content.xlf");

            // Xliff xlifffile = new Xliff(doc);

            //BPT testBPT = new BPT("<bpt id=\"1\">&lt;cf font=\"Arial\" asiantextfont=\"Arial\" complexscriptsfont=\"Arial\"&gt;</bpt>");
            //Console.WriteLine(testBPT.bptID);

            //foreach(TransUnit segemtent in xlifffile.listOfTransUnitObjects)
            //{

            /*If whole inner text is between yellow highligh tags 
             *that is - whole inner text is between <bpt></bpt><ept></ept> tags in which <bpt> there is highlight="yellow".
             * 1. If it is the whole text, script should change only translatable="" attribute in the transUnit into "No".
             * 2. If this is not the whole text, script should add tilt tag.*/

            //}

            /*string aspxFile = File.ReadAllText(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Outlook\2020.04.27\HR Bulk Translations, aspx files ( ENG)\Process\Decodin - Encoding\Business_Resource_Groups.aspx");
            aspxFile = aspxFile.Replace("<!--[if gte mso 9]>", "<placeholder>");
            aspxFile = aspxFile.Replace("<![endif]-->", "</placeholder>");

            string decoded = WebUtility.HtmlDecode(aspxFile);            

            File.WriteAllText(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Outlook\2020.04.27\HR Bulk Translations, aspx files ( ENG)\Process\Decodin - Decoded.aspx", decoded);

            string encoded = WebUtility.HtmlEncode(decoded);
            encoded = encoded.Replace("<placeholder>","<!--[if gte mso 9]>");
            encoded = encoded.Replace("</placeholder>","<![endif]-->");

            File.WriteAllText(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Outlook\2020.04.27\HR Bulk Translations, aspx files ( ENG)\Process\Decodin - Encoded.aspx", encoded);*/


            string aspxFileForEncoding = File.ReadAllText(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\TMS\2020.05.20\Corteva - G_2376630 - Corteva  - Manager_Pages  Part 2 - Eng_PostProcess_Check_H\Job-Change-Checklist.aspx");
            Regex mainRegex = new Regex("<mso:CustomDocumentProperties>([\\S\\W]*)</mso:.*?>");          
            Regex rx = new Regex("<mso:(PublishingPageContent|Keywords|ShortDescription).*?>([\\S\\W]*?)</mso:.*?>");

            aspxFileForEncoding = aspxFileForEncoding.Trim();
            string newAspxFile = aspxFileForEncoding;

            Match msoCustomContent = mainRegex.Match(aspxFileForEncoding);

            MatchCollection msoContent = rx.Matches(msoCustomContent.Groups[1].Value);
            //MatchCollection msoContent = rx.Matches(aspxFileForEncoding);

            List<string> listOfInnerStrings = new List<string>();

            string a;

            foreach(Match en in msoContent)
            {
                a = en.Groups[1].Value;
                listOfInnerStrings.Add(a);
                Console.WriteLine(a);
            }


            foreach(string innerText in listOfInnerStrings)
            {


                Console.WriteLine(innerText);
                Console.WriteLine(WebUtility.HtmlEncode(innerText));

                if (innerText.Length != 0)
                {
                    a = WebUtility.HtmlEncode(innerText);
                    aspxFileForEncoding = aspxFileForEncoding.Replace(innerText, a);
                }

            }

            //Regex nr = new Regex("<mso:PublishingPageContent.*?>(.*?)</mso:PublishingPageContent.*?>");
            //MatchCollection msoContent2 = nr.Matches(aspxFileForEncoding);

            //foreach (Match en in msoContent2)
            //{
            //    a = en.Groups[1].Value;
            //    Console.WriteLine(a);
            //}

            File.WriteAllText(@"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Outlook\2020.05.04\HR Bulk Translations, aspx files ( ENG)\Files which cause problems\new.aspx", aspxFileForEncoding);
            

            /*string xlsxPath = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script\Breaking protection C#\GuiTextLanguagesCatalog.xlsx";
            string xlsxFolder = @"C:\Users\Aleksander.Parol\Desktop\GLT_Engineering\Documentation\Script";

            Regex xmlSheetRegex = new Regex("sheet\\d*\\.xml");
            Regex passwordProtectionRegex = new Regex("<sheetProtection.*?>");

            string readXmlFile;
            string entryName;

            List<string> fileEntries = new List<string>(Directory.GetFiles(xlsxFolder).Where(x => x.ToLowerInvariant().EndsWith("xlsx")));

            foreach (var file in fileEntries)
            {
                using (ZipArchive zipArchive = ZipFile.Open(xlsxPath, ZipArchiveMode.Update))
                {
                    foreach (ZipArchiveEntry entry in zipArchive.Entries)
                    {
                        if (xmlSheetRegex.Match(entry.Name).Value != String.Empty)
                        {
                            entryName = entry.FullName;

                            Stream entryStream = entry.Open();
                            StreamReader reader = new StreamReader(entryStream);


                            readXmlFile = reader.ReadToEnd();
                            readXmlFile = passwordProtectionRegex.Replace(readXmlFile, string.Empty);

                            entryStream.Close();

                            using (Stream overwrite = entry.Open())
                            {
                                StreamWriter writer = new StreamWriter(overwrite);
                                overwrite.SetLength(0);

                                writer.WriteLine(readXmlFile);
                                Console.WriteLine(readXmlFile);
                                writer.Flush();
                            }


                        }

                    }
                }
            }*/

            



            Thread.Sleep(22000);



        }
    }
}
