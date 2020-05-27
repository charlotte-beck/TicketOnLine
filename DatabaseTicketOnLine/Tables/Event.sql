﻿CREATE TABLE [dbo].[Event]
(
	EventId INT NOT NULL IDENTITY,
	EventType NVARCHAR(128) NOT NULL,
	EventName NVARCHAR(128) NOT NULL,
	EventDate DATE NOT NULL,
	EventDescription NVARCHAR(255) NOT NULL,
	EventOrg NVARCHAR(128) NOT NULL,
	EventLocation NVARCHAR(128) NOT NULL,
	EventPrice FLOAT NOT NULL,
	CONSTRAINT [PK_Event] PRIMARY KEY ([EventId])
)
