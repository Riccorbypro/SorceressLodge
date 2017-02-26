CREATE PROCEDURE [dbo].[Procedure_SelectUserID]
	@userid int,
	@fname varchar(20),
	@sname varchar(20),
	@desc varchar(127),
	@image varbinary(MAX)
AS
	SELECT UserID=@userid from MagicUsers where FName=@fname and SName=@sname and Image=@image and Description=@desc
RETURN @userid;
