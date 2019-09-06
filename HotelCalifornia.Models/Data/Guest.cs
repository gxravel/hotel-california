using System;
using System.ComponentModel.DataAnnotations;

namespace HotelCalifornia.Models.Data
{
    /// <summary>
    /// The representation of database table for guests.
    /// </summary>
    public class Guest
    {
        /// <summary>
        /// Initializes the data of a guest.
        /// </summary>
        /// <param name="roomId">The hotel room id that the guest occupies</param>
        public Guest(Guid roomId, string fullName)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            CheckIntoRoomDate = DateTime.Now;
            RoomId = roomId;
        }

        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The full name of the guest.
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// The date of checking into the hotel.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckIntoRoomDate { get; set; }

        /// <summary>
        /// The date of checking out of the hotel.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CheckOutRoomDate { get; set; }

        /// <summary>
        /// Foreign key for the hotel room.
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// Navigation for the hotel room.
        /// </summary>
        public HotelRoom Room { get; set; }
    }
}
