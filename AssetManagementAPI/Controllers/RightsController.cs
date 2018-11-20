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
using AssetManagementAPI.Models;

namespace AssetManagementAPI.Controllers
{
    public class RightsController : ApiController
    {
        private QLCSVCEntities db = new QLCSVCEntities();

        // GET: api/Rights
        public IQueryable<Right> GetRights()
        {
            return db.Rights;
        }

        // GET: api/Rights/5
        [ResponseType(typeof(Right))]
        public IHttpActionResult GetRight(int id)
        {
            Right right = db.Rights.Find(id);
            if (right == null)
            {
                return NotFound();
            }

            return Ok(right);
        }

        // PUT: api/Rights/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRight(int id, Right right)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != right.RightId)
            {
                return BadRequest();
            }

            db.Entry(right).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RightExists(id))
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

        // POST: api/Rights
        [ResponseType(typeof(Right))]
        public IHttpActionResult PostRight(Right right)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rights.Add(right);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RightExists(right.RightId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = right.RightId }, right);
        }

        // DELETE: api/Rights/5
        [ResponseType(typeof(Right))]
        public IHttpActionResult DeleteRight(int id)
        {
            Right right = db.Rights.Find(id);
            if (right == null)
            {
                return NotFound();
            }

            db.Rights.Remove(right);
            db.SaveChanges();

            return Ok(right);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RightExists(int id)
        {
            return db.Rights.Count(e => e.RightId == id) > 0;
        }
    }
}