using Infrastructure.Models;

namespace ApplicationCore.AppServices
{
    public interface IImportService
    {
        bool Import(Provider provider);
    }
}
