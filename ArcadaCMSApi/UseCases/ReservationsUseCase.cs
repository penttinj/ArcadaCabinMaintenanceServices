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
    public class ReservationsUseCase: IReservationsUseCase
    {
        private readonly IDbConnection _sql;
        public ReservationsUseCase(IDbConnection sql)
        {
            _sql = sql;
        }



        public IEnumerable<Reservation> GetAll()
        {
            // TODO: Fill out Reservation info based on ServiceId, innerjoins?
            const string query = "SELECT * from Reservations";

            return _sql.Query<Reservation>(query);
        }

        public int Create(Reservation reservation)
        {
            const string query = "INSERT INTO Reservations (ServiceType, Description, Price) VALUES (@ServiceType, @Description, @Price)";

            int affectedRows = _sql.Execute(query, reservation);
            var insertedService = _sql.Query<Reservation>($"Select * from Reservations WHERE Description = '{reservation.Description}'");

            return affectedRows;

        }

        public IEnumerable<Reservation> Update(int id, Reservation reservation)
        {
            string s = "";
            // Here comes stupid code :D

            s += (reservation.ServiceType != null) ? $" ServiceType='{reservation.ServiceType}'," : "";
            s += (reservation.Description != null) ? $" Description='{reservation.Description}'," : "";

            // Price property defaults to 0 if it wasn't constructed, so if you initiate Price with 0 it won't be updated either! Hey nothing in life is free
            s += (reservation.Price != 0) ? $" Price='{reservation.Price}'," : "";

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
            return (reservation.ServiceType == null && reservation.Description == null && reservation.Price == 0);
        }

    }
}
