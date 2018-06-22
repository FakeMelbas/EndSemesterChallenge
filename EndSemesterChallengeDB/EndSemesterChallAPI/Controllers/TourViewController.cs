using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EndSemesterChallAPI.Models;

namespace EndSemesterChallAPI.Controllers
{
    public class TourViewController : ApiController
    {
        private EndSemesterDBEntities db = new EndSemesterDBEntities();

        // GET: api/TourView
        public IQueryable<Tour1> GetTours1()
        {
            return db.Tours1;
        }

        // GET: api/TourView/5
        [ResponseType(typeof(Tour1))]
        public IHttpActionResult GetTour1(string id)
        {
            Tour1 tour1 = db.Tours1.FirstOrDefault(b => b.TourName == id);
            if (tour1 == null)
            {
                return NotFound();
            }

            return Ok(tour1);
        }

        // PUT: api/TourView/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTour1(string id, Tour1 tour1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tour1.TourName)
            {
                return BadRequest();
            }

            db.Entry(tour1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Tour1Exists(id))
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

        // POST: api/TourView
        [ResponseType(typeof(Tour1))]
        public IHttpActionResult PostTour1(Tour1 tour1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tours1.Add(tour1);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Tour1Exists(tour1.TourName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tour1.TourName }, tour1);
        }

        // DELETE: api/TourView/5
        [ResponseType(typeof(Tour1))]
        public IHttpActionResult DeleteTour1(string id)
        {
            Tour1 tour1 = db.Tours1.Find(id);
            if (tour1 == null)
            {
                return NotFound();
            }

            db.Tours1.Remove(tour1);
            db.SaveChanges();

            return Ok(tour1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Tour1Exists(string id)
        {
            return db.Tours1.Count(e => e.TourName == id) > 0;
        }
    }
}