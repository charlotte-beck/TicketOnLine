using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IReservationAPIRequester<TEntity, T>
    {
        IEnumerable<T> GetAllByEvent(int eventId);
        T GetOneReservation(int reservationId);
        IEnumerable<T> GetAllByUser(int userId);
        TEntity CreateReservation(TEntity entity);
        //bool UpdateReservation(int reservationId, TEntity entity);
        //void DeleteReservation(int reservationId);
    }
}
