@echo off

call %~dp0\..\batcs.bat sample\sample.cs aaa bbb ccccccccc

exit /b %errorlevel%
