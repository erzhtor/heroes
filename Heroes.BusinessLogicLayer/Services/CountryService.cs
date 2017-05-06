using Heroes.BusinessLogicLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Heroes.Data.Models;
using Heroes.DataAccessLayer.Models;
using System.Linq.Expressions;
using Heroes.DataAccessLayer.GenericRepository;
using Heroes.DataAccessLayer.UnitOfWork;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace Heroes.BusinessLogicLayer.Services
{
    public class CountryService : BaseService, ICountryService
    {
        private readonly IGenericRepository<Country> countryRepository;

        public CountryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            countryRepository = this.unitOfWork.GetRepository<Country>();
        }

        public CountryDTO Add(CountryDTO countryToAdd)
        {
            var country = Mapper.Map<Country>(countryToAdd);
            countryRepository.Insert(country);
            unitOfWork.Save();
            return Mapper.Map<CountryDTO>(country);
        }

        public bool CountryExists(int id)
        {
            return countryRepository.GetById(id) != null;
        }

        public CountryDTO Delete(int id)
        {
            var country = countryRepository.GetById(id);
            var countryDto = Mapper.Map<CountryDTO>(country);
            countryRepository.Delete(country);
            unitOfWork.Save();
            return countryDto;
        }

        public IEnumerable<CountryDTO> GetAll(Expression<Func<Country, bool>> filter = null)
        {
            return countryRepository.Get(filter).ProjectTo<CountryDTO>();
        }

        public CountryDTO GetById(int id)
        {
            var country = countryRepository.GetById(id);
            return Mapper.Map<CountryDTO>(country);
        }

        public void Update(CountryDTO countryToUpdate)
        {
            var country = countryRepository.GetById(countryToUpdate.ID);
            Mapper.Map(countryToUpdate, country);
            unitOfWork.Save();
        }
    }
}
