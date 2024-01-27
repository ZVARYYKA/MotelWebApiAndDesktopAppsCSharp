using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class GuestRoom
    {
        public int GuestRoomId { get; set; }
        public int GuestId { get; set; }
        public int RoomId { get; set; }
        // Навигационные свойства для связи с Guest и Room
        public virtual Guest Guest { get; set; }
        public virtual Room Room { get; set; }

        // Другие свойства промежуточной таблицы

        public GuestRoom() { }
    }
}