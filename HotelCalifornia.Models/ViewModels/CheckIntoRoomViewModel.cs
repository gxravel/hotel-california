using System;
using System.ComponentModel.DataAnnotations;

namespace HotelCalifornia.Models.ViewModels
{
    /// <summary>
    /// Contains the properties expecting from the check into room request.
    /// <list type="bullet">
    /// <item>
    /// <term>RoomId</term>
    /// <description>A Guid room id</description>
    /// </item>
    /// <item>
    /// <term>CheckIntoDate</term>
    /// <description>A DateTime</description>
    /// </item>
    /// </list>
    /// </summary>
    public class CheckIntoRoomViewModel
    {
        /// <summary>
        /// The id of the hotel room.
        /// </summary>
        [Required]
        public Guid RoomId { get; set; }

        /// <summary>
        /// The full name of the guest.
        /// </summary>
        [Required]
        public string FullName { get; set; }

        /// <summary>
        /// The date of checking into the hotel.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CheckIntoDate { get; set; }
    }
}
