using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GuestRoomsController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/GuestRooms
        public IEnumerable<GuestRoom> GetGuestRooms()
        {
            return db.GuestRooms.ToList();
        }

        // GET: api/GuestRooms/5
        public IHttpActionResult GetGuestRoom(int id)
        {
            GuestRoom guestRoom = db.GuestRooms.Find(id);
            if (guestRoom == null)
            {
                return NotFound();
            }
            return Ok(guestRoom);
        }

        // POST: api/GuestRooms
        public IHttpActionResult PostGuestRoom(GuestRoom guestRoom)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GuestRooms.Add(guestRoom);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = guestRoom.GuestRoomId }, guestRoom);
        }

        // PUT: api/GuestRooms/5
        public IHttpActionResult PutGuestRoom(int id, GuestRoom guestRoom)
        {
            guestRoom.GuestRoomId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingGuestRoom = db.GuestRooms.Find(id);
            if (existingGuestRoom == null)
            {
                return NotFound();
            }

            db.Entry(existingGuestRoom).CurrentValues.SetValues(guestRoom);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestRoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingGuestRoom);
        }

        // DELETE: api/GuestRooms/5
        public IHttpActionResult DeleteGuestRoom(int id)
        {
            GuestRoom guestRoom = db.GuestRooms.Find(id);
            if (guestRoom == null)
            {
                return NotFound();
            }

            db.GuestRooms.Remove(guestRoom);
            db.SaveChanges();

            return Ok(guestRoom);
        }

        private bool GuestRoomExists(int id)
        {
            return db.GuestRooms.Any(e => e.GuestRoomId == id);
        }
    }

}