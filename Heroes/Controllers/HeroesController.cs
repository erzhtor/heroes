using Heroes.BusinessLogicLayer.Contracts;
using Heroes.BusinessLogicLayer.Models;
using Heroes.Data.Models;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

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
        public IEnumerable<HeroDTO> GetHeroes([FromUri]HeroFiler filter)
        {
            return heroService.GetHeroes(filter);
        }

        // GET: api/Heroes/5
        [ResponseType(typeof(HeroDTO))]
        public IHttpActionResult GetHero(int id)
        {
            var hero = heroService.GetHeroById(id);
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

            heroService.UpdateHero(heroDto);

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
            var newHero = heroService.AddHero(heroDto);

            return CreatedAtRoute("DefaultApi", new { id = newHero.ID }, newHero);
        }

        // DELETE: api/Heroes/5
        [ResponseType(typeof(HeroDTO))]
        public IHttpActionResult DeleteHero(int id)
        {
            var hero = heroService.DeleteHero(id);
            if (hero == null)
            {
                return NotFound();
            }
            return Ok(hero);
        }
    }
}