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
using System.Text.RegularExpressions;

/*This class will construct all tag elements in the given trans unit content.*/

namespace TMS_XLZ_Basic.XLZ.Xliff.TransUnit.TransUnitElements
{
    public class TransUnitElementsConstructor
    {

        public List<BptEptElement> listOfBptEptElements;
        //public List<PhElement> listOfPhElements;
        //public List<ItElement> listOfItElements;

        public List<BPT> listOfBpt = new List<BPT>();
        public List<EPT> listOfEpt = new List<EPT>(); 


        public TransUnitElementsConstructor(string transUnitText)
        {
            Regex bptTag = new Regex("<bpt.*?id=\"\\d+\"?>.*?</bpt>");
            Regex eptTag = new Regex("<ept.*?id=\"\\d+\"?>.*?</ept>");

            MatchCollection bptMatchList = bptTag.Matches(transUnitText);
            var listOfBptStrings = bptMatchList.Cast<Match>().Select(match => match.Value).ToList();

            MatchCollection eptMatchList = eptTag.Matches(transUnitText);
            var listOfEptStrings = eptMatchList.Cast<Match>().Select(match => match.Value).ToList();

            BPT auxiliaryBpt;
            EPT auxiliaryEpt;

            foreach(string bpt in listOfBptStrings)
            {
                auxiliaryBpt = new BPT(bpt);
                listOfBpt.Add(auxiliaryBpt);
            }

            foreach (string ept in listOfEptStrings)
            {
                auxiliaryEpt = new EPT(ept);
                listOfEpt.Add(auxiliaryEpt);
            }

        }
    }
}
