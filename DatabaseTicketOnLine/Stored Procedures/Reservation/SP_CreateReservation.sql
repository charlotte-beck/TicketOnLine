CREATE PROCEDURE [dbo].[SP_CreateReservation]
	@UserId INT, 
	@EventId INT, 
	@FactureDate DATE, 
	@NbTicket INT,
	@FactureTotal FLOAT, 
	@NumTransactionValidee INT

AS
BEGIN
	INSERT INTO Reservation (UserId, EventId, FactureDate, NbTicket, FactureTotal, NumTransactionValidee) 
	VALUES (@UserId, @EventId, @FactureDate, @NbTicket, @FactureTotal, @NumTransactionValidee);
END