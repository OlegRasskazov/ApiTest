using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Importers
{
    public interface IImporter
    {
        Provider Import();
    }
}
