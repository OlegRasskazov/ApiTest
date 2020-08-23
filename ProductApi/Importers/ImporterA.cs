using ProductApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi.Importers
{
    public class ImporterA : IImporter
    {
        private string _json;

        public ImporterA(string json)
        {
            _json = json;
        }

        public Provider Import()
        {
            throw new NotImplementedException();
        }
    }
}
