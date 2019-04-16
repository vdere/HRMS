USE [Sep19CHN]
GO

/****** Object:  StoredProcedure [Group4].[usp_DisplayEmployeeDetails]    Script Date: 10/27/2018 9:58:33 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER proc [Group4].[usp_DisplayEmployeeDetails]
as
Begin
select e.Employee_Id AS 'Employee ID',e.First_Name AS 'First Name',e.Middle_Name AS 'Middle Name',e.Last_Name AS 'Last Name',e.Birth_Date AS 'Birth Date',e.Age,e.Gender,
	   c.Status_Description AS 'Status Description',e.Religion,e.Citizenship,e.Mobile_No,e.Home_Phone_No AS 'Home Number',
	   e.Address_ AS 'Address',e.City,e.State_ as 'State',e.Pincode,e.Country,p.Project_Name AS 'Project Name',s.Skill_Name,
	   e.Educational_Background AS 'Educational Background',cd.Email,lv.Level_Description as 'Level Description',cd.Date_Hired AS 'Date Hired',sp.Speciality_Name

from Group4.Employee e Join Group4.Civil_Status c on e.Civil_Status=c.Status_Id  
	 join Group4.Project p  on e.Project_Id=p.Project_Id 
	 join Group4.Skill s on e.Skill_Id=s.Skill_Id 
	 join Group4.Capgemini_Details cd on e.Employee_Id=cd.Employee_Id 
	 join Group4.Level_ lv on cd.Level_Id=lv.Level_Id 
	 join Group4.Speciality sp on cd.Speciality=sp.Speciality_Id 
end
GO
exec [Group4].[usp_DisplayEmployeeDetails]

Truncate table Group4.Employee
select * from Group4.Employee
select * from Group4.Capgemini_Details
delete from Group4.Capgemini_Details where Group4.Capgemini_Details.Employee_Id=1003
delete from Group4.Employee where Group4.Employee.Employee_Id=1000

ALTER PROC Group4.usp_SearchEmployeeDetails
(
	@Employee_Id		INT
)
AS
BEGIN
select e.Employee_Id,e.First_Name,e.Middle_Name,e.Last_Name,e.Birth_Date,e.Age,e.Gender,e.Civil_Status,e.Project_Id,e.Skill_Id,
	   c.Status_Description,e.Religion,e.Citizenship,e.Mobile_No,e.Home_Phone_No,
	   e.Address_,e.City,e.State_,e.Pincode,e.Country,p.Project_Name,s.Skill_Name,
	   e.Educational_Background,cd.Email,lv.Level_Id,lv.Level_Description,cd.Date_Hired,sp.Speciality_Id,sp.Speciality_Name

from Group4.Employee e 
	 Join Group4.Civil_Status c on e.Civil_Status=c.Status_Id  
	 join Group4.Project p  on e.Project_Id=p.Project_Id 
	 join Group4.Skill s on e.Skill_Id=s.Skill_Id 
	 join Group4.Capgemini_Details cd on e.Employee_Id=cd.Employee_Id 
	 join Group4.Level_ lv on cd.Level_Id=lv.Level_Id 
	 join Group4.Speciality sp on cd.Speciality=sp.Speciality_Id 
	 WHERE e.Employee_Id = @Employee_Id
END
GO
SELECT * FROM Group4.Employee

EXEC Group4.usp_SearchEmployeeDetails 1008


--UPDATE EMPLOYEE DETAILS
ALTER PROC Group4.usp_UpdateEmployee
(
	@Employee_Id	INT,
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
	WHERE Employee_Id = @Employee_Id
END
GO


--LOAD USER ROLE TABLE
CREATE PROC Group4.usp_DisplayUserRole
AS
BEGIN
SELECT * FROM Group4.Roles
END

--LOAD CIVILSTATUS TABLE
CREATE PROC Group4.usp_LoadCivilStatus
AS
BEGIN
SELECT * FROM Group4.Civil_Status
END

--LOAD PROJECT NAMES
CREATE PROC Group4.usp_LoadProjectNames
AS
BEGIN
SELECT * FROM Group4.Project
END

--LOAD SKILLS 
CREATE PROC Group4.usp_LoadSkills
AS
BEGIN
SELECT * FROM Group4.Skill
END

--LOAD LEVELS 
CREATE PROC Group4.usp_LoadLevels
AS
BEGIN
SELECT * FROM Group4.Level_
END

--LOAD SPECIALITY 
CREATE PROC Group4.usp_LoadSpeciality
AS
BEGIN
SELECT * FROM Group4.Speciality
END