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
    public class serviceUseCase : IserviceUseCase
    {
        private readonly IDbConnection _sql;
        public serviceUseCase(IDbConnection sql)
        {
            _sql = sql;
        }
        
        public IEnumerable<Room> GetAll()
        {
            const string query = "INSERT INTO Rooms (name, seats, computers) VALUES ('ACMS', 4, 2)";

            return _sql.Query<Room>(query);
        }
    }
}
