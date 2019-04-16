    ---/// <summary>
    ---/// Employee ID :161585
    ---/// Employee Name : Viraj Dere
    ---/// Description : Display Procedures
    ---/// Date of Creation : 10/19/2018
    ---/// </summary>


use Sep19CHN

--DISPLAY PROCEDURES
--ADMIN PROCEDURES
CREATE PROC Group4.usp_DisplayAllUsers
 AS
 BEGIN
 select * from Group4.Users
 END

 CREATE PROC Group4.usp_DisplayAllEmployees
 AS
 BEGIN
 select * from Group4.Employee
 END

 CREATE PROC Group4.usp_DisplayAllProjects
 AS
 BEGIN
 select * from Group4.Project
 END

 CREATE PROC Group4.usp_DisplayAllCategories
 AS
 BEGIN
 select * from Group4.Category
 END

ALTER PROC Group4.usp_DisplayAllSkills
AS
BEGIN
SELECT s.Skill_Id AS 'Skill ID',s.Skill_Name AS 'Skill Name',s.Skill_Description AS 'Skill Description',
	   c.Category_Name AS 'Category Name' 
FROM   Group4.Skill s
	 JOIN Group4.Category c ON s.Category_Id = c.Category_Id
END

 CREATE PROC Group4.usp_DisplayAllCivilStatus
 AS
 BEGIN
 select * from Group4.Civil_Status
 END

 CREATE PROC Group4.usp_DisplayAllLevels
 AS
 BEGIN
 select * from Group4.Level_
 END

 CREATE PROC Group4.usp_DisplayAllSpec
 AS
 BEGIN
 select * from Group4.Speciality
 END

