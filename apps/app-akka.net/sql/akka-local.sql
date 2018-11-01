use SerilogLogs
select * from Log order by id desc
return
--=============================================================================
Truncate table [Log]
DBCC SHRINKDATABASE(N'SerilogLogs')
return