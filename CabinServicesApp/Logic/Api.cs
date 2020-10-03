using CabinServicesApp.Models;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CabinServicesApp.Logic
{
    class Api
    {
        private static string jwt = "noTokenYet";

        // public static string Jwt { get => jwt; set => jwt = value; }

        public async Task<List<CabinsResponse>> GetCabins(string email)
        {
            // Send GET request to /cabins
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri($"https://localhost:44378/cabins/{email}"),
                Method = HttpMethod.Get
            };
            request.Headers.Authorization = new AuthenticationHeaderValue(jwt);
            HttpResponseMessage message = await client.SendAsync(request);

            if (message.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            HttpContent content = message.Content;
            string json = await content.ReadAsStringAsync();

            // Get the auth header from ACMSApi response
            if (message.Headers.TryGetValues("Authorization", out IEnumerable<string> values))
            {
                jwt = new AuthenticationHeaderValue(values.First()).Scheme;
            }
            else
            {
                throw new Exception("Authorization header not found from the response");
            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            var cabinsResponse = js.Deserialize<List<CabinsResponse>>(json);

            return cabinsResponse;
        }

        public async Task SaveReservation(Reservation reservation)
        {
            HttpClient client = new HttpClient();
            string jsonObject = new JavaScriptSerializer().Serialize(reservation);
            StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            await client.PostAsync("http://localhost:63501/reservations", content);
        }
    }
}
