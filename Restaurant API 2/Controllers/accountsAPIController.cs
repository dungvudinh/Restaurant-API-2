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
using Restaurant_API_2.Models;

namespace Restaurant_API_2.Controllers
{
    public class accountsAPIController : ApiController
    {
        private RestaurantDatabaseEntities db = new RestaurantDatabaseEntities();

        // GET: api/accountsAPI
        public IQueryable<account> Getaccounts()
        {
            return db.accounts;
        }

        // GET: api/accountsAPI/5
        [ResponseType(typeof(account))]
        public IHttpActionResult Getaccount(int id)
        {
            account account = db.accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }

            return Ok(account);
        }

        // PUT: api/accountsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putaccount(int id, account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != account.id)
            {
                return BadRequest();
            }

            db.Entry(account).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!accountExists(id))
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

        // POST: api/accountsAPI
        [ResponseType(typeof(account))]
        public IHttpActionResult Postaccount(account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.accounts.Add(account);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = account.id }, account);
        }

        // DELETE: api/accountsAPI/5
        [ResponseType(typeof(account))]
        public IHttpActionResult Deleteaccount(int id)
        {
            account account = db.accounts.Find(id);
            if (account == null)
            {
                return NotFound();
            }

            db.accounts.Remove(account);
            db.SaveChanges();

            return Ok(account);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool accountExists(int id)
        {
            return db.accounts.Count(e => e.id == id) > 0;
        }
    }
}