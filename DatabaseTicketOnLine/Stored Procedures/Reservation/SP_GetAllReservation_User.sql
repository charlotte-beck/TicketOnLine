CREATE PROCEDURE [dbo].[SP_GetAllReservation_User]
	@UserId INT
AS
BEGIN
	SELECT r.ReservationId, r.UserId, r.EventId, r.FactureDate, r.NbTicket, r.FactureTotal, r.NumTransactionValidee, u.Email AS [User], e.EventName AS [Event]
	FROM [User] u 
	RIGHT JOIN Reservation r ON u.UserId = r.UserId
	LEFT JOIN [Event] e ON r.EventId = e.EventId
	WHERE r.UserId = @UserId;
END