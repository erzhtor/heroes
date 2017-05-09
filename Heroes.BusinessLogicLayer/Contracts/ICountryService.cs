using Heroes.Data.Models;
using Heroes.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Heroes.BusinessLogicLayer.Contracts
{
    public interface ICountryService
    {
        IEnumerable<CountryDTO> GetCountries(Expression<Func<Country, bool>> filter = null);
        CountryDTO GetCountryById(int id);
        void UpdateCountry(CountryDTO countryToUpdate);
        CountryDTO AddCountry(CountryDTO countryToAdd);
        CountryDTO DeleteCountry(int id);
        bool CountryExists(int id);
    }
}
