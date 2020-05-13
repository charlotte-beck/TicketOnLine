CREATE PROCEDURE [dbo].[SP_CreateEvent]
	@EventType nvarchar(128),
	@EventName nvarchar(128),
	@EventDate datetime2(7),
	@EventDescription nvarchar(255),
	@EventOrg nvarchar(128),
	@EventLocation nvarchar(128),
	@EventPrice float
AS
Begin
	insert into [Event] (EventType, EventName, EventDate, EventDescription, EventOrg, EventLocation, EventPrice)
	values (@EventType, @EventName, @EventDate, @EventDescription, @EventOrg, @EventLocation, @EventPrice);
End