CREATE PROCEDURE [dbo].[Procedure_InsertMU]
	@fname varchar(20),
	@sname varchar(20),
	@desc varchar(127),
	@image varbinary(MAX)
AS
	insert into MagicUsers(FName,SName,Description,Image) values(@fname, @sname, @desc, @image) 
RETURN 0
