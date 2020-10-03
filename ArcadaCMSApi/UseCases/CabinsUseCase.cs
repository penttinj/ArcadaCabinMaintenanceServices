using ArcadaCMSApi.Interfaces;
using ArcadaCMSApi.Models;
using Dapper;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;




namespace ArcadaCMSApi.UseCases
{
    public class CabinsResult
    {
        public List<Cabin> Cabins { get; set; }
        public AuthenticationHeaderValue Jwt { get; set; }
#pragma warning disable IDE1006 // Naming Styles
        public Cabin cabin { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }

    public class ResponseMessageAndToken
    {
        public HttpResponseMessage ResponseMessage { get; set; }
        public AuthenticationHeaderValue Jwt { get; set; }

        public ResponseMessageAndToken(HttpResponseMessage resp, AuthenticationHeaderValue jwt)
        {
            ResponseMessage = resp;
            Jwt = jwt;
        }
    }

    public class CabinsUseCase
    {
        readonly HttpClient client;
        public CabinsUseCase(HttpClient _client)
        {
            client = _client;
        }



        public async Task<CabinsResult> GetAllCabinsAsync(string token)
        {
            try
            {
                var responseMessage = await ApiRequest("https://arcada-cabin-broker.azurewebsites.net/cabins/", token);

                var content = responseMessage.ResponseMessage.Content;
                var json = await content.ReadAsStringAsync();

                Console.WriteLine("OOMG BLYAD!! :D");
                Debug.WriteLine("Coming from Debug");

                var js = new JavaScriptSerializer();
                var body = js.Deserialize<CabinsResponse>(json);
                var cabinsAndJwt = new CabinsResult
                {
                    Cabins = new List<Cabin>(body.cabins),
                    Jwt = responseMessage.Jwt
                };
                return cabinsAndJwt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<CabinsResult> GetByEmailAsync(string token, string email)
        {
            try
            {
                var responseMessage = await ApiRequest("https://arcada-cabin-broker.azurewebsites.net/cabins/", token);

                var content = responseMessage.ResponseMessage.Content;
                var json = await content.ReadAsStringAsync();


                var js = new JavaScriptSerializer();
                var body = js.Deserialize<CabinsResponse>(json);
                var cabins = new List<Cabin>(body.cabins);
                var emailCabins = FindCabinsByEmail(cabins, email);

                if (emailCabins.Count == 0)
                {
                    return null;
                }

                var cabinsAndJwt = new CabinsResult
                {
                    Cabins = emailCabins,
                    Jwt = responseMessage.Jwt
                };

                return cabinsAndJwt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private List<Cabin> FindCabinsByEmail(List<Cabin> cabins, string email)
        {
            var foundCabins = new List<Cabin>();
            foreach (Cabin cabin in cabins)
            {
                if (cabin.owner.email.ToLower() == email.ToLower())
                {
                    foundCabins.Add(cabin);
                }
            }

            return foundCabins;
        }

        public async Task<ResponseMessageAndToken> ApiRequest(string uri, string token)
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(uri),
                Method = HttpMethod.Get
            };
            request.Headers.Authorization = new AuthenticationHeaderValue(token);
            var message = await client.SendAsync(request);

            // If the JWT token was invalid, login to get valid JWT then do the request.
            if (message.StatusCode == HttpStatusCode.Unauthorized)
            {
                var newRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri(uri),
                    Method = HttpMethod.Get
                };
                string newToken = await LoginToBroker();
                AuthenticationHeaderValue jwt = new AuthenticationHeaderValue(newToken);
                newRequest.Headers.Authorization = jwt;
                var newMessage = await client.SendAsync(newRequest);

                return new ResponseMessageAndToken(newMessage, jwt);
            }

            AuthenticationHeaderValue jwtFromMsg;
            if (message.Headers.TryGetValues("Authorization", out IEnumerable<string> values))
            {
                jwtFromMsg = new AuthenticationHeaderValue(values.First());
            }
            else
            {
                throw new Exception("Authorization header not found from the response");
            }

            return new ResponseMessageAndToken(message, jwtFromMsg);
        }

        public async Task<string> LoginToBroker()
        {
            string token;
            string jsonBody = "{\"email\": \"arcada.cms.api@foo.com\", \"password\": \"qweqweqwe\"}";
            StringContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("https://arcada-cabin-broker.azurewebsites.net/users/login", content);
            var headers = response.Headers;
            if (headers.TryGetValues("Authorization", out IEnumerable<string> values))
            {
                token = values.First();
            }
            else
            {
                throw new Exception("Authorization header not found from the response");
            }

            return token;
        }
    }
}
