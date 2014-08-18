USE [master]
GO
CREATE DATABASE [SeeCommon] ON 
( FILENAME = N'C:\TEST\SeeCommon.mdf' )
 FOR ATTACH
GO
if exists (select name from master.sys.databases sd where name = N'SeeCommon' and SUSER_SNAME(sd.owner_sid) = SUSER_SNAME() ) EXEC [SeeCommon].dbo.sp_changedbowner @loginame=N'DANSDELL\Administrator', @map=false
GO
