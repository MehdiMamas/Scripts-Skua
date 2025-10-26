@echo off
REM Regular Update Checker for Upstream Repository (Windows)
REM Tracks upstream/Skua branch

cd /d "C:\Users\mehdi\OneDrive\Documents\Skua\Scripts"

echo ============================================
echo   Checking for Upstream Updates
echo ============================================
echo.

REM Fetch latest from upstream
echo Fetching from upstream Skua branch...
git fetch upstream

echo.
echo ============================================
echo   Current Status
echo ============================================
echo.

REM Show current branch
echo Current branch:
git branch --show-current

REM Check if there are updates
echo.
echo Checking for new commits...
git rev-list HEAD..upstream/Skua >nul 2>&1

if %ERRORLEVEL% EQU 0 (
    for /f %%i in ('git rev-list --count HEAD..upstream/Skua') do set COUNT=%%i
) else (
    set COUNT=0
)

if %COUNT% EQU 0 (
    echo ================================
    echo   Your fork is up-to-date!
    echo   No new commits from upstream.
    echo ================================
) else (
    echo ================================
    echo   NEW UPDATES AVAILABLE!
    echo ================================
    echo.
    echo New commits from upstream Skua branch:
    echo -------------------------------------------
    git log HEAD..upstream/Skua --oneline -10
    echo -------------------------------------------
    echo.
    echo Total new commits: %COUNT%
    echo.
    echo.
    FOR /F %%i IN ('git diff --name-only HEAD..upstream/Skua ^| find /c /v ""') DO SET FILECOUNT=%%i
    echo Files that will be affected: %FILECOUNT:~-5% files total
    echo.
    echo First 20 files:
    echo -------------------------------------------
    git diff --name-only HEAD..upstream/Skua > temp_files.txt
    head -20 temp_files.txt 2>nul || more /E +0 temp_files.txt | findstr /N "^" | findstr /B "1: 2: 3: 4: 5: 6: 7: 8: 9: 10: 11: 12: 13: 14: 15: 16: 17: 18: 19: 20:"
    del temp_files.txt 2>nul
    echo -------------------------------------------
    echo    (Too many to list all - %FILECOUNT:~-5% files total)
    echo.
    echo IMPORTANT: Check if your custom files are affected:
    git diff --name-only HEAD..upstream/Skua | findstr /C:"CoreBots.cs" >nul
    if %ERRORLEVEL% EQU 0 (
        echo    WARNING: CoreBots.cs will be updated ^(you have custom changes!^)
    )
    git diff --name-only HEAD..upstream/Skua | findstr /C:"CoreStory.cs" >nul
    if %ERRORLEVEL% EQU 0 (
        echo    WARNING: CoreStory.cs will be updated ^(you have custom changes!^)
    )
    echo.
    echo To update, run:
    echo    git merge upstream/Skua
    echo.
    echo Or use the safe update script:
    echo    safe-update.bat
)

echo.
echo ============================================
echo   Your Last Commit
echo ============================================
echo.
git log -1 --oneline

echo.
echo ============================================
echo Done! Check completed.
echo ============================================
pause

