CREATE PROCEDURE [dbo].[Procedure_Delete]
	@userid int
AS
	DELETE FROM UserSkills WHERE UserID=@userid
	DELETE FROM Bounty WHERE UserID=@userid
	DELETE FROM Location WHERE UserID=@userid
	DELETE FROM MagicUsers WHERE UserID=@userid
RETURN 0
