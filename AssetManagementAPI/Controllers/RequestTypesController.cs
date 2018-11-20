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
    public class RequestTypesController : ApiController
    {
        private QLCSVCEntities db = new QLCSVCEntities();

        // GET: api/RequestTypes
        public IQueryable<RequestType> GetRequestTypes()
        {
            return db.RequestTypes;
        }

        // GET: api/RequestTypes/5
        [ResponseType(typeof(RequestType))]
        public IHttpActionResult GetRequestType(int id)
        {
            RequestType requestType = db.RequestTypes.Find(id);
            if (requestType == null)
            {
                return NotFound();
            }

            return Ok(requestType);
        }

        // PUT: api/RequestTypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequestType(int id, RequestType requestType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requestType.RequestTypeId)
            {
                return BadRequest();
            }

            db.Entry(requestType).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestTypeExists(id))
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

        // POST: api/RequestTypes
        [ResponseType(typeof(RequestType))]
        public IHttpActionResult PostRequestType(RequestType requestType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestTypes.Add(requestType);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = requestType.RequestTypeId }, requestType);
        }

        // DELETE: api/RequestTypes/5
        [ResponseType(typeof(RequestType))]
        public IHttpActionResult DeleteRequestType(int id)
        {
            RequestType requestType = db.RequestTypes.Find(id);
            if (requestType == null)
            {
                return NotFound();
            }

            db.RequestTypes.Remove(requestType);
            db.SaveChanges();

            return Ok(requestType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestTypeExists(int id)
        {
            return db.RequestTypes.Count(e => e.RequestTypeId == id) > 0;
        }
    }
}