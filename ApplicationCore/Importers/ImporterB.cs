using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ApplicationCore.Importers
{
    public class ImporterB : IImporter
    {
        private XDocument _xDocument;

        public ImporterB(XDocument xDocument)
        {
            _xDocument = xDocument;
        }
        public IList<Product> Import()
        {
            throw new NotImplementedException();
        }
    }
}
