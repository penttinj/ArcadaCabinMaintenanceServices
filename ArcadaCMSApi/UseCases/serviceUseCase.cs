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
        
        public Boolean Create(Service service)
        {
            const string query = "INSERT INTO Services (ServiceType, Description, Price) VALUES (@ServiceType, @Description, @Price)";

            var result = _sql.Query(query, service);

            return true;

        }

        public IEnumerable<Service> GetAll()
        {
            const string query = "SELECT * from Services";

            return _sql.Query<Service>(query);
        }
    }
}
