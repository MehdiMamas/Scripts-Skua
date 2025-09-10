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

echo.
echo Memory leak audit completed. Logs saved to "!logfile!".
echo.

REM Prompt to open the log file
set /p openlog=Do you want to open the log file now? (Y/N): 
if /i "!openlog!"=="Y" (
    start notepad "!logfile!"
)

endlocal
