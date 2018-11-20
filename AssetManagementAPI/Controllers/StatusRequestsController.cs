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
    public class StatusRequestsController : ApiController
    {
        private QLCSVCEntities db = new QLCSVCEntities();

        // GET: api/StatusRequests
        public IQueryable<StatusRequest> GetStatusRequests()
        {
            return db.StatusRequests;
        }

        // GET: api/StatusRequests/5
        [ResponseType(typeof(StatusRequest))]
        public IHttpActionResult GetStatusRequest(int id)
        {
            StatusRequest statusRequest = db.StatusRequests.Find(id);
            if (statusRequest == null)
            {
                return NotFound();
            }

            return Ok(statusRequest);
        }

        // PUT: api/StatusRequests/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusRequest(int id, StatusRequest statusRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusRequest.StatusRequestId)
            {
                return BadRequest();
            }

            db.Entry(statusRequest).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusRequestExists(id))
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

        // POST: api/StatusRequests
        [ResponseType(typeof(StatusRequest))]
        public IHttpActionResult PostStatusRequest(StatusRequest statusRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusRequests.Add(statusRequest);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusRequest.StatusRequestId }, statusRequest);
        }

        // DELETE: api/StatusRequests/5
        [ResponseType(typeof(StatusRequest))]
        public IHttpActionResult DeleteStatusRequest(int id)
        {
            StatusRequest statusRequest = db.StatusRequests.Find(id);
            if (statusRequest == null)
            {
                return NotFound();
            }

            db.StatusRequests.Remove(statusRequest);
            db.SaveChanges();

            return Ok(statusRequest);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusRequestExists(int id)
        {
            return db.StatusRequests.Count(e => e.StatusRequestId == id) > 0;
        }
    }
}