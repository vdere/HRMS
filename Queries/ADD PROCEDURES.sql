    ---/// <summary>
    ---/// Employee ID :161585
    ---/// Employee Name : Viraj Dere
    ---/// Description : Add Procedures
    ---/// Date of Creation : 10/19/2018
    ---/// </summary>

use Sep19CHN



--ADD EMPLOYEE
ALTER PROC Group4.usp_AddEmployee
(
	@Employee_Id    INT,
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
	INSERT INTO 
	Group4.Employee(
	First_Name, Middle_Name, Last_Name,Birth_Date,Age,Gender,Civil_Status,Religion,
	Citizenship,Mobile_No,Home_Phone_No,Address_,City,State_,Pincode,Country,
	Project_Id,Skill_Id,Educational_Background)

	VALUES(@First_Name, @Middle_Name,@Last_Name,@Birth_Date,@Age,@Gender,@Civil_Status,@Religion,
	@Citizenship,@Mobile_No,@Home_Phone_No,@Address_,@City,@State_,@Pincode,@Country,
	@Project_Id,@Skill_Id,@Educational_Background)
	
	INSERT INTO
	Group4.Capgemini_Details(
	Employee_Id,
	Email,Level_Id,Date_Hired,Speciality)
	VALUES(@Employee_Id,@Email,@Level_Id,@Date_Hired,@Speciality)
END
GO

--ADD PROJECTS
CREATE PROC Group4.usp_AddProject
(
	@Project_Name		VARCHAR(20),
	@Project_Description VARCHAR(50),
	@Project_Client		VARCHAR(20),
	@Project_Start_Date	DATE,
	@Project_End_Date	DATE
)
AS
BEGIN
	INSERT INTO 
	Group4.Project(
	Project_Name,Project_Description,Project_Client,Project_Start_Date,
	Project_End_Date
	)

	VALUES(@Project_Name,@Project_Description,@Project_Client,@Project_Start_Date,
	@Project_End_Date)
END
GO

--ADD SKILLS
CREATE PROC Group4.usp_AddSkill
(
	@Skill_Name			VARCHAR(20),
	@Skill_Description	VARCHAR(50),
	@Category_Id		INT
)
AS
BEGIN
	INSERT INTO 
	Group4.Skill(Skill_Name,Skill_Description,Category_Id)

	VALUES(@Skill_Name,@Skill_Description,@Category_Id)
END
GO

--ADD CATEGORIES
CREATE PROC Group4.usp_AddCategory
(
	@Category_Name		  VARCHAR(20),
	@Category_Description VARCHAR(50)
)
AS
BEGIN
	INSERT INTO 
	Group4.Category(Category_Name,Category_Description)

	VALUES(@Category_Name,@Category_Description)
END
GO


--CLERK/MANAGER SIGNUP
CREATE PROC Group4.usp_AddUser
(
	@UserName CHAR(128),
	@Password_ CHAR(128),
	@First_Name VARCHAR(15),
	@Last_Name VARCHAR(15)
)
AS
BEGIN
	INSERT INTO 
	Group4.Users(UserName,Password_,First_Name,Last_Name)
	VALUES(@UserName,@Password_,@First_Name,@Last_Name)
END
GO



--ADMIN PROCEDURES
--ADD CIVIL STATUS
CREATE PROC Group4.usp_AddCivilStatus
(
	@Status_Description VARCHAR(20)
)
AS
BEGIN
	INSERT INTO 
	Group4.Civil_Status(Status_Description)
	VALUES(@Status_Description)
END
GO

--ADD SPECIALITY 
CREATE PROC Group4.usp_AddSpeciality
(
	@Speciality_Name VARCHAR(20)
)
AS
BEGIN
	INSERT INTO 
	Group4.Speciality(Speciality_Name)
	VALUES(@Speciality_Name)
END
GO

--ADD LEVEL DESCRIPTION
CREATE PROC Group4.usp_AddLevel
(
	@Level_Description VARCHAR(20)
)
AS
BEGIN
	INSERT INTO 
	Group4.Level_(Level_Description)
	VALUES(@Level_Description)
END
GO