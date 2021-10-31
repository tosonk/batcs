@echo off
setlocal enabledelayedexpansion

if "%1"=="" (
    echo ".csƒtƒ@ƒCƒ‹‚ðˆø”‚Å“n‚µ‚Ä‚­‚¾‚³‚¢"
    exit 1
)
set CS_PATH=%CD%\%1

pushd %~dp0

echo @powershell -NoProfile -ExecutionPolicy Unrestricted "$s=[scriptblock]::create((gc \"%%~f0\"|?{$_.readcount -gt 1})-join\"`n\");&$s" %%*^&goto:eof >> temp.bat
echo. >> temp.bat
echo $csArgs = $args >> temp.bat
echo $csArgs[0] = $null >> temp.bat
echo $csArgs = $csArgs -ne $null >> temp.bat
echo. >> temp.bat
echo $src = @' >> temp.bat

copy /b temp.bat + %CS_PATH% temp.bat > nul

echo. >> temp.bat

echo '@ >> temp.bat
echo. >> temp.bat
echo. >> temp.bat
echo Add-Type -TypeDefinition $src -Language CSharp -ReferencedAssemblies System.Windows.Forms >> temp.bat
echo. >> temp.bat
echo $Result = [BatCs]::Entry($csArgs) >> temp.bat
echo exit $Result >> temp.bat

call temp.bat %*
set ERROR_CODE=%errorlevel%
del temp.bat

popd 

exit /b %ERROR_CODE%
