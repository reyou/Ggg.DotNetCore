use SerilogLogs
select * from Log 
where 1=1
order by id desc
return
--=============================================================================
Truncate table [Log]
DBCC SHRINKDATABASE(N'SerilogLogs')
return