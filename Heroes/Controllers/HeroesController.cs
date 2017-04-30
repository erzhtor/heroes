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
    public class HeroesController : ApiController
    {
        private EntityContext db = new EntityContext();

        // GET: api/Heroes
        public IQueryable<HeroDTO> GetHeroes()
        {
            return db.Heroes.ProjectTo<HeroDTO>();
        }

        // GET: api/Heroes/5
        [ResponseType(typeof(HeroDTO))]
        public async Task<IHttpActionResult> GetHero(int id)
        {
            var hero = await db.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<HeroDTO>(hero));
        }

        // PUT: api/Heroes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutHero(int id, HeroDTO heroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hero = Mapper.Map<Hero>(heroDto);
            if (id != hero.ID)
            {
                return BadRequest();
            }
            db.Heroes.Attach(hero);
            db.Entry(hero).Collection(x => x.Powers).Load();
            hero.Powers.Clear();
            var updatedPowers = await GetPowersByIds(heroDto.PowerIDs);
            foreach (var power in updatedPowers)
            {
                hero.Powers.Add(power);
            }
            db.Entry(hero).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroExists(id))
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

        // POST: api/Heroes
        [ResponseType(typeof(HeroDTO))]
        public async Task<IHttpActionResult> PostHero(HeroDTO heroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var hero = Mapper.Map<Hero>(heroDto);
            hero.Powers = await GetPowersByIds(heroDto.PowerIDs);
            db.Heroes.Add(hero);
            await db.SaveChangesAsync();

            var result = Mapper.Map<HeroDTO>(hero);
            return CreatedAtRoute("DefaultApi", new { id = hero.ID }, result);
        }

        // DELETE: api/Heroes/5
        [ResponseType(typeof(HeroDTO))]
        public async Task<IHttpActionResult> DeleteHero(int id)
        {
            var hero = await db.Heroes.FindAsync(id);
            if (hero == null)
            {
                return NotFound();
            }

            db.Heroes.Remove(hero);
            await db.SaveChangesAsync();

            return Ok(Mapper.Map<HeroDTO>(hero));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HeroExists(int id)
        {
            return db.Heroes.Count(e => e.ID == id) > 0;
        }

        private async Task<ICollection<Power>> GetPowersByIds(List<int> powerIDs)
        {
            powerIDs = powerIDs ?? new List<int>();
            return await db.Powers.Where(x => powerIDs.Contains(x.ID)).ToListAsync();
        }

        private async Task<ICollection<Power>> GetPowersByHeroID(int id)
        {
            var hero = await db.Heroes.FirstAsync(x => x.ID == id);
            return hero.Powers;
        }
    }
}