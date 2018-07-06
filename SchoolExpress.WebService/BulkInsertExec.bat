@echo off
sqlcmd -S (LocalDb)\MSSQLLocalDB -d SchoolExpressDb -E -i "Scripts\MsSql\CleanTables.sql"
sqlcmd -S (LocalDb)\MSSQLLocalDB -d SchoolExpressDb -E -i "Scripts\MsSql\ResetIdentities.sql"
set sources[0]=Campus
set sources[1]=ClassRoom
set sources[2]=Course
set sources[3]=Degree
set sources[4]=Career
set sources[5]=CareerDetail
set sources[6]=Module
set sources[7]=Period
set sources[8]=Person
set sources[9]=Speaker
set sources[10]=Student
set sources[11]=CareerSchedule
set sources[12]=CareerScheduleDetail
set sources[13]=Enrollment
set sources[14]=EnrollmentDetail
::set files=%CD%\DataSources\*.csv
::for %%i in (%files%) do sqlcmd -S (LocalDb)\MSSQLLocalDB -d SchoolExpressDb -E -v filepath="%%i" tablename="%%~ni" -i "Scripts\MsSql\BulkInsert.sql"
::for /F "tokens=2 delims==" %%s in ('set sources[') do echo %%s
::sqlcmd -S (LocalDb)\MSSQLLocalDB -d SchoolExpressDb -E -v filepath="%CD%\DataSources\%%s.csv" tablename="%%s" -i "Scripts\MsSql\BulkInsert.sql"

set "x=0" 
:SymLoop 
if defined sources[%x%] ( 
   call set name=%%sources[%x%]%%
   call set file=%CD%\DataSources\%%name%%.csv
   call sqlcmd -S "(LocalDb)\MSSQLLocalDB" -d SchoolExpressDb -E -u -W -v filepath="%%file%%" tablename="%%name%%" -i Scripts\MsSql\BulkInsert.sql
   set /a "x+=1"
   GOTO :SymLoop 
)

