CREATE PROCEDURE [dbo].[Procedure_InsertBounty]
	@userid int,
	@bounty float
AS
	Insert into Bounty(UserID, Bounty) values(@userid, @bounty)
RETURN 0
