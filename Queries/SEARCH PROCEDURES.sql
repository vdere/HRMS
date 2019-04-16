    ---/// <summary>
    ---/// Employee ID :161585
    ---/// Employee Name : Viraj Dere
    ---/// Description : Search Procedures
    ---/// Date of Creation : 10/19/2018
    ---/// </summary>




use Sep19CHN

--SEARCH PROCEDURES FOR HR CLERK
--SEARCH EMPLOYEE
CREATE PROC Group4.usp_SearchEmployee
(
	@Employee_Id		INT
)
AS
BEGIN
	SELECT * FROM Group4.Employee

	WHERE Employee_Id = @Employee_Id
END
GO

--SEARCH PROJECTS
CREATE PROC Group4.usp_SearchProject
(
	@Project_Id		INT
)
AS
BEGIN
	SELECT * FROM Group4.Project
	WHERE Project_Id = @Project_Id
END
GO

--SEARCH SKILLS
ALTER PROC Group4.usp_SearchSkills
(
	@Skill_Id		INT
)
AS
BEGIN
SELECT s.Skill_Id ,s.Skill_Name ,s.Skill_Description ,
	 c.Category_Id,c.Category_Name 
FROM Group4.Skill s
	 JOIN Group4.Category c ON s.Category_Id = c.Category_Id
WHERE Skill_Id = @Skill_Id
END
GO
exec Group4.usp_SearchSkills 101
--SEARCH CATEGORIES
ALTER PROC Group4.usp_SearchCategories
(
	@Category_Id 	INT
)
AS
BEGIN
	SELECT * FROM Group4.Category
	WHERE Category_Id = @Category_Id
END
GO
exec Group4.usp_SearchCategories 101
select * from Group4.Category


--SEARCH PROCEDURES FOR ADMIN
--SEARCH USER
CREATE PROC Group4.usp_SearchUser
(
	@UserId 	INT
)
AS
BEGIN
	SELECT * FROM Group4.Users
	WHERE UserId = @UserId
END
GO

--SEARCH CIVILSTATUS
CREATE PROC Group4.usp_SearchCivilStatus
(
	@Status_Id	INT
)
AS
BEGIN
	SELECT * FROM Group4.Civil_Status
	WHERE Status_Id = @Status_Id
END
GO

--SEARCH LEVEL
CREATE PROC Group4.usp_SearchLevel
(
	@Level_Id	INT
)
AS
BEGIN
	SELECT * FROM Group4.Level_
	WHERE Level_Id = @Level_Id
END
GO

--SEARCH SPECIALITY
CREATE PROC Group4.usp_SearchSpec
(
	@Speciality_Id	INT
)
AS
BEGIN
	SELECT * FROM Group4.Speciality
	WHERE Speciality_Id = @Speciality_Id
END
GO

select IDENT_CURRENT('Group4.Speciality')+ident_incr('Group4.Speciality')