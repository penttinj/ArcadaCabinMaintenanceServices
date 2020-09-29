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
using System.Threading.Tasks;

namespace ArcadaCMSApi.UseCases
{
    public class CabinsUseCase
    {
        //private readonly ILogger<CabinsUseCase> _logger;
        HttpClient client;
        public CabinsUseCase(HttpClient _client)
        {
//            _logger = logger;
            client = _client;
        }

        public async Task<List<Cabin>> GetAll(string token)
        {
            try
            {
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://arcada-cabin-broker.azurewebsites.net/cabins/"),
                    Method = HttpMethod.Get
                };
                request.Headers.Add("Authorization", token);
                var responseMessage = await client.SendAsync(request);
                var content = responseMessage.Content;
                var json = await content.ReadAsStringAsync();

                JavaScriptSerializer js = new JavaScriptSerializer();
                CabinsResponse body = js.Deserialize<CabinsResponse>(json);
                var cabinz = body.cabins;
                var cabins = new List<Cabin>(cabinz);
                string[] things = new string[5];
                things[0] = "zero";
                things[1] = "two";
                List<string> listan = new List<string>(things);
                return cabins;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }


    }
}
