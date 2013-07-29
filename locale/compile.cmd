for /f %%a IN ('dir /b *.txt') do (
"c:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\ResGen.exe" %%a
)
