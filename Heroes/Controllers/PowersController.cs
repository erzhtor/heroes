using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Heroes.DataAccessLayer;
using Heroes.DataAccessLayer.Models;
using Heroes.Data.Models;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Heroes.Controllers
{
    public class PowersController : ApiController
    {
        private EntityContext db = new EntityContext();

        // GET: api/Powers
        public IQueryable<PowerDTO> GetPowers()
        {
            return db.Powers.ProjectTo<PowerDTO>();
        }

        // GET: api/Powers/5
        [ResponseType(typeof(PowerDTO))]
        public async Task<IHttpActionResult> GetPower(int id)
        {
            var power = await db.Powers.FindAsync(id);
            if (power == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PowerDTO>(power));
        }

        // PUT: api/Powers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPower(int id, PowerDTO powerDto)
        {
            var power = Mapper.Map<Power>(powerDto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != power.ID)
            {
                return BadRequest();
            }

            db.Entry(power).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PowerExists(id))
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

        // POST: api/Powers
        [ResponseType(typeof(PowerDTO))]
        public async Task<IHttpActionResult> PostPower(PowerDTO powerDto)
        {
            var power = Mapper.Map<Power>(powerDto);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Powers.Add(power);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = power.ID }, power);
        }

        // DELETE: api/Powers/5
        [ResponseType(typeof(PowerDTO))]
        public async Task<IHttpActionResult> DeletePower(int id)
        {
            var power = await db.Powers.FindAsync(id);
            if (power == null)
            {
                return NotFound();
            }

            db.Powers.Remove(power);
            await db.SaveChangesAsync();

            return Ok(Mapper.Map<PowerDTO>(power));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PowerExists(int id)
        {
            return db.Powers.Count(e => e.ID == id) > 0;
        }
    }
}