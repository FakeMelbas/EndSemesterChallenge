/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if '$(LoadTestData)' = 'True' 

BEGIN

DELETE FROM Booking;
DELETE FROM TourEvent;
DELETE FROM Tour;
DELETE FROM Client;



INSERT INTO Client(ClientID, Surname, GivenName, Gender) VALUES 
(1, 'Price', 'Taylor', 'M'),
(2, 'Gamble', 'Ellyse', 'F'),
(3, 'Price', 'Taylor', 'F');

INSERT INTO Tour(TourName, [Description]) VALUES
('West', 'Tour of wineries and outlets of the Geelong and Otways region'),
('East', 'Tour of wineries and outlets of Yarra Valley'),
('South', 'Tour of wineries and outlets of Mornington Penisula'),
('North', 'Tour of wineries and outlets of the Bendigo and Castlemaine region');

INSERT INTO TourEvent(TourName, EventMonth, EventDay, EventYear, Fee) VALUES
('North', 'Jan', 9, 2016, $200),
('North', 'Feb', 13, 2016, $225),
('South', 'Jan', 16, 2016, $200),
('West', 'Jan', 29, 2016, $225);

INSERT INTO Booking(Client, TourName, EventMonth, EventDay, EventYear, Payment, DateBooked) VALUES
(1, 'North', 'Jan', 9, 2016, $200, '12/10/2015'),
(2, 'North', 'Jan', 9, 2016, $200, '12/16/2015'),
(1, 'North', 'Feb', 13, 2016, $225, '01/08/2016'),
(2, 'North', 'Feb', 13, 2016, $225, '01/14/2016'),
(3, 'North', 'Feb', 13, 2016, $225, '02/03/2016'),
(1, 'South', 'Jan', 16, 2016, $200, '12/10/2015'),
(2, 'South', 'Jan', 16, 2016, $200, '12/18/2015'),
(3, 'South', 'Jan', 16, 2016, $200, '01/09/2016'),
(2, 'West', 'Jan', 29, 2016, $200, '12/17/2015'),
(3, 'West', 'Jan', 29, 2016, $200, '12/18/2015');


END