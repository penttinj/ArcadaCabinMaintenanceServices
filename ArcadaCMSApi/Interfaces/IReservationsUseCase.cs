using ArcadaCMSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcadaCMSApi.Interfaces
{
    public interface IReservationsUseCase
    {
        IEnumerable<ReservationResponse> GetAll();
        IEnumerable<ReservationResponse> GetAll(string email);
        int Create(Reservation reservation);
        IEnumerable<Reservation> Update(int id, Reservation reservation);
        int Delete(int id);
        bool isEmptyReservation(Reservation reservation);
    }
}
