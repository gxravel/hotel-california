using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace HotelCalifornia.Domain.ErrorHandling
{
    /// <summary>
    /// Contains the method to write JSON as request response.
    /// </summary>
    public static class HttpExtensions
    {
        private static readonly JsonSerializer Serializer = new JsonSerializer
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        /// Writes JSON as request response according to <paramref name="obj"/> object
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="response">This http response</param>
        /// <param name="obj">The object to serialize - actual response</param>
        /// <param name="contentType">The content type</param>
        public static async Task WriteJson<T>(this HttpResponse response, T obj, string contentType = null)
        {
            response.ContentType = contentType ?? "application/json";
            using var writer = new HttpResponseStreamWriter(response.Body, Encoding.UTF8);
            using var jsonWriter = new JsonTextWriter(writer)
            {
                CloseOutput = false,
                AutoCompleteOnClose = false
            };

            Serializer.Serialize(jsonWriter, obj);
            await jsonWriter.FlushAsync();
        }
    }
}
