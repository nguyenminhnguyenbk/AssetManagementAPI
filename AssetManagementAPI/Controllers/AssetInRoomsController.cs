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
    public class AssetInRoomsController : ApiController
    {
        private QLCSVCEntities db = new QLCSVCEntities();

        // GET: api/AssetInRooms
        public IQueryable<AssetInRoom> GetAssetInRooms()
        {
            return db.AssetInRooms;
        }

        // GET: api/AssetInRooms/5
        [ResponseType(typeof(AssetInRoom))]
        public IHttpActionResult GetAssetInRoom(int id)
        {
            AssetInRoom assetInRoom = db.AssetInRooms.Find(id);
            if (assetInRoom == null)
            {
                return NotFound();
            }

            return Ok(assetInRoom);
        }

        // PUT: api/AssetInRooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssetInRoom(int id, AssetInRoom assetInRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assetInRoom.AssetInRoomId)
            {
                return BadRequest();
            }

            db.Entry(assetInRoom).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssetInRoomExists(id))
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

        // POST: api/AssetInRooms
        [ResponseType(typeof(AssetInRoom))]
        public IHttpActionResult PostAssetInRoom(AssetInRoom assetInRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AssetInRooms.Add(assetInRoom);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AssetInRoomExists(assetInRoom.AssetInRoomId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = assetInRoom.AssetInRoomId }, assetInRoom);
        }

        // DELETE: api/AssetInRooms/5
        [ResponseType(typeof(AssetInRoom))]
        public IHttpActionResult DeleteAssetInRoom(int id)
        {
            AssetInRoom assetInRoom = db.AssetInRooms.Find(id);
            if (assetInRoom == null)
            {
                return NotFound();
            }

            db.AssetInRooms.Remove(assetInRoom);
            db.SaveChanges();

            return Ok(assetInRoom);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssetInRoomExists(int id)
        {
            return db.AssetInRooms.Count(e => e.AssetInRoomId == id) > 0;
        }
    }
}