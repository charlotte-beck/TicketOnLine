CREATE PROCEDURE [dbo].[SP_DeleteReservation]
	@ReservationId INT
AS
BEGIN
	DELETE FROM Reservation 
	WHERE ReservationId = @ReservationId; 
END