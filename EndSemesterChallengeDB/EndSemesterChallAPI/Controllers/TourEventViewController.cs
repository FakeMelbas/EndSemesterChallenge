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
    public class TourEventViewController : ApiController
    {
        private EndSemesterDBEntities db = new EndSemesterDBEntities();

        // GET: api/TourEventView
        public IQueryable<TourEvent1> GetTourEvents1()
        {
            return db.TourEvents1;
        }

        // GET: api/TourEventView/5
        [ResponseType(typeof(TourEvent1))]
        public IHttpActionResult GetTourEvent1(string TourName, string EventMonth, int EventYear, int EventDay)
        {
            TourEvent1 tourEvent1 = db.TourEvents1.FirstOrDefault(b => b.TourName == TourName && b.EventMonth == EventMonth && b.EventYear == EventYear && b.EventDay == EventDay);
            if (tourEvent1 == null)
            {
                return NotFound();
            }

            return Ok(tourEvent1);
        }

        // PUT: api/TourEventView/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTourEvent1(string id, TourEvent1 tourEvent1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tourEvent1.TourName)
            {
                return BadRequest();
            }

            db.Entry(tourEvent1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TourEvent1Exists(id))
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

        // POST: api/TourEventView
        [ResponseType(typeof(TourEvent1))]
        public IHttpActionResult PostTourEvent1(TourEvent1 tourEvent1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TourEvents1.Add(tourEvent1);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TourEvent1Exists(tourEvent1.TourName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tourEvent1.TourName }, tourEvent1);
        }

        // DELETE: api/TourEventView/5
        [ResponseType(typeof(TourEvent1))]
        public IHttpActionResult DeleteTourEvent1(string id)
        {
            TourEvent1 tourEvent1 = db.TourEvents1.Find(id);
            if (tourEvent1 == null)
            {
                return NotFound();
            }

            db.TourEvents1.Remove(tourEvent1);
            db.SaveChanges();

            return Ok(tourEvent1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TourEvent1Exists(string id)
        {
            return db.TourEvents1.Count(e => e.TourName == id) > 0;
        }
    }
}