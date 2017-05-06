using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Heroes.Data.Models;
using Heroes.BusinessLogicLayer.Contracts;

namespace Heroes.Controllers
{
    public class HeroesController : ApiController
    {
        private readonly IHeroService heroService;

        public HeroesController(IHeroService heroService)
        {
            this.heroService = heroService;
        }

        // GET: api/Heroes
        public IEnumerable<HeroDTO> GetHeroes()
        {
            return heroService.GetAll();
        }

        // GET: api/Heroes/5
        [ResponseType(typeof(HeroDTO))]
        public IHttpActionResult GetHero(int id)
        {
            var hero = heroService.GetById(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }

        // PUT: api/Heroes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHero(int id, HeroDTO heroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != heroDto.ID)
            {
                return BadRequest();
            }

            if (!heroService.HeroExists(id))
            {
                return NotFound();
            }

            heroService.Update(heroDto);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Heroes
        [ResponseType(typeof(HeroDTO))]
        public IHttpActionResult PostHero(HeroDTO heroDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newHero = heroService.Add(heroDto);

            return CreatedAtRoute("DefaultApi", new { id = newHero.ID }, newHero);
        }

        // DELETE: api/Heroes/5
        [ResponseType(typeof(HeroDTO))]
        public IHttpActionResult DeleteHero(int id)
        {
            var hero = heroService.Delete(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }
    }
}