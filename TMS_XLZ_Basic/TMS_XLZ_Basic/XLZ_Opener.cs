using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System;
using System.IO.Compression;

namespace TMS_XLZ_Basic
{
    class XLZ_Opener
    {

        public static string sXLZ(string sFile)
        {
            string content = "";

            try
            {
                using(ZipArchive xlzArchive = ZipFile.OpenRead(sFile))
                {
                    foreach (ZipArchiveEntry file in xlzArchive.Entries)
                    {
                        if (file.Name.ToLower().EndsWith(".xlf"))
                        {
                            using (Stream stream = file.Open())
                            {
                                StreamReader reader = new StreamReader(stream);
                                content = reader.ReadToEnd();
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Please check your file: {0} - this is not a valid archive - possibility to process file outside of TMS may be required:ex {1}", Path.GetFileName(sFile), ex.ToString()));
            }
            return content;
        }
    }
}
