    ---/// <summary>
    ---/// Employee ID :161585
    ---/// Employee Name : Viraj Dere
    ---/// Description : Update Procedures
    ---/// Date of Creation : 10/19/2018
    ---/// </summary>


use Sep19CHN

--UPDATE PROCEDURES
--HR CLERK./MANAGER PROCEDURES
--UPDATE EMPLOYEE
ALTER PROC Group4.usp_UpdateEmployee
(
	@Employee_Id INT,
	@First_Name		VARCHAR(10),
	@Middle_Name	VARCHAR(10),
	@Last_Name		VARCHAR(10),
	@Birth_Date		DATE,
	@Age			INT,
	@Gender			VARCHAR(10),
	@Civil_Status	INT,
	@Religion		VARCHAR(20),
	@Citizenship	VARCHAR(20),
	@Mobile_No		BIGINT,
	@Home_Phone_No	BIGINT,
	@Address_		VARCHAR(100),
	@City			VARCHAR(20),
	@State_			VARCHAR(20),
	@Pincode		BIGINT,
	@Country		VARCHAR(20),
	@Project_Id		INT,
	@Skill_Id		INT,
	@Educational_Background VARCHAR(20),
	@Email			VARCHAR(50),
	@Level_Id		INT,
	@Date_Hired		DATE,
	@Speciality		INT
)
AS
BEGIN
	UPDATE Group4.Employee
	SET First_Name	= @First_Name, 
		Middle_Name = @Middle_Name,
		Last_Name	= @Last_Name,
		Birth_Date	= @Birth_Date,
		Age			= @Age,
		Gender		= @Gender,
		Civil_Status = @Civil_Status,
		Religion	= @Religion,
		Citizenship = @Citizenship,
		Mobile_No	= @Mobile_No,
		Home_Phone_No = @Home_Phone_No,
		Address_	= @Address_,
		City		= @City,
		State_		= @State_,
		Pincode		= @Pincode,
		Country		= @Country,
		Project_Id	= @Project_Id,
		Skill_Id	= @Skill_Id,
		Educational_Background = @Educational_Background
	WHERE Employee_Id = @Employee_Id

	UPDATE Group4.Capgemini_Details
	SET Email		= @Email,
		Level_Id	= @Level_Id,
		Date_Hired	=@Date_Hired,
		Speciality	= @Speciality
	WHERE Employee_Id = @Employee_Id
END
GO

--UPDATE PROJECTS
CREATE PROC Group4.usp_UpdateProject
(
	@Project_Id			INT,
	@Project_Name		VARCHAR(20),
	@Project_Description VARCHAR(50),
	@Project_Client		VARCHAR(20),
	@Project_Start_Date	DATE,
	@Project_End_Date	DATE
)
AS
BEGIN
	UPDATE Group4.Project
	SET Project_Name		= @Project_Name, 
		Project_Description = @Project_Description,
		Project_Client		= @Project_Client,
		Project_Start_Date	= @Project_Start_Date,
		Project_End_Date	= @Project_End_Date
	WHERE Project_Id = @Project_Id
END
GO

--UPDATE SKILLS
CREATE PROC Group4.usp_UpdateSkill
(
	@Skill_Id			INT,
	@Skill_Name			VARCHAR(20),
	@Skill_Description	VARCHAR(50),
	@Category_Id		INT
)
AS
BEGIN
	UPDATE Group4.Skill
	SET Skill_Name		= @Skill_Name, 
		Skill_Description = @Skill_Description,
		Category_Id		= @Category_Id
	WHERE Skill_Id = @Skill_Id
END
GO

--UPDATE CATEGORIES
CREATE PROC Group4.usp_UpdateCategory
(
	@Category_Id			INT,
	@Category_Name		  VARCHAR(20),
	@Category_Description VARCHAR(50)
)
AS
BEGIN
	UPDATE Group4.Category
	SET Category_Name		 = @Category_Name, 
		Category_Description = @Category_Description
	WHERE Category_Id = @Category_Id
END
GO


--ADMIN PROCEDURES
--UPDATE USER
CREATE PROC Group4.usp_UpdateUser
(
	@UserId		INT,
	@UserName	VARCHAR(20),
	@Password_	VARCHAR(20),
	@First_Name VARCHAR(15),
	@Last_Name	VARCHAR(15)
)
AS
BEGIN
	UPDATE Group4.Users
	SET UserName	= @UserName, 
		Password_	= @Password_ ,
		First_Name	= @First_Name,
		Last_Name	= @Last_Name
	WHERE UserId	=@UserId
END
GO

--UPDATE CIVILSTATUS
CREATE PROC Group4.usp_UpdateCivilStatus
(
	@Status_Id INT ,
	@Status_Description VARCHAR(20)
)
AS
BEGIN
	UPDATE Group4.Civil_Status
	SET Status_Description	= @Status_Description
	WHERE Status_Id	= @Status_Id
END
GO

--UPDATE LEVEL
CREATE PROC Group4.usp_UpdateLevel
(
	@Level_Id INT ,
	@Level_Description VARCHAR(20)
)
AS
BEGIN
	UPDATE Group4.Level_
	SET Level_Description	= @Level_Description
	WHERE Level_Id	= @Level_Id
END
GO

--UPDATE SPECIALITY
CREATE PROC Group4.usp_UpdateSpeciality
(
	@Speciality_Id INT ,
	@Speciality_Name VARCHAR(20)
)
AS
BEGIN
	UPDATE Group4.Speciality
	SET Speciality_Name	= @Speciality_Name
	WHERE Speciality_Id	= @Speciality_Id
END
GO