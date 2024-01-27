using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace WebApplication1.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("name=MotelDbContext")
        {
        }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<GuestRoom> GuestRooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Конфигурация отношения многие ко многим
            modelBuilder.Entity<GuestRoom>()
                .HasKey(gr => gr.GuestRoomId);

            modelBuilder.Entity<GuestRoom>()
                .HasRequired(gr => gr.Guest)
                .WithMany(g => g.GuestRooms)
                .HasForeignKey(gr => gr.GuestId);

            modelBuilder.Entity<GuestRoom>()
                .HasRequired(gr => gr.Room)
                .WithMany(r => r.GuestRooms)
                .HasForeignKey(gr => gr.RoomId);

            base.OnModelCreating(modelBuilder);
        }
    }
}