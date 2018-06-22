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
    public class ClientViewController : ApiController
    {
        private EndSemesterDBEntities db = new EndSemesterDBEntities();

        // GET: api/ClientView
        public IQueryable<Client1> GetClients1()
        {
            return db.Clients1;
        }

        // GET: api/ClientView/5
        [ResponseType(typeof(Client1))]
        public IHttpActionResult GetClient1(int id)
        {
            Client1 client1 = db.Clients1.FirstOrDefault(b => b.ClientID == id);

            if (client1 == null)
            {
                return NotFound();
            }

            return Ok(client1);
        }

        // PUT: api/ClientView/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient1(int id, Client1 client1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client1.ClientID)
            {
                return BadRequest();
            }

            db.Entry(client1).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Client1Exists(id))
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

        // POST: api/ClientView
        [ResponseType(typeof(Client1))]
        public IHttpActionResult PostClient1(Client1 client1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clients1.Add(client1);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Client1Exists(client1.ClientID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = client1.ClientID }, client1);
        }

        // DELETE: api/ClientView/5
        [ResponseType(typeof(Client1))]
        public IHttpActionResult DeleteClient1(int id)
        {
            Client1 client1 = db.Clients1.Find(id);
            if (client1 == null)
            {
                return NotFound();
            }

            db.Clients1.Remove(client1);
            db.SaveChanges();

            return Ok(client1);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Client1Exists(int id)
        {
            return db.Clients1.Count(e => e.ClientID == id) > 0;
        }
    }
}