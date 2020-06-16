CREATE PROCEDURE [dbo].[SP_CreateReservation]
	@UserId INT, 
	@EventId INT, 
	@FactureDate DATE, 
	@FactureTotal FLOAT, 
	@NumTransactionValidee INT

AS
BEGIN
	INSERT INTO Reservation (UserId, EventId, FactureDate, FactureTotal, NumTransactionValidee) 
	VALUES (@UserId, @EventId, @FactureDate, @FactureTotal, @NumTransactionValidee);
END