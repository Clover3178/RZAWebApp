using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using RZAWebApp.Data;
using System.ComponentModel.DataAnnotations;

namespace RZAWebApp.Models
{
    public class Bookings
    {
        [Key]
        public int BookingID { get; set; }

        public string? UserID { get; set; }

        public bool? ZooBooked { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ZooDate { get; set; }

        public bool? HotelBooked { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HotelDate { get; set; }

        public string? HotelRoomType { get; set; }

        [DataType(DataType.Date)]
        public DateTime? HotelBookedUntil { get; set; }

    }


}
