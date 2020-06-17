CREATE TABLE [dbo].[Reservation]
(
	[ReservationId] INT NOT NULL IDENTITY,
	UserId INT NOT NULL,
	EventId INT NOT NULL,
	FactureDate DATE NOT NULL,
	NbTicket INT NOT NULL,
	FactureTotal FLOAT NOT NULL,
	NumTransactionValidee INT NOT NULL,
	CONSTRAINT [PK_Reservation] PRIMARY KEY ([ReservationId]),
	CONSTRAINT [FK_UserReservation] FOREIGN KEY (UserId) REFERENCES [User]([UserId]),
	CONSTRAINT [FK_EventReservation] FOREIGN KEY (EventId) REFERENCES [Event]([EventId])
)
