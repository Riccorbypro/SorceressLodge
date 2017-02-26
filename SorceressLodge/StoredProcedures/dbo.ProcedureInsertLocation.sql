CREATE PROCEDURE [dbo].[Procedure_InsertLocation]
	@userid int,
	@location varchar(127),
	@date datetime
AS
	Insert into Location(UserID, Location, DateTime) values(@userid, @location, @date)
RETURN 0
