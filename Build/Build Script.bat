@echo off
call "%vs90comntools%..\..\VC\vcvarsall.bat" x86 || goto EnvironmentError
rem Check for missing files
dir | find "ILmerge.exe" /I > nul || goto ILMergeError
echo Cleaning output...
devenv ..\LCARSmain\LCARSmain.sln /Clean > nul && echo Main project cleaned
devenv "..\Standard Installer\Standard Installer.sln" /Clean > nul && echo Installer cleaned
rmdir /S /Q Out > nul
mkdir .\Out
echo Clean complete.
echo Compiling project...
devenv ..\LCARSmain\LCARSmain.sln /Build "Release|AnyCPU" > nul || goto CompileError
echo Main project compile succeeded.
echo Compressing output...
zipit.exe .\Out\CurrentVersion.zip -D ..\LCARSmain\LCARSmain\bin\Debug -r+ -j- -E *.* > nul && echo Compression complete.
echo Moving files...
xcopy /Y .\Out\CurrentVersion.zip "..\Standard Installer\Standard Installer\Resources\" > nul
echo Compiling installer...
devenv "..\Standard Installer\Standard Installer.sln" /Build "Release|AnyCPU" > nul || goto CompileError
echo Compile Complete.
echo Linking files
ilmerge /lib:"..\Standard Installer\Standard Installer\bin\release" "Standard Installer.exe"  Ionic.zip.reduced.dll Interop.IWshRuntimeLibrary.dll  /target:winexe  /out:.\Out\LCARSx32Installer.exe
echo Build is complete.
echo Rename output files to include version number.
goto End
:CompileError
echo Compile failed. Build will terminate.
goto End
:ILMergeError
echo ILMerge was not found. Please download and copy ILMerge.exe to this directory.
goto End
:EnvironmentError
echo Could not initialize environment
:End
pause