CREATE TABLE [dbo].[Employee]
(
	[id] INT NOT NULL PRIMARY KEY, 
    [fullName] NVARCHAR(500) NOT NULL, 
    [initiationDate] DATE NOT NULL, 
    [fk_hiredfor] INT NOT NULL, 
    [email] NVARCHAR(250) NOT NULL, 
    [cellphone] NVARCHAR(50) NOT NULL, 
    [startDate] DATE NOT NULL, 
    [service_equipmentneeded] NVARCHAR(MAX) NOT NULL, 
    [aditional_service] NVARCHAR(500) NULL, 
    [fk_companylist] INT NULL, 
    [another_company] NVARCHAR(250) NULL, 
    [aditional_info] NVARCHAR(500) NULL, 
    [building_access] INT NOT NULL, 
    [another_building] NVARCHAR(500) NULL, 
    [restricted_access] NVARCHAR(500) NULL, 
    [hiringManagerEmail] NVARCHAR(250) NOT NULL
)
