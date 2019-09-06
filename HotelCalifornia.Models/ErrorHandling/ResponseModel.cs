namespace HotelCalifornia.Models.ErrorHandling
{
    /// <summary>
    /// The Api response model.
    /// </summary>
    public class ResponseModel
    {
        /// <summary>
        /// Get or set the response of a request.
        /// </summary>
        /// <returns>The actual response or problem details</returns>
        public object Response { get; set; }

        /// <summary>
        /// Creates the object with <c>Response == null</c>
        /// </summary>
        public ResponseModel()
        {

        }
        /// <summary>
        /// Creates the object and initializes it with <paramref name="response"/>
        /// </summary>
        /// <param name="response">The actual response</param>
        public ResponseModel(object response)
        {
            Response = response;
        }
    }
}
