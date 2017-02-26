CREATE PROCEDURE [dbo].[Procedure_Insert]
	@userid int,
	@typeid int,
	@profic int,
	@fname varchar(20),
	@sname varchar(20),
	@desc varchar(127),
	@image image,
	@bounty float,
	@location varchar(127),
	@datetime datetime

AS
	insert into MagicUsers(FName,SName,Desription,Image) values(@fname, @sname, @desc, @image)
	insert into UserSkills(UserID, TypeID, Proficiency) values(@userid, @typeid, @profic)
	insert into Location(UserID, Location, DateTime) values(@userid, @location,@datetime)
	insert into Bounty(UserID, Bounty) values(@userid, @bounty)
RETURN 0
