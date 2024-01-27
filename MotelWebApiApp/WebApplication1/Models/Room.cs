using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNumber { get; set; }
        // Навигационное свойство для связи с GuestRoom
        [JsonIgnore]
        public virtual ICollection<GuestRoom> GuestRooms { get; set; }

        public Room()
        {
            GuestRooms = new HashSet<GuestRoom>();
        }
    }
}