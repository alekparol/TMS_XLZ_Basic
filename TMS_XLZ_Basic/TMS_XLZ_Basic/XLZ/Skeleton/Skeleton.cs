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

namespace TMS_XLZ_Basic
{
    class Skeleton
    {

        /* Fields */

        public XmlDocument baseDocument;

        public List<SkeletonUnit> skeletonUnitsList;


        /* Methods */

        public SkeletonUnit GetSkeletonUnitByID(int ID)
        {
            for (int i = 0; i < skeletonUnitsList.Count; i++)
            {

                if (skeletonUnitsList[i].GetSkeletonUnitID() == ID)
                {
                    return skeletonUnitsList[i];
                }

            }

            return null;
        }

        /* Constructors */

        public Skeleton(XmlDocument inputFile)
        {
            baseDocument = inputFile;

            skeletonUnitsList = new List<SkeletonUnit>();

            XmlNodeList auxillaryList = baseDocument.GetElementsByTagName("tu-placeholder");
            SkeletonUnit auxillarySkeletonUnit;

            foreach(XmlNode entity in auxillaryList)
            {

                auxillarySkeletonUnit = new SkeletonUnit(entity);
                skeletonUnitsList.Add(auxillarySkeletonUnit);

            }

        }


    }
}
