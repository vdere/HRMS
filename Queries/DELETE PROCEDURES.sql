use Sep19CHN

--DELETE PROCEDURES
--CLERK PROCEDURES
--DELETE EMPLOYEE
ALTER PROC Group4.usp_DeleteEmployee
(
	@Employee_Id		INT
)
AS
BEGIN
	DELETE FROM Group4.Employee
	WHERE Employee_Id = @Employee_Id
END
GO

exec Group4.usp_DeleteEmployee 1005

--DELETE PROJECTS
CREATE PROC Group4.usp_DeleteProjects
(
	@Project_Id		INT
)
AS
BEGIN
	DELETE FROM Group4.Project
	WHERE Project_Id = @Project_Id
END
GO

--DELETE SKILLS
CREATE PROC Group4.usp_DeleteSkills
(
	@Skill_Id		INT
)
AS
BEGIN
	DELETE FROM Group4.Skill
	WHERE Skill_Id = @Skill_Id
END
GO

--DELETE CATEGORIES
ALTER PROC Group4.usp_DeleteCategory
(
	@Category_Id		INT
)
AS
BEGIN
	DELETE FROM Group4.Category
	WHERE Category_Id = @Category_Id
END
GO
select * from Group4.Category




--ADMIN PROCEDURES
--DELETE USER
CREATE PROC Group4.usp_DeleteUser
(
	@UserId		INT
)
AS
BEGIN
	DELETE FROM Group4.Users
	WHERE UserId = @UserId
END
GO

--DELETE SPECIALITY
CREATE PROC Group4.usp_DeleteSpec
(
	@Speciality_Id		INT
)
AS
BEGIN
	DELETE FROM Group4.Speciality
	WHERE Speciality_Id = @Speciality_Id
END
GO

--DELETE CIVILSTATUS
CREATE PROC Group4.usp_DeleteCivilStatus
(
	@Status_Id		INT
)
AS
BEGIN
	DELETE FROM Group4.Civil_Status
	WHERE Status_Id = @Status_Id
END
GO

--DELETE Employee
ALTER TABLE Group4.Capgemini_Details
ADD CONSTRAINT fk_name
	FOREIGN KEY(Employee_Id)
	REFERENCES Group4.Employee(Employee_Id)
	ON DELETE CASCADE