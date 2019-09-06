using System;

namespace HotelCalifornia.Models.ErrorHandling
{
    /// <summary>
    /// The realization of <c>4xx Client Error</c> exception.
    /// </summary>
    [Serializable]
    public class ClientException : Exception
    {
        /// <summary>
        /// 4xx Status code.
        /// </summary>
        public int StatusCode { get; set; } = 400;

        /// <summary>
        /// The default <c>Exception</c> constructor.
        /// </summary>
        public ClientException() { }

        /// <summary>
        /// The default <c>Exception(string message)</c> constructor.
        /// </summary>
        /// <param name="message">Message of the error</param>
        public ClientException(string message) : base(message) { }

        /// <summary>
        /// The default <c>Exception(string message, Exception inner)</c> constructor.
        /// </summary>
        /// <param name="message">Message of the error</param>
        /// <param name="inner">Inner exception</param>
        public ClientException(string message, Exception inner) : base(message, inner) { }

        /// <summary>
        /// The default <c>Exception(string message)</c> constructor with <paramref name="statusCode"/> to modify.
        /// </summary>
        /// <param name="message">Message of the error</param>
        /// <param name="statusCode">Status code of the error</param>
        public ClientException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        protected ClientException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
