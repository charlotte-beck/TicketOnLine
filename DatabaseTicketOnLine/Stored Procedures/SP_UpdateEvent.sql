CREATE PROCEDURE [dbo].[SP_UpdateEvent]
	@EventId int,
	@EventType nvarchar(128),
	@EventName nvarchar(128),
	@EventDate datetime2(7),
	@EventDescription nvarchar(255),
	@EventOrg nvarchar(128),
	@EventLocation nvarchar(128),
	@EventPrice float
AS
Begin
	Update [Event]
	Set EventType = @EventType,
	EventName = @EventName,
	EventDate = @EventDate,
	EventDescription = @EventDescription,
	EventOrg = @EventOrg,
	EventLocation = @EventLocation,
	EventPrice = @EventPrice
	where EventId = @EventId;
End
