using ArcadaCMSApi.Interfaces;
using ArcadaCMSApi.Models;
using Dapper;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;




namespace ArcadaCMSApi.UseCases
{
    public class CabinsListResponse
    {
        public List<Cabin> Cabins { get; set; }
        public AuthenticationHeaderValue Jwt { get; set; }
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
        HttpClient client;
        public CabinsUseCase(HttpClient _client)
        {
            client = _client;
        }



        public async Task<List<Cabin>> GetAll(string token)
        {
            try
            {
                var qwe = new CabinsListResponse();
                var responseMessage = await ApiRequest("https://arcada-cabin-broker.azurewebsites.net/cabins/", token);
                
                var content = responseMessage.ResponseMessage.Content;
                var json = await content.ReadAsStringAsync();


                JavaScriptSerializer js = new JavaScriptSerializer();
                CabinsResponse body = js.Deserialize<CabinsResponse>(json);
                var cabins = new List<Cabin>(body.cabins);
                return cabins;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

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


            if (message.StatusCode == HttpStatusCode.Unauthorized)
            {
                var newRequest = new HttpRequestMessage()
                {
                    RequestUri = new Uri(uri),
                    Method = HttpMethod.Get
                };
                string newToken = await LoginToBroker();
                AuthenticationHeaderValue authValue = new AuthenticationHeaderValue(newToken);
                newRequest.Headers.Authorization = authValue;
                var newMessage = await client.SendAsync(newRequest);

                return new ResponseMessageAndToken(newMessage, authValue);
            }
            
            IEnumerable<string> values;
            AuthenticationHeaderValue jwtFromMsg;
            if (message.Headers.TryGetValues("Authorization", out values))
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
            IEnumerable<string> values;
            if (headers.TryGetValues("Authorization", out values))
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
