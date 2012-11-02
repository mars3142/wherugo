for /f %%a IN ('dir /b *.txt') do (
"c:\Program Files\Microsoft.NET\SDK\v2.0 64bit\Bin\ResGen.exe" %%a
)
