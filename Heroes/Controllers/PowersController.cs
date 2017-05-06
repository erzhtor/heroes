using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using Heroes.Data.Models;
using Heroes.BusinessLogicLayer.Contracts;

namespace Heroes.Controllers
{
    public class PowersController : ApiController
    {
        private readonly IPowerService powerService;

        public PowersController(IPowerService powerService)
        {
            this.powerService = powerService;
        }

        // GET: api/Powers
        public IEnumerable<PowerDTO> GetPowers()
        {
            return powerService.GetAll();
        }

        // GET: api/Powers/5
        [ResponseType(typeof(PowerDTO))]
        public IHttpActionResult GetPower(int id)
        {
            var power = powerService.GetById(id);
            if (power == null)
            {
                return NotFound();
            }
            return Ok(power);
        }

        // PUT: api/Powers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPower(int id, PowerDTO powerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != powerDto.ID)
            {
                return BadRequest();
            }

            if (!powerService.PowerExists(powerDto.ID))
            {
                return NotFound();
            }

            powerService.Update(powerDto);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Powers
        [ResponseType(typeof(PowerDTO))]
        public IHttpActionResult PostPower(PowerDTO powerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newPower = powerService.Add(powerDto);
            return CreatedAtRoute("DefaultApi", new { id = newPower.ID }, newPower);
        }

        // DELETE: api/Powers/5
        [ResponseType(typeof(PowerDTO))]
        public IHttpActionResult DeletePower(int id)
        {
            var power = powerService.Delete(id);
            if (power == null)
            {
                return NotFound();
            }
            return Ok(power);
        }
    }
}