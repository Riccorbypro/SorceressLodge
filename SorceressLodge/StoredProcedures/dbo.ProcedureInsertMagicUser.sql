CREATE PROCEDURE [dbo].[Procedure_InsertMU]
	@fname varchar(20),
	@sname varchar(20),
	@desc varchar(127)
AS
	insert into MagicUsers(FName,SName,Description) values(@fname, @sname, @desc) 
RETURN 0
