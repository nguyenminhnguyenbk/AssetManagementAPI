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
    public class StatusAssetsController : ApiController
    {
        private QLCSVCEntities db = new QLCSVCEntities();

        // GET: api/StatusAssets
        public IQueryable<StatusAsset> GetStatusAssets()
        {
            return db.StatusAssets;
        }

        // GET: api/StatusAssets/5
        [ResponseType(typeof(StatusAsset))]
        public IHttpActionResult GetStatusAsset(int id)
        {
            StatusAsset statusAsset = db.StatusAssets.Find(id);
            if (statusAsset == null)
            {
                return NotFound();
            }

            return Ok(statusAsset);
        }

        // PUT: api/StatusAssets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatusAsset(int id, StatusAsset statusAsset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statusAsset.StatusAssetId)
            {
                return BadRequest();
            }

            db.Entry(statusAsset).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusAssetExists(id))
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

        // POST: api/StatusAssets
        [ResponseType(typeof(StatusAsset))]
        public IHttpActionResult PostStatusAsset(StatusAsset statusAsset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatusAssets.Add(statusAsset);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statusAsset.StatusAssetId }, statusAsset);
        }

        // DELETE: api/StatusAssets/5
        [ResponseType(typeof(StatusAsset))]
        public IHttpActionResult DeleteStatusAsset(int id)
        {
            StatusAsset statusAsset = db.StatusAssets.Find(id);
            if (statusAsset == null)
            {
                return NotFound();
            }

            db.StatusAssets.Remove(statusAsset);
            db.SaveChanges();

            return Ok(statusAsset);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatusAssetExists(int id)
        {
            return db.StatusAssets.Count(e => e.StatusAssetId == id) > 0;
        }
    }
}