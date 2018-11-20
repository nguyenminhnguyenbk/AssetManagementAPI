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
    public class RequestAssetsController : ApiController
    {
        private QLCSVCEntities db = new QLCSVCEntities();

        // GET: api/RequestAssets
        public IQueryable<RequestAsset> GetRequestAssets()
        {
            return db.RequestAssets;
        }

        // GET: api/RequestAssets/5
        [ResponseType(typeof(RequestAsset))]
        public IHttpActionResult GetRequestAsset(int id)
        {
            RequestAsset requestAsset = db.RequestAssets.Find(id);
            if (requestAsset == null)
            {
                return NotFound();
            }

            return Ok(requestAsset);
        }

        // PUT: api/RequestAssets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequestAsset(int id, RequestAsset requestAsset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requestAsset.RequestAssetId)
            {
                return BadRequest();
            }

            db.Entry(requestAsset).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestAssetExists(id))
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

        // POST: api/RequestAssets
        [ResponseType(typeof(RequestAsset))]
        public IHttpActionResult PostRequestAsset(RequestAsset requestAsset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RequestAssets.Add(requestAsset);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = requestAsset.RequestAssetId }, requestAsset);
        }

        // DELETE: api/RequestAssets/5
        [ResponseType(typeof(RequestAsset))]
        public IHttpActionResult DeleteRequestAsset(int id)
        {
            RequestAsset requestAsset = db.RequestAssets.Find(id);
            if (requestAsset == null)
            {
                return NotFound();
            }

            db.RequestAssets.Remove(requestAsset);
            db.SaveChanges();

            return Ok(requestAsset);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequestAssetExists(int id)
        {
            return db.RequestAssets.Count(e => e.RequestAssetId == id) > 0;
        }
    }
}