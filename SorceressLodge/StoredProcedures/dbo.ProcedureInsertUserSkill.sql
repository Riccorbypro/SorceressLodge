CREATE PROCEDURE [dbo].[Procedure_InsertUserSkill]
	@userid int,
	@typeid int,
	@profic int
AS
	INSERT into UserSkills(UserID, TypeID, Proficiency) values(@userid, @typeid, @profic)
RETURN 0
