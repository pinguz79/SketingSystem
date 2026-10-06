@echo off
set LOCALDB=%LOCALAPPDATA%\SketingSystem.db
echo Installing database...
copy /Y "%~dp0SketingSystem.db" "%LOCALDB%"
echo Done.
pause
