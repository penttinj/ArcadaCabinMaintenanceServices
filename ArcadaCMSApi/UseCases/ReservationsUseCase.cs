using ArcadaCMSApi.Interfaces;
using ArcadaCMSApi.Models;
using Dapper;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.UseCases
{
    public class ReservationsUseCase : IReservationsUseCase
    {
        private readonly IDbConnection _sql;
        public ReservationsUseCase(IDbConnection sql)
        {
            _sql = sql;
        }



        public IEnumerable<ReservationResponse> GetAll()
        {
            string query = "SELECT Reservations.*, Services.ServiceType, Services.Description, Services.Price " +
                "FROM Reservations INNER JOIN Services ON Reservations.ServiceId = Services.id";

            var reservations = _sql.Query<ReservationResponse>(query);

            return reservations;
        }


        public IEnumerable<ReservationResponse> GetAll(string email)
        {
            string query = $"SELECT Reservations.*, Services.ServiceType, Services.Description, Services.Price " +
                "from Reservations INNER JOIN Services ON Reservations.ServiceId = Services.id " +
                $"WHERE CabinEmail = '{email}' ";

            return _sql.Query<ReservationResponse>(query);
        }


        public int Create(Reservation reservation)
        {
            const string query = "INSERT INTO Reservations (ServiceId, CabinId, CabinOwnerName, CabinEmail, CabinAddress, ScheduledDate) " +
                "VALUES (@ServiceId, @CabinId, @CabinOwnerName, @CabinEmail, @CabinAddress, @ScheduledDate)";

            int affectedRows = _sql.Execute(query, reservation);

            return affectedRows;
        }

        public IEnumerable<Reservation> Update(int id, Reservation reservation)
        {
            string s = "";
            // Here comes stupid code :D again

            s += (reservation.ServiceId != 0) ? $" ServiceId='{reservation.ServiceId}'," : "";
            s += (reservation.CabinId != null) ? $" CabinId='{reservation.CabinId}'," : "";
            s += (reservation.CabinOwnerName != null) ? $" CabinOwnerName='{reservation.CabinOwnerName}'," : "";
            s += (reservation.CabinEmail != null) ? $" CabinEmail='{reservation.CabinEmail}'," : "";
            s += (reservation.CabinAddress != null) ? $" CabinAddress='{reservation.CabinAddress}'," : "";
            s += (reservation.ScheduledDate != null) ? $" ScheduledDate='{reservation.ScheduledDate}'," : "";


            string updatedValues = s.EndsWith(",") ? s.Remove(s.Length - 1) : s;

            string query = $"UPDATE Reservations SET {updatedValues} WHERE id = {id}";

            int affectedRows = _sql.Execute(query);
            if (affectedRows > 0)
            {
                return _sql.Query<Reservation>($"Select * from Reservations WHERE id = '{id}'");
            }

            return null;
        }

        public int Delete(int id)
        {
            string query = $"DELETE FROM Reservations WHERE id = {id}";

            int affectedRows = _sql.Execute(query);

            return affectedRows;

        }


        public bool isEmptyReservation(Reservation reservation)
        {
            return (reservation.ServiceId == 0 && reservation.CabinId == null && reservation.CabinOwnerName == null && reservation.CabinEmail == null
                 && reservation.CabinAddress == null && reservation.ScheduledDate == null);
        }

    }
}
