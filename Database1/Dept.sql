﻿CREATE TABLE [dbo].[Dept]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Code] NVARCHAR(10) NOT NULL, 
    [DeptLevelId] UNIQUEIDENTIFIER NOT NULL, 
    [ParentId] UNIQUEIDENTIFIER NULL
)
