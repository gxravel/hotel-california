namespace HotelCalifornia.Models.Auxiliary
{
    /// <summary>
    /// Enums to use in this app.
    /// </summary>
    public class Enums
    {
        /// <summary>
        /// Contains the predefined types of a hotel room.
        /// <para><see cref=">Standard"/></para>
        /// <para><see cref=">JuniorSuite"/></para>
        /// <para><see cref=">Suite"/></para>
        /// </summary>
        public enum HotelRoomTypes
        {
            Standard = 0,
            JuniorSuite = 1,
            Suite = 2
        }

        /// <summary>
        /// Contains the predefined columns of a hotel room.
        /// <para><see cref=">Id"/></para>
        /// <para><see cref=">Capacity"/></para>
        /// <para><see cref=">Type"/></para>
        /// <para><see cref=">IsOccupied"/></para>
        /// <para><see cref=">Cost"/></para>
        /// </summary>
        public enum HotelRoomColumns
        {
            Id = 0,
            Capacity = 1,
            Type = 2,
            IsOccupied = 3,
            Cost = 4
        }
    }
}
