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
        IEnumerable<CountryDTO> GetAll(Expression<Func<Country, bool>> filter = null);
        CountryDTO GetById(int id);
        void Update(CountryDTO countryToUpdate);
        CountryDTO Add(CountryDTO countryToAdd);
        CountryDTO Delete(int id);
        bool CountryExists(int id);
    }
}
