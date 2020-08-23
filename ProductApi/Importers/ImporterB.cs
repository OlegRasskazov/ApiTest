using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductApi.Importers
{
    public class ImporterB: IImporter
    {
        private XDocument _xDocument;

        public ImporterB(XDocument xDocument)
        {
            _xDocument = xDocument;
        }
        public Provider Import()
        {
            throw new NotImplementedException();
        }
    }
}
