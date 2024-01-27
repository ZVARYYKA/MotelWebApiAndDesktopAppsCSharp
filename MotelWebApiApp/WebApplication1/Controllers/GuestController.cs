using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GuestsController : ApiController
    {
        private HotelContext db = new HotelContext();

        //GET
        public IEnumerable<Guest> GetGuests()
        {
            return db.Guests.ToList();
        }
        public IHttpActionResult GetGuest(int id)
        {
            Guest guest = db.Guests.Find(id);

            if (guest == null)
            {
                return NotFound();
            }

            return Ok(guest);
        }
        public IHttpActionResult PostGuest(Guest guest) { 

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Guests.Add(guest);
            db.SaveChanges();

            return Ok(guest);
        }
        public IHttpActionResult PutGuest(int id, Guest guest)
        {
            guest.GuestId = id;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           

            // Проверка наличия гостя с указанным id в базе данных
            var existingGuest = db.Guests.Find(id);
            if (existingGuest == null)
            {
                return NotFound();
            }

            // Обновление свойств существующего гостя
            db.Entry(existingGuest).CurrentValues.SetValues(guest);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GuestExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(existingGuest);
        }

        // DELETE: api/Guests/5
        public IHttpActionResult DeleteGuest(int id)
        {
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return NotFound();
            }

            db.Guests.Remove(guest);
            db.SaveChanges();

            return Ok(guest);
        }

        private bool GuestExists(int id)
        {
            return db.Guests.Any(e => e.GuestId == id);
        }

    }
}