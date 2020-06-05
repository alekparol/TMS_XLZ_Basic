using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TMS_XLZ_Basic.XLZ.XLF.Meta
{
    class Meta
    {

        /* Fields */

        private string documentRootName;

        /* Properties */

        /* Methods */

        /* Constructors */

        public Meta(XmlDocument inputFile)
        {

            documentRootName = inputFile.DocumentElement.Name;

        }

    }
}
