using SharedModels.Models;

namespace ResourceServer.Repositories
{
    public interface ICountryRepository
    {
        Task <IEnumerable<Country>> GetAllCountries();
    }
}
