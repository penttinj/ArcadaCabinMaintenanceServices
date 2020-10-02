using ArcadaCMSApi.Interfaces;
using ArcadaCMSApi.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.UseCases
{
    public class ServiceUseCase : IServiceUseCase
    {
        private readonly IDbConnection _sql;
        public ServiceUseCase(IDbConnection sql)
        {
            _sql = sql;
        }



        public IEnumerable<Service> GetAll()
        {
            const string query = "SELECT * from Services";

            return _sql.Query<Service>(query);
        }

        public int Create(Service service)
        {
            const string query = "INSERT INTO Services (ServiceType, Description, Price) VALUES (@ServiceType, @Description, @Price)";

            int affectedRows = _sql.Execute(query, service);
            var insertedService = _sql.Query<Service>($"Select * from Services WHERE Description = '{service.Description}'");

            return affectedRows;

        }

        public IEnumerable<Service> Update(int id, Service service)
        {
            string s = "";
            // Here comes stupid code :D

            s += (service.ServiceType != null) ? $" ServiceType='{service.ServiceType}'," : "";
            s += (service.Description != null) ? $" Description='{service.Description}'," : "";

            // Price property defaults to 0 if it wasn't constructed, so if you initiate Price with 0 it won't be updated either! Hey nothing in life is free
            s += (service.Price != 0) ? $" Price='{service.Price}'," : "";

            string updatedValues = s.EndsWith(",") ? s.Remove(s.Length - 1) : s;

            string query = $"UPDATE Services SET {updatedValues} WHERE id = {id}";

            int affectedRows = _sql.Execute(query);
            if (affectedRows > 0)
            {
                return _sql.Query<Service>($"Select * from Services WHERE id = '{id}'");
            }

            return null;
        }

        public int Delete(int id)
        {
            string query = $"DELETE FROM Services WHERE id = {id}";

            int affectedRows = _sql.Execute(query);

            return affectedRows;

        }


        public bool isEmptyService(Service service)
        {
            return (service.ServiceType == null && service.Description == null && service.Price == 0);
        }

    }
}
