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

        /*Fields*/

        public List<BptEptElement> listOfBptEptElements = new List<BptEptElement>();
      
        public List<PH> listOfPhElements = new List<PH>();
        public List<IT> listOfItElements = new List<IT>();

        public List<BPT> listOfBpt = new List<BPT>();
        public List<EPT> listOfEpt = new List<EPT>();

        public List<int> listBptNotPairedIDs;
        public List<int> listEptNotPairedIDs;

        /*Properties*/


        /*Methods*/

        public bool IsBptNotPaired()
        {
            if(listBptNotPairedIDs.Count != 0)
            {
                return true;
            }

            return false;

        }

        public bool IsEptNotPaired()
        {
            if (listEptNotPairedIDs.Count != 0)
            {
                return true;
            }

            return false;

        }

        public BPT GetBptByID(int id)
        {
            if(listOfBpt.Exists(x => x.ID == id))
            {
                return listOfBpt.Find(x => x.ID == id);
            }

            return null;
        }

        public EPT GetEptByID(int id)
        {
            if (listOfEpt.Exists(x => x.ID == id))
            {
                return listOfEpt.Find(x => x.ID == id);
            }

            return null;
        }

        public PH GetPhByID(int id)
        {
            if (listOfPhElements.Exists(x => x.ID == id))
            {
                return listOfPhElements.Find(x => x.ID == id);
            }

            return null;
        }

        /*Constructors*/



        public TransUnitElementsConstructor(string transUnitText)
        {
            Regex bptTag = new Regex("<bpt.*?id=\"\\d+\"?>.*?</bpt>");
            Regex eptTag = new Regex("<ept.*?id=\"\\d+\"?>.*?</ept>");

            Regex itTag = new Regex("<it.*?id=\"\\d+\"?>.*?</it>");
            Regex phTag = new Regex("<ph.*?id=\"\\d+\"?>.*?</ph>");

            MatchCollection bptMatchList = bptTag.Matches(transUnitText);
            var listOfBptStrings = bptMatchList.Cast<Match>().Select(match => match.Value).ToList();

            MatchCollection eptMatchList = eptTag.Matches(transUnitText);
            var listOfEptStrings = eptMatchList.Cast<Match>().Select(match => match.Value).ToList();

            MatchCollection itMatchList = itTag.Matches(transUnitText);
            var listOfItStrings = itMatchList.Cast<Match>().Select(match => match.Value).ToList();

            MatchCollection phMatchList = phTag.Matches(transUnitText);
            var listOfPhStrings = phMatchList.Cast<Match>().Select(match => match.Value).ToList();

            /*I think that here there should be validation added to check if all corresponding elements in the list string 
             have the same index as matcheslist. */

            BPT auxiliaryBpt;
            EPT auxiliaryEpt;

            IT auxiliaryIt;
            PH auxiliaryPh;

            BptEptElement auxiliaryBptEptElement;

            int auxiliaryIndex;
            Match bptMatch;
            Match eptMatch;

            /*Initializing list of BPT, EPT, PH and IT objects.*/

            foreach (string bpt in listOfBptStrings)
            {
                auxiliaryBpt = new BPT(bpt);
                listOfBpt.Add(auxiliaryBpt);
            }

            foreach (string ept in listOfEptStrings)
            {              
                auxiliaryEpt = new EPT(ept);
                listOfEpt.Add(auxiliaryEpt);
            }

            foreach (string ph in listOfPhStrings)
            {
                auxiliaryPh = new PH(ph);
                listOfPhElements.Add(auxiliaryPh);
            }

            foreach (string it in listOfItStrings)
            {
                auxiliaryIt = new IT(it);
                listOfItElements.Add(auxiliaryIt);
            }

            /*All all bpt tag has to have ept tag but not otherwise, so that's why I search through ept list and initialize 
              BptEpt objects. 
              1 Case - Ept tag list is not empty. We want all pairs bpt-ept in this case.
              2 Case - Some Ept doesn't have a paired Bpt tag - so corresponding Bpt tag should be places in some previous 
              trans-unit note. We should be able to save this information.
              3 Case - Some Bpt tag doesn't have paired Ept tag so this information should be stored and used in the Case 2. 
              And in case of 2 and 3 we want to create a EptBpt object on the level of Xliff document. */

            if (listOfEpt.Count != 0)
            {
                foreach (EPT ept in listOfEpt)
                {
                    if (listOfBpt.Exists(x => x.ID == ept.ID))
                    {

                        auxiliaryIndex = listOfBpt.FindIndex(x => x.ID == ept.ID);
                        bptMatch = bptMatchList[auxiliaryIndex];

                        auxiliaryIndex = listOfEpt.FindIndex(x => x.ID == ept.ID);
                        eptMatch = eptMatchList[auxiliaryIndex];

                        auxiliaryBptEptElement = new BptEptElement(transUnitText.Substring(bptMatch.Index,
                                                        eptMatch.Index + eptMatch.Length - bptMatch.Index));

                        listOfBptEptElements.Add(auxiliaryBptEptElement);

                    }
                    else
                    {
                        listEptNotPairedIDs.Add(ept.ID);
                    }
                }
            }
            else if(listOfBpt.Count != 0)
            {
                foreach(BPT bpt in listOfBpt)
                {
                    listBptNotPairedIDs.Add(bpt.ID);
                }
            }

        }
    }
}
