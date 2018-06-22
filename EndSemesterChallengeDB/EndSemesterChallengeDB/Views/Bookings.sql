CREATE VIEW [dbo].[Bookings]
	AS SELECT Client, TourName, EventMonth, EventDay, EventYear, Payment, DateBooked FROM [Booking]
