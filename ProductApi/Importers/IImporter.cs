using ProductApi.Models;

namespace ProductApi.Importers
{
    public interface IImporter
    {
        Provider Import();
    }
}
