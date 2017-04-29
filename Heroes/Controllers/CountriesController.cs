﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Heroes.DataAccessLayer;
using Heroes.DataAccessLayer.Models;
using Heroes.Data.Models;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using System.Threading.Tasks;

namespace Heroes.Controllers
{
    public class CountriesController : ApiController
    {
        private EntityContext db = new EntityContext();

        // GET: api/Countries
        public IQueryable<CountryDTO> GetCountries()
        {
            return db.Countries.ProjectTo<CountryDTO>();
        }

        // GET: api/Countries/5
        [ResponseType(typeof(CountryDTO))]
        public async Task<IHttpActionResult> GetCountry(int id)
        {
            var country = await db.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<CountryDTO>(country));
        }

        // PUT: api/Countries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCountry(int id, CountryDTO countryDto)
        {
            var country = Mapper.Map<Country>(countryDto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != country.ID)
            {
                return BadRequest();
            }

            db.Entry(country).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Countries
        [ResponseType(typeof(CountryDTO))]
        public async Task<IHttpActionResult> PostCountry(CountryDTO countryDto)
        {
            var country = Mapper.Map<Country>(countryDto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Countries.Add(country);
            await db.SaveChangesAsync();

            var result = Mapper.Map<CountryDTO>(country);
            return CreatedAtRoute("DefaultApi", new { id = country.ID }, result);
        }

        // DELETE: api/Countries/5
        [ResponseType(typeof(CountryDTO))]
        public async Task<IHttpActionResult> DeleteCountry(int id)
        {
            var country = await db.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            db.Countries.Remove(country);
            db.SaveChanges();

            return Ok(Mapper.Map<CountryDTO>(country));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryExists(int id)
        {
            return db.Countries.Count(e => e.ID == id) > 0;
        }
    }
}