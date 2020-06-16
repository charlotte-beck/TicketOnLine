CREATE PROCEDURE [dbo].[SP_GetReservation]
	@ReservationId INT
AS
BEGIN
	SELECT r.ReservationId, r.UserId, r.EventId, r.FactureDate, r.FactureTotal, r.NumTransactionValidee, u.Email AS [User], u.Email, e.EventName AS [Event]
	FROM [User] u 
	RIGHT JOIN Reservation r ON u.UserId = r.UserId
	LEFT JOIN [Event] e ON r.EventId = e.EventId
	WHERE r.ReservationId = @ReservationId;
END