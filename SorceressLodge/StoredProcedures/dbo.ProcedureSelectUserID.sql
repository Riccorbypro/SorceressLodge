CREATE PROCEDURE [dbo].[Procedure_SelectUserID]
	@fname varchar(20),
	@sname varchar(20),
	@desc varchar(127),
	@image varbinary(MAX)
AS
	SELECT UserID from MagicUsers where FName=@fname and SName=@sname and Image=@image and Description=@desc
RETURN UserID;
