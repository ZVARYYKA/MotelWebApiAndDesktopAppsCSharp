using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class RoomsController : ApiController
    {
        private HotelContext db = new HotelContext();

        // GET: api/Rooms
        public IEnumerable<Room> GetRooms()
        {
            return db.Rooms.ToList();
        }

        // GET: api/Rooms/5
        public IHttpActionResult GetRoom(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            return Ok(room);
        }

        // POST: api/Rooms
        public IHttpActionResult PostRoom(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rooms.Add(room);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = room.RoomId }, room);
        }

        // PUT: api/Rooms/5
        public IHttpActionResult PutRoom(int id, Room room)
        {
            room.RoomId = id;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingRoom = db.Rooms.Find(id);
            if (existingRoom == null)
            {
                return NotFound();
            }

            db.Entry(existingRoom).CurrentValues.SetValues(room);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingRoom);
        }

        // DELETE: api/Rooms/5
        public IHttpActionResult DeleteRoom(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            db.Rooms.Remove(room);
            db.SaveChanges();

            return Ok(room);
        }

        private bool RoomExists(int id)
        {
            return db.Rooms.Any(e => e.RoomId == id);
        }
    }
}