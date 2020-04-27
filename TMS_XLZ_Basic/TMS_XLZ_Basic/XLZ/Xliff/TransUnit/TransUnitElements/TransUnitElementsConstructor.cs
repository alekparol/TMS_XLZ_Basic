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

namespace TMS_XLZ_Basic.XLZ.Xliff.TransUnit.TransUnitElements
{
    class TransUnitElementsConstructor
    {

        public List<BPT> listOfBPT;
        public List<string> listOfEPT;
        public List<string> listOfPH;

        public TransUnitElementsConstructor(string transUnitText)
        {

            Regex regexBPT = new Regex("(<bpt.*?>.*</?bpt.*?>)");
            MatchCollection matchesBPT = regexBPT.Matches(transUnitText);

            BPT auxillaryBPT;

            foreach (Match en in matchesBPT)
            {
                auxillaryBPT = new BPT(en.Value);
                listOfBPT.Add(auxillaryBPT);
            }
        }

    }
}
