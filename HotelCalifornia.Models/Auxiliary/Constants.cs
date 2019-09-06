namespace HotelCalifornia.Models.Auxiliary
{
    /// <summary>
    /// Constants to use in this app.
    /// </summary>
    public class Constants
    {
        /// <summary>
        /// Min password length.
        /// </summary>
        public const int MinPasswordLength = 6;

        /// <summary>
        /// Min login length.
        /// </summary>
        public const int MinLoginLength = 3;

        /// <summary>
        /// The roles using by the authorization system.
        /// </summary>
        public class Roles
        {
            /// <summary>
            /// The administrator role.
            /// </summary>
            public const string Admin = "admin";

            /// <summary>
            /// The list of all roles.
            /// </summary>
            public static readonly string[] All = new string[] { Admin };
        }
    }
}
