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
    public class RoleRightsController : ApiController
    {
        private QLCSVCEntities db = new QLCSVCEntities();

        // GET: api/RoleRights
        public IQueryable<RoleRight> GetRoleRights()
        {
            return db.RoleRights;
        }

        // GET: api/RoleRights/5
        [ResponseType(typeof(RoleRight))]
        public IHttpActionResult GetRoleRight(int id)
        {
            RoleRight roleRight = db.RoleRights.Find(id);
            if (roleRight == null)
            {
                return NotFound();
            }

            return Ok(roleRight);
        }

        // PUT: api/RoleRights/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoleRight(int id, RoleRight roleRight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roleRight.RoleRightId)
            {
                return BadRequest();
            }

            db.Entry(roleRight).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleRightExists(id))
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

        // POST: api/RoleRights
        [ResponseType(typeof(RoleRight))]
        public IHttpActionResult PostRoleRight(RoleRight roleRight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RoleRights.Add(roleRight);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roleRight.RoleRightId }, roleRight);
        }

        // DELETE: api/RoleRights/5
        [ResponseType(typeof(RoleRight))]
        public IHttpActionResult DeleteRoleRight(int id)
        {
            RoleRight roleRight = db.RoleRights.Find(id);
            if (roleRight == null)
            {
                return NotFound();
            }

            db.RoleRights.Remove(roleRight);
            db.SaveChanges();

            return Ok(roleRight);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoleRightExists(int id)
        {
            return db.RoleRights.Count(e => e.RoleRightId == id) > 0;
        }
    }
}