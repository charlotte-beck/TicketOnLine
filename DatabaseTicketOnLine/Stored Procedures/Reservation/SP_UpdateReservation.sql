CREATE PROCEDURE [dbo].[SP_UpdateReservation]
	@ReservationId INT,
	@FactureDate DATE, 
	@NbTicket INT,
	@FactureTotal FLOAT, 
	@NumTransactionValidee INT
AS
BEGIN
	UPDATE Reservation 
	SET FactureDate = @FactureDate, NbTicket = @NbTicket, FactureTotal = @FactureTotal, NumTransactionValidee = @NumTransactionValidee
	WHERE ReservationId = @ReservationId;
END