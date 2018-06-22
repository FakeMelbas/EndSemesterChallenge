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
    public class BookingViewController : ApiController
    {
        private EndSemesterDBEntities db = new EndSemesterDBEntities();

        // GET: api/BookingView
        public IQueryable<Booking1> GetBookings1()
        {
            return db.Bookings1;
        }

        // GET: api/BookingView/5
        [ResponseType(typeof(Booking1))]
        public IHttpActionResult GetBooking1(int Client, string TourName, DateTime DateBooked)
        {
            Booking1 booking1 = db.Bookings1.FirstOrDefault(b => b.Client == Client && b.TourName == TourName && b.DateBooked == DateBooked);
            if (booking1 == null)
            {
                return NotFound();
            }

            return Ok(booking1);
        }

        // PUT: api/BookingView/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBooking1(int id, Booking1 booking1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != booking1.Client)
            {
                return BadRequest();
            }

            db.Entry(booking1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Booking1Exists(id))
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

        // POST: api/BookingView
        [ResponseType(typeof(Booking1))]
        public IHttpActionResult PostBooking1(Booking1 booking1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Bookings1.Add(booking1);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Booking1Exists(booking1.Client))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = booking1.Client }, booking1);
        }

        // DELETE: api/BookingView/5
        [ResponseType(typeof(Booking1))]
        public IHttpActionResult DeleteBooking1(int id)
        {
            Booking1 booking1 = db.Bookings1.Find(id);
            if (booking1 == null)
            {
                return NotFound();
            }

            db.Bookings1.Remove(booking1);
            db.SaveChanges();

            return Ok(booking1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Booking1Exists(int id)
        {
            return db.Bookings1.Count(e => e.Client == id) > 0;
        }
    }
}