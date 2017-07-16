USE [ChessAtomicCrawlingContext-20160628170124]
GO

USE [AtomicDB]
GO

select count(*)
from [dbo].[AtomicGameInfoOlds] 


select count(*)
from [dbo].[AtomicGameInfoes] 


select *
from Players

select TOP(5) *
from UpdatesInfoes


select *
from __MigrationHistory

select count(*)
from [dbo].[GameShorts] 

truncate table [dbo].[GameShorts] 


delete
from __MigrationHistory
where MigrationId = '201707131013495_AutomaticMigration'

USE [AtomicDB]
GO

ALTER TABLE [dbo].[Players]  DROP COLUMN localCount