﻿CREATE TABLE [dbo].[Booking]
(
	[Client] INT NOT NULL,
	[TourName] NVARCHAR(100) NOT NULL,
	[EventMonth] NVARCHAR(20) NOT NULL,
	[EventDay] INT NOT NULL,
	[EventYear] INT NOT NULL,
	[Payment] MONEY NOT NULL,
	[DateBooked] DATE NOT NULL,
	CONSTRAINT PK_BOOKING PRIMARY KEY(Client, TourName, DateBooked),
	CONSTRAINT FK_BOOKING_ClientID FOREIGN KEY (Client) REFERENCES Client(ClientID),
	CONSTRAINT FK_BOOKING_TourName FOREIGN KEY (TourName) REFERENCES Tour(TourName)

)