using HotelCalifornia.Models.Auxiliary;

namespace HotelCalifornia.Models.ViewModels
{
    /// <summary>
    /// Contains the properties expecting from the get rooms request.
    /// <list type="bullet">
    /// <item>
    /// <term>Page</term>
    /// <description>An integer</description>
    /// </item>
    /// <item>
    /// <term>RoomsOnPage</term>
    /// <description>An integer</description>
    /// </item>
    /// <item>
    /// <term>FindColumn</term>
    /// <description>An enum</description>
    /// </item>
    /// <item>
    /// <term>FindValue</term>
    /// <description>A string</description>
    /// </item>
    /// <item>
    /// <term>SortColumn</term>
    /// <description>An enum</description>
    /// </item>
    /// <item>
    /// <term>IsAscending</term>
    /// <description>Boolean</description>
    /// </item>
    /// </list>
    /// </summary>
    public class GetRoomsViewModel
    {
        /// <summary>
        /// Current page.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// How much rooms on a page.
        /// </summary>
        public int RoomsOnPage { get; set; }

        /// <summary>
        /// The column to find for.
        /// </summary>
        public Enums.HotelRoomColumns? FindColumn { get; set; }

        /// <summary>
        /// The castable value that is looking for.
        /// </summary>
        public string FindValue { get; set; }

        /// <summary>
        /// The column to sort.
        /// </summary>
        public Enums.HotelRoomColumns? SortColumn { get; set; }

        /// <summary>
        /// The order of sorting (ascending / descending).
        /// </summary>
        public bool IsAscending { get; set; } = true;
    }
}
