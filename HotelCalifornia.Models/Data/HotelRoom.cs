using HotelCalifornia.Models.Auxiliary;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelCalifornia.Models.Data
{
    /// <summary>
    /// The representation of database table for hotel rooms.
    /// </summary>
    public class HotelRoom
    {
        /// <summary>
        /// Initializes the parameters of a room.
        /// </summary>
        public HotelRoom(int capacity = 2, Enums.HotelRoomTypes type = Enums.HotelRoomTypes.Standard, bool isOccupied = false)
        {
            Id = Guid.NewGuid();
            Capacity = capacity;
            Type = type;
            IsOccupied = isOccupied;
            CalculateCost();
        }

        /// <summary>
        /// Primary key.
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// The number of guests the room can contain.
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// The type of the room. It can be standard, junior suite or suite.
        /// </summary>
        public Enums.HotelRoomTypes Type { get; set; }

        /// <summary>
        /// Indicates if the room is currently occupied.
        /// </summary>
        public bool IsOccupied { get; set; }

        /// <summary>
        /// The room price per night in a unit of currency.
        /// </summary>
        public float Cost { get; set; }

        private const float StandardPrice = 1000.0f;
        private const float TypeStandardCoefficient = 1.0f;
        private const float TypeJuniorSuiteCoefficient = 2.0f;
        private const float TypeSuiteCoefficient = 3.0f;
        private const float CapacityCoefficient = 1.25f;

        /// <summary>
        /// Calculates the room cost per night for the room.
        /// </summary>
        private void CalculateCost()
        {
            float typeCoefficient = Type switch
            {
                Enums.HotelRoomTypes.Standard => TypeStandardCoefficient,
                Enums.HotelRoomTypes.JuniorSuite => TypeJuniorSuiteCoefficient,
                Enums.HotelRoomTypes.Suite => TypeSuiteCoefficient,
                _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(Type))
            };
            Cost = StandardPrice * typeCoefficient * CapacityCoefficient * Capacity;
        }

        /// <summary>
        /// Calculates the room cost for the entire period.
        /// </summary>
        /// <param name="checkInto">A date of checking the guest into a room</param>
        /// <param name="checkOut">A date of checking the guest out of a room</param>
        /// <param name="roomCost">A cost of the room</param>
        /// <returns>The room cost for the entire period</returns>
        public static float CalculateCostForEntirePeriod(DateTime checkInto, DateTime checkOut, float roomCost)
        {
            var daysNumber = (checkOut - checkInto).Days + 1;
            return roomCost * daysNumber;
        }

    }
}
