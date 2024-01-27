using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Guest
    {
        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // Другие свойства гостя
        [JsonIgnore]
        public virtual ICollection<GuestRoom> GuestRooms { get; set; }
        public Guest()
        {
            GuestRooms = new HashSet<GuestRoom>();
        }
    }
}