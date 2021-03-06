@echo off

if "%~1"=="" (
	echo -----------------------------------------------------
	echo Invalid parameter!
	echo -----------------------------------------------------
	echo Usage: ExtractTextByColumns.bat file_name
	echo Example: ExtractTextByColumns.bat "columns.pdf"
	echo -----------------------------------------------------
	if not "%NOPAUSE%"=="1" pause
	exit /b 1
)

powershell -NoProfile -ExecutionPolicy Bypass -Command "& .\ExtractTextByColumns.ps1" "%1"
echo Script finished with errorlevel=%errorlevel%

pause