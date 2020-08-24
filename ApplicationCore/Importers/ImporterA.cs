using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Importers
{
    public class ImporterA : IImporter
    {
        private string _json;

        public ImporterA(string json)
        {
            _json = json;
        }

        public IList<Product> Import()
        {
            throw new NotImplementedException();
        }
    }
}
