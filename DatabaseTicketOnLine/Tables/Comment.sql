CREATE TABLE [dbo].[Comment]
(
	CommentId INT NOT NULL IDENTITY,
	UserId INT NOT NULL,
	EventId INT NOT NULL,
	CommentDate DATE NOT NULL,
	CommentContent NVARCHAR(max) NOT NULL,
	CONSTRAINT [PK_Comment] PRIMARY KEY (CommentId),
	CONSTRAINT [FK_UserComment] FOREIGN KEY (UserId) REFERENCES [User](UserId),
	CONSTRAINT [FK_EventComment] FOREIGN KEY (EventId) REFERENCES [Event](EventId)
)
