@echo off

if "%1"=="" (
    echo ".csファイルを引数で渡してください"
    exit 1
)
set CS_PATH=%CD%\%1

pushd %~dp0

copy /b head.txt + %CS_PATH% + tail.txt temp.bat > nul
call temp.bat %*
set ERROR_CODE=%errorlevel%
del temp.bat

popd 

exit /b %ERROR_CODE%
