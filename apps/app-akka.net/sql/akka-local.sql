use SerilogLogs
select * from Log 
where 1=1
and message like '%Recorded temperature%'
order by id desc
return
--=============================================================================
Truncate table [Log]
DBCC SHRINKDATABASE(N'SerilogLogs')
return