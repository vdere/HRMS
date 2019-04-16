    ---/// <summary>
    ---/// Employee ID :161585
    ---/// Employee Name : Viraj Dere
    ---/// Description : Table Creations
    ---/// Date of Creation : 10/19/2018
    ---/// </summary>

use Sep19CHN

CREATE SCHEMA Group4

--SPECIALITY TABLE
CREATE TABLE Group4.Speciality
(
	Speciality_Id INT IDENTITY(1100,1) PRIMARY KEY,
	Speciality_Name VARCHAR(20)
)

--LEVEL TABLE
CREATE TABLE Group4.Level_
(
	Level_Id INT IDENTITY(10,1) PRIMARY KEY,
	Level_Description VARCHAR(50)
)
select * from Group4.Level_
delete from Group4.Level_ where Level_Id=14
--CIVIL STATUS TABLE
CREATE TABLE Group4.Civil_Status
(
	Status_Id INT IDENTITY(100,1) PRIMARY KEY,
	Status_Description VARCHAR(20)
)

--CATEGORY TABLE
CREATE TABLE Group4.Category
(
	Category_Id INT IDENTITY(100,1) PRIMARY KEY,
	Category_Name VARCHAR(20),
	Category_Description VARCHAR(50)
)

--PROJECT TABLE
CREATE TABLE Group4.Project
(
	Project_Id INT IDENTITY(1215,1) PRIMARY KEY,
	Project_Name VARCHAR(20),
	Project_Description VARCHAR(50),
	Project_Client VARCHAR(20),
	Project_Start_Date DATE,
	Project_End_Date DATE
)

--SKILL TABLE
CREATE TABLE Group4.Skill
(
	Skill_Id INT IDENTITY(201,1) PRIMARY KEY,
	Skill_Name VARCHAR(20),
	Skill_Description VARCHAR(50),
	Category_Id INT,
	FOREIGN KEY (Category_Id) REFERENCES Group4.Category(Category_Id)
)

--EMPLOYEE TABLE
CREATE TABLE Group4.Employee
(
	Employee_Id INT IDENTITY(1000,1) PRIMARY KEY,
	First_Name VARCHAR(10),
	Middle_Name VARCHAR(10),
	Last_Name VARCHAR(10),
	Birth_Date DATE,
	Age INT,
	Gender VARCHAR(10),
	Civil_Status INT,
	Religion VARCHAR(20),
	Citizenship VARCHAR(20),
	Mobile_No BIGINT,
	Home_Phone_No BIGINT,
	Address_ VARCHAR(100),
	City VARCHAR(20),
	State_ VARCHAR(20),
	Pincode BIGINT,
	Country VARCHAR(20),
	Project_Id INT,
	Skill_Id INT,
	Educational_Background VARCHAR(20),
	FOREIGN KEY (Civil_Status) REFERENCES Group4.Civil_Status(Status_Id),
	FOREIGN KEY (Project_Id) REFERENCES Group4.Project(Project_Id),
	FOREIGN KEY (Skill_Id) REFERENCES Group4.Skill(Skill_Id)
)

--CAPGEMINI DETAILS TABLE
CREATE TABLE Group4.Capgemini_Details
(
	Employee_Id INT NOT NULL ,
	Email VARCHAR(50),
	Level_Id INT NOT NULL,
	Date_Hired DATE,
	Speciality INT NOT NULL,
	FOREIGN KEY(Employee_Id) REFERENCES Group4.Employee(Employee_Id),
	FOREIGN KEY(Level_Id) REFERENCES Group4.Level_(Level_Id),
	FOREIGN KEY(Speciality) REFERENCES Group4.Speciality(Speciality_Id),
)

--USERS TABLE
CREATE TABLE Group4.Users
(
	UserId INT IDENTITY(1201,1) PRIMARY KEY,
	UserName VARCHAR(20),
	Password_ VARCHAR(20),
	First_Name VARCHAR(15),
	Last_Name VARCHAR(15)
)

--ROLES TABLE
CREATE TABLE Group4.Roles
(
	Role_Id INT IDENTITY(1510,1) PRIMARY KEY,
	Role_Name VARCHAR(20)
)
SELECT * FROM Group4.Roles

--USER ROLES TABLE
CREATE TABLE Group4.User_Roles
(
	UserId INT NOT NULL,
	Role_Id INT NOT NULL,
	FOREIGN KEY(UserId) REFERENCES Group4.Users(UserId),
	FOREIGN KEY(Role_Id) REFERENCES Group4.Roles(Role_Id)
)




select * from Group4.Users

--USER LOGIN PROCEDURES
--LOGIN VERIFICATION
CREATE PROC Group4.VerifyLogin
(
	@userName VARCHAR(20),
	@password VARCHAR(20)
)
AS
	BEGIN
		SELECT UserName,Password_ FROM Group4.Users
		WHERE  (UserName = @userName) AND (Password_ = @password)
	END




create proc Group4.usp_DisplayEmployeeDetails
as
Begin
select e.First_Name,e.Middle_Name,e.Last_Name,e.Birth_Date,e.Age,e.Gender,
	   c.Status_Description,e.Religion,e.Citizenship,e.Mobile_No,e.Home_Phone_No,
	   e.Address_,e.City,e.State_,e.Pincode,e.Country,p.Project_Name,s.Skill_Name,
	   e.Educational_Background,cd.Email,lv.Level_Description,cd.Date_Hired,sp.Speciality_Name

from Group4.Employee e Join Group4.Civil_Status c on e.Civil_Status=c.Status_Id  
	 join Group4.Project p  on e.Project_Id=p.Project_Id 
	 join Group4.Skill s on e.Skill_Id=s.Skill_Id 
	 join Group4.Capgemini_Details cd on e.Employee_Id=cd.Employee_Id 
	 join Group4.Level_ lv on cd.Level_Id=lv.Level_Id 
	 join Group4.Speciality sp on cd.Speciality=sp.Speciality_Id 
end
GO

CREATE PROC Group4.usp_SearchEmployeeDetails
(
	@Employee_Id		INT
)
AS
BEGIN
SELECT e.First_Name,e.Middle_Name,e.Last_Name,e.Birth_Date,e.Age,e.Gender,
	   c.Status_Description,e.Religion,e.Citizenship,e.Mobile_No,e.Home_Phone_No,
	   e.Address_,e.City,e.State_,e.Pincode,e.Country,p.Project_Name,s.Skill_Name,
	   e.Educational_Background,cd.Email,lv.Level_Description,cd.Date_Hired,sp.Speciality_Name

FROM Group4.Employee e Join Group4.Civil_Status c on e.Civil_Status=c.Status_Id  
	 join Group4.Project p  on e.Project_Id=p.Project_Id 
	 join Group4.Skill s on e.Skill_Id=s.Skill_Id 
	 join Group4.Capgemini_Details cd on e.Employee_Id=cd.Employee_Id 
	 join Group4.Level_ lv on cd.Level_Id=lv.Level_Id 
	 join Group4.Speciality sp on cd.Speciality=sp.Speciality_Id
WHERE e.Employee_Id = @Employee_Id
END
GO
SELECT * FROM Group4.Employee

EXEC Group4.usp_SearchEmployeeDetails 1000


--UPDATE EMPLOYEE DETAILS
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
	SET Email = @Email,
		Level_Id=@Level_Id,
		Date_Hired=@Date_Hired,
		Speciality=@Speciality
END
GO