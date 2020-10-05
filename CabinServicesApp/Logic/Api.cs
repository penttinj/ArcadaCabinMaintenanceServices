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

        public async Task<Cabin[]> GetCabins(string email)
        {
            // Send GET request to /cabins/<email>
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri($"https://arcadacmsapi20201005115126.azurewebsites.net/cabins/{email}"),
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

            // Get the auth header from ACMSApi response and assign it to jwt
            if (message.Headers.TryGetValues("Authorization", out IEnumerable<string> values))
            {
                jwt = new AuthenticationHeaderValue(values.First()).Scheme;
            }
            else
            {
                throw new Exception("Authorization header not found from the response");
            }

            JavaScriptSerializer js = new JavaScriptSerializer();

            var cabinsResponse = js.Deserialize<Cabin[]>(json);

            return cabinsResponse;
        }

        public async Task<IEnumerable<Service>> GetServices()
        {
            // Send GET request to /services
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri($"https://arcadacmsapi20201005115126.azurewebsites.net/services"),
                Method = HttpMethod.Get
            };
            
            HttpResponseMessage message = await client.SendAsync(request);

            if (message.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            HttpContent content = message.Content;
            string json = await content.ReadAsStringAsync();

            JavaScriptSerializer js = new JavaScriptSerializer();

            var services = js.Deserialize<IEnumerable<Service>>(json);

            return services;
        }

        public async Task<ReservationResponse[]> GetReservations(string email)
        {
            // Send GET request to /cabins/<email>
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri($"https://arcadacmsapi20201005115126.azurewebsites.net/reservations/{email}"),
                Method = HttpMethod.Get
            };
            HttpResponseMessage message = await client.SendAsync(request);

            if (message.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            HttpContent content = message.Content;
            string json = await content.ReadAsStringAsync();

            JavaScriptSerializer js = new JavaScriptSerializer();

            var reservationsResponse = js.Deserialize<ReservationResponse[]>(json);

            return reservationsResponse;
        }

        public async Task<bool> SaveReservation(Reservation reservation)
        {
            HttpClient client = new HttpClient();
            string jsonObject = new JavaScriptSerializer().Serialize(reservation);
            StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://arcadacmsapi20201005115126.azurewebsites.net/reservations", content);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ModifyReservation(Reservation reservation, int reservationId)
        {
            HttpClient client = new HttpClient();
            string jsonObject = new JavaScriptSerializer().Serialize(reservation);
            StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://arcadacmsapi20201005115126.azurewebsites.net/reservations/{reservationId}", content);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteReservation(int reservationId)
        {
            HttpClient client = new HttpClient();

            var response = await client.DeleteAsync($"https://arcadacmsapi20201005115126.azurewebsites.net/reservations/{reservationId}");
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }
    }
}
