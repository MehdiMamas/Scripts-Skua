@echo off
REM Safe Update Script - Updates from upstream Skua branch with automatic backup (Windows)

cd /d "C:\Users\mehdi\OneDrive\Documents\Skua\Scripts"

echo ============================================
echo   Safe Update from Upstream
echo ============================================
echo.

REM Save current work
echo Step 1: Saving current work...
git add .
git commit -m "Auto-save before upstream update %date% %time%" 2>nul
if %ERRORLEVEL% NEQ 0 (
    echo    ^(No changes to save^)
)

REM Create backup branch
set BACKUP_BRANCH=backup-%date:~-4%%date:~-10,2%%date:~-7,2%-%time:~0,2%%time:~3,2%%time:~6,2%
set BACKUP_BRANCH=%BACKUP_BRANCH: =0%
echo.
echo Step 2: Creating backup branch: %BACKUP_BRANCH%
git branch %BACKUP_BRANCH%
echo    Backup created! To restore: git reset --hard %BACKUP_BRANCH%

REM Fetch upstream
echo.
echo Step 3: Fetching from upstream Skua branch...
git fetch upstream

REM Check if there are updates
for /f %%i in ('git rev-list --count HEAD..upstream/Skua') do set COUNT=%%i

if %COUNT% EQU 0 (
    echo.
    echo ================================
    echo   Already up-to-date!
    echo   No updates needed.
    echo ================================
    pause
    exit /b 0
)

REM Show what will change
echo.
echo Step 4: Preview of changes:
echo -------------------------------------------
git log HEAD..upstream/Skua --oneline -5
echo -------------------------------------------

echo.
echo Files that will be modified:
git diff --name-only HEAD..upstream/Skua > temp_files.txt
FOR /F %%i IN ('find /c /v "" ^< temp_files.txt') DO SET FILECOUNT=%%i
echo    Total files changed: %FILECOUNT:~-5%
echo.
echo First 20 files:
more /E +0 temp_files.txt | findstr /N "^" | findstr /B "1: 2: 3: 4: 5: 6: 7: 8: 9: 10: 11: 12: 13: 14: 15: 16: 17: 18: 19: 20:"
del temp_files.txt
echo.
echo    (Too many to show all - %FILECOUNT:~-5% files total)

echo.
echo Checking your custom files...
set CONFLICTS=0
git diff --name-only HEAD..upstream/Skua | findstr /C:"CoreBots.cs" >nul
if %ERRORLEVEL% EQU 0 (
    echo    WARNING: CoreBots.cs will be updated ^(you have custom changes here!^)
    set CONFLICTS=1
)
git diff --name-only HEAD..upstream/Skua | findstr /C:"CoreStory.cs" >nul
if %ERRORLEVEL% EQU 0 (
    echo    WARNING: CoreStory.cs will be updated ^(you have custom changes here!^)
    set CONFLICTS=1
)

if %CONFLICTS% EQU 0 (
    echo    Your custom files are safe!
)

echo.
echo -------------------------------------------
echo Ready to merge?
echo -------------------------------------------
set /p CONTINUE="Continue with merge? (y/N): "

if /i not "%CONTINUE%"=="y" (
    echo.
    echo Update cancelled.
    echo    Backup branch %BACKUP_BRANCH% is still available.
    pause
    exit /b 0
)

REM Perform merge
echo.
echo Step 5: Merging upstream/Skua...
git merge upstream/Skua

if %ERRORLEVEL% EQU 0 (
    echo.
    echo Merge successful!
    echo.
    echo Step 6: Pushing to your fork...
    git push origin Skua
    
    echo.
    echo ============================================
    echo   Update Complete!
    echo ============================================
    echo.
    echo Your fork is now up-to-date!
    echo.
    echo IMPORTANT: Test your custom modifications:
    echo    - Cutscene skip fix ^(run story with cutscenes^)
    echo    - Multi-monster KillQuest ^(quest 7114^)
    echo.
    echo If everything works, you can delete the backup:
    echo    git branch -d %BACKUP_BRANCH%
) else (
    echo.
    echo ============================================
    echo   CONFLICTS DETECTED!
    echo ============================================
    echo.
    echo Conflicts need to be resolved manually.
    echo See FORK_WORKFLOW.md for conflict resolution guide.
    echo.
    echo To abort the merge:
    echo    git merge --abort
    echo.
    echo To restore from backup:
    echo    git reset --hard %BACKUP_BRANCH%
)

echo.
pause

