CREATE PROCEDURE [dbo].[SP_UpdateReservation]
	@ReservationId INT,
	@FactureDate DATE, 
	@FactureTotal FLOAT, 
	@NumTransactionValidee INT
AS
BEGIN
	UPDATE Reservation 
	SET FactureDate = @FactureDate, FactureTotal = @FactureTotal, NumTransactionValidee = @NumTransactionValidee
	WHERE ReservationId = @ReservationId;
END