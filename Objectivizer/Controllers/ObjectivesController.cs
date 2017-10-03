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
using Microsoft.AspNet.Identity;
using Objectivizer.Models;

namespace Objectivizer.Controllers
{
    [RoutePrefix("api/objectives")]
    public class ObjectivesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Objectives
        public IQueryable<Objective> GetObjectives()
        {
            return db.Objectives;
        }

        [HttpGet]
        [Route("myObjectives")]
        [Authorize]
        public List<Objective> GetMyObjectives()
        {
            ApplicationUser user = db.Users.FirstOrDefault(us => us.Id.Equals(User.Identity.GetUserId()));
            return db.Objectives.Where(obj => user.Organisations.Contains(obj.OrganisationId)).ToList();
        }

        // GET: api/Objectives/5
        [ResponseType(typeof(Objective))]
        public async Task<IHttpActionResult> GetObjective(int id)
        {
            Objective objective = await db.Objectives.FindAsync(id);
            if (objective == null)
            {
                return NotFound();
            }

            return Ok(objective);
        }

        // PUT: api/Objectives/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutObjective(int id, Objective objective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objective.ObjectiveId)
            {
                return BadRequest();
            }

            db.Entry(objective).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectiveExists(id))
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

        // POST: api/Objectives
        [ResponseType(typeof(Objective))]
        public async Task<IHttpActionResult> PostObjective(Objective objective)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Objectives.Add(objective);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = objective.ObjectiveId }, objective);
        }

        // DELETE: api/Objectives/5
        [ResponseType(typeof(Objective))]
        public async Task<IHttpActionResult> DeleteObjective(int id)
        {
            Objective objective = await db.Objectives.FindAsync(id);
            if (objective == null)
            {
                return NotFound();
            }

            db.Objectives.Remove(objective);
            await db.SaveChangesAsync();

            return Ok(objective);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObjectiveExists(int id)
        {
            return db.Objectives.Count(e => e.ObjectiveId == id) > 0;
        }
    }
}