@echo off
REM Navigate to this script's folder
cd /d "%~dp0"

REM Ensure Logs folder exists
if not exist "Logs" mkdir "Logs"

REM Enable delayed expansion for variables
setlocal enabledelayedexpansion

REM Create a timestamped log filename (YYYY-MM-DD_HH-MM-SS)
for /f "tokens=1-6 delims=/:. " %%a in ("%date% %time%") do (
    set "yyyy=%%c"
    set "mm=%%a"
    set "dd=%%b"
    set "hh=%%d"
    set "min=%%e"
    set "ss=%%f"
)
set "timestamp=!yyyy!-!mm!-!dd!_!hh!-!min!-!ss!"
set "logfile=Logs\MemoryLeakAudit_!timestamp!.txt"

REM Run the audit using dotnet and redirect output to the log file
dotnet run > "!logfile!" 2>&1

REM Show output in the console
type "!logfile!"

REM Notify user where the logs are
echo.
echo Memory leak audit completed. Logs saved to "!logfile!".

endlocal
