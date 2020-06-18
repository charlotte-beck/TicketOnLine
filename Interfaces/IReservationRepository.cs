using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IReservationRepository<TEntity, T>
    {
        List<T> GetAllReservationByEvent(int eventId);
        T GetOneReservation(int reservationId);
        List<T> GetAllReservationByUser(int userId);
        TEntity CreateReservation(TEntity entity);
        //bool UpdateReservation(int reservationId, TEntity entity);
        //void DeleteReservation(int reservationId);
    }
}
