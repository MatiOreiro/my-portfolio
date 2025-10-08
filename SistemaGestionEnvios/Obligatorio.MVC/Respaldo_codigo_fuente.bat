@echo off
setlocal enabledelayedexpansion
set "raiz=%~dp0"
set "destino=%raiz%CodigoFuente"
set "zipfile=%raiz%CodigoFuente.zip"

if not exist "%destino%" mkdir "%destino%"

for /r %%F in (*.cs *.cshtml *.js *.css) do (
    set "nombre=%%~nxF"
    set "nombreL=%%~nxF"
    call set "nombreL=%%nombreL:~0,7%%"
    
    rem Excluir archivos que comienzan con jquery o bootstrap
    if /i not "!nombreL!"=="jquery." if /i not "!nombreL!"=="bootstr" (
        set "salida=%destino%\!nombre!.txt"
        type "%%F" > "!salida!"
    )
)

powershell -Command "Compress-Archive -Path '%destino%\*' -DestinationPath '%zipfile%' -Force"
rmdir /s /q "%destino%"
echo Carpeta comprimida como CodigoFuente.zip
echo Carpeta temporal eliminada.
echo Listo.
pause
