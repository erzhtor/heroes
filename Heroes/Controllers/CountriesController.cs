using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Heroes.Data.Models;
using AutoMapper;
using System.Threading.Tasks;
using Heroes.BusinessLogicLayer.Contracts;

namespace Heroes.Controllers
{
    public class CountriesController : ApiController
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        // GET: api/Countries
        public IEnumerable<CountryDTO> GetCountries()
        {
            return countryService.GetAll();
        }

        // GET: api/Countries/5
        [ResponseType(typeof(CountryDTO))]
        public IHttpActionResult GetCountry(int id)
        {
            var country = countryService.GetById(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<CountryDTO>(country));
        }

        // PUT: api/Countries/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCountry(int id, CountryDTO countryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != countryDto.ID)
            {
                return BadRequest();
            }

            if (!countryService.CountryExists(id))
            {
                return NotFound();
            }

            countryService.Update(countryDto);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Countries
        [ResponseType(typeof(CountryDTO))]
        public IHttpActionResult PostCountry(CountryDTO countryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newCountry = countryService.Add(countryDto);
            return CreatedAtRoute("DefaultApi", new { id = newCountry.ID }, newCountry);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(CountryDTO))]
        public IHttpActionResult DeleteCountry(int id)
        {
            var deletedCountry = countryService.Delete(id);
            if (deletedCountry == null)
            {
                return NotFound();
            }
            return Ok(deletedCountry);
        }
    }
}