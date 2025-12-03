@ECHO OFF
color 0E
:start
mode con cols=87 lines=28 >nul
cls
setlocal enabledelayedexpansion

:main_menu
cls
ECHO.
ECHO   ===================================================================
ECHO       			F1 SEASONS 1996-1997
ECHO   ===================================================================
ECHO. 
ECHO   === Main Menu ===================
ECHO. 
ECHO  	1) F1 Season 1997
ECHO  	2) Fictional Scenarios
ECHO. 
ECHO 	x) Exit
ECHO. 
ECHO   =================================
ECHO. 
set /p choice=-  Select an option and press ENTER: 

if "%choice%"=="1"  (
echo You chose F1 Season 1997  
goto 1997
)
if "%choice%"=="2"  (
echo You chose the fictional scenarios 
goto FICT
)
if "%choice%"=="x" exit

:1997
mode con cols=87 lines=35 >nul
cls
ECHO.
ECHO   ===================================================================
ECHO   			F1 CHAMPIONSHIP SEASON 1997    
ECHO   ===================================================================
ECHO.
ECHO   1) 1997 Australian Grand Prix		Melbourne
ECHO   2) 1997 Brazilian Grand Prix		Interlagos
ECHO   3) 1997 Argentinian Grand Prix	Buenos Aires
ECHO   4) 1997 San Marino Grand Prix  	Imola
ECHO   5) 1997 Monaco Grand Prix  		Monaco
ECHO   6) 1997 Spanish Grand Prix		Barcelona
ECHO   7) 1997 Canadian Grand Prix		Montreal
ECHO   8) 1997 French Grand Prix		Magny-Cours
ECHO   9) 1997 British Grand Prix  		Silverstone
ECHO   10) 1997 German Grand Prix  		Hockenheim
ECHO   11) 1997 Hungarian Grand Prix		Hungaroring
ECHO   12) 1997 Belgian Grand Prix  		Spa-Francorchamps
ECHO   13) 1997 Italian Grand Prix  		Monza
ECHO   14) 1997 Austrian Grand Prix  	A1Ring
ECHO   15) 1997 Luxembourg Grand Prix	Nurburgring
ECHO   16) 1997 Japanese Grand Prix 		Suzuka
ECHO   17) 1997 European Grand Prix		Jerez
ECHO.
ECHO   x. previous page
ECHO   ===================================================================================	
ECHO.
set /p choice=-  Select an option and press ENTER: 
if "%choice%"=="1" goto 1997_Melbourne
if "%choice%"=="2" goto 1997_Interlagos
if "%choice%"=="3" goto 1997_BuenosAires
if "%choice%"=="4" goto 1997_Imola
if "%choice%"=="5" goto 1997_Monaco
if "%choice%"=="6" goto 1997_Barcelona
if "%choice%"=="7" goto 1997_Montreal
if "%choice%"=="8" goto 1997_Magny-Cours
if "%choice%"=="9" goto 1997_Silverstone
if "%choice%"=="10" goto 1997_Hockenheim
if "%choice%"=="11" goto 1997_Hungaroring
if "%choice%"=="12" goto 1997_Spa-Francorchamps
if "%choice%"=="13" goto 1997_Monza
if "%choice%"=="14" goto 1997_A1Ring
if "%choice%"=="15" goto 1997_Nurburgring
if "%choice%"=="16" goto 1997_Suzuka
if "%choice%"=="17" goto 1997_Jerez
if "%choice%"=="x" goto main_menu
ECHO "%choice%" is not valid, try again

:1997_Melbourne
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 AUSTRALIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 23 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		O. Panis	(IN) 		J. Trulli			(OUT)
ECHO   Sauber #17 : 		N. Larini	(IN)		G. Morbidelli and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	J. Trulli	(IN)		T. Marques 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(IN)
ECHO   Lola #25 : 	R. Rosset	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Early season "Prince" livery
ECHO   Stewart : 	Early season livery
ECHO.
ECHO   =============================================================================================	
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_01Australia.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_97_Lola.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 01 - Melbourne" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Melbourne

:1997_Interlagos
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 BRAZILIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		O. Panis	(IN) 		J. Trulli			(OUT)
ECHO   Sauber #17 : 		N. Larini	(IN)		G. Morbidelli and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	J. Trulli	(IN)		T. Marques 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Early season "Prince" livery
ECHO   Stewart : 	Early season livery
ECHO.
ECHO   =============================================================================================	
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_01Australia.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 02 - Interlagos" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Interlagos

:1997_BuenosAires
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 ARGENTINIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		O. Panis	(IN) 		J. Trulli			(OUT)
ECHO   Sauber #17 : 		N. Larini	(IN)		G. Morbidelli and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	J. Trulli	(IN)		T. Marques 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Early season "Prince" livery
ECHO   Stewart : 	Early season livery
ECHO.
ECHO   =============================================================================================		
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_02Argentina.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 03 - Buenos Aires" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_BuenosAires

:1997_Imola
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 SAN MARINO GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		O. Panis	(IN) 		J. Trulli			(OUT)
ECHO   Sauber #17 : 		N. Larini	(IN)		G. Morbidelli and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	J. Trulli	(IN)		T. Marques 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Early season "Prince" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================	
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_03SanMarino.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 04 - Imola" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Imola

:1997_Monaco
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 MONACO GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		O. Panis	(IN) 		J. Trulli			(OUT)
ECHO   Sauber #17 : 		N. Larini	(IN)		G. Morbidelli and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	J. Trulli	(IN)		T. Marques 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Early season "Prince" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_03SanMarino.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 05 - Monaco" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Monaco

:1997_Barcelona
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 SPANISH GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		O. Panis	(IN) 		J. Trulli			(OUT)
ECHO   Sauber #17 : 		G. Morbidelli	(IN)		N. Larini and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	J. Trulli	(IN)		T. Marques 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Early season "Prince" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_04Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 06 - Barcelona" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Barcelona

:1997_Montreal
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 CANADIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	A. Wurz		(IN) 		G. Berger			(OUT)
ECHO   Prost #14 : 		O. Panis	(IN) 		J. Trulli			(OUT)
ECHO   Sauber #17 : 		G. Morbidelli	(IN)		N. Larini and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	J. Trulli	(IN)		T. Marques 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Early season "Prince" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================	
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_05Canada.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 07 - Montreal" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Montreal

:1997_Magny-Cours
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 FRENCH GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	A. Wurz		(IN) 		G. Berger			(OUT)
ECHO   Prost #14 : 		J. Trulli	(IN) 		O. Panis			(OUT)
ECHO   Sauber #17 : 		N. Fontana	(IN)		N. Larini and G. Morbidelli 	(OUT)
ECHO   Minardi #21 : 	T. Marques	(IN)		J. Trulli 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Arrows : 	No Tobacco livery
ECHO   Williams : 	France 'No tobacco' livery
ECHO   Ferrari : 	France 'No tobacco' livery
ECHO   McLaren : 	No Tobacco livery
ECHO   Jordan : 	France 'No tobacco' livery
ECHO   Prost : 		France 'No tobacco' livery
ECHO   Minardi : 	France 'No tobacco' livery
ECHO   Benetton : 	France 'No tobacco' livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================	
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997_NT.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_06France.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 08 - Magny-Cours" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Magny-Cours

:1997_Silverstone
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 BRITISH GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	A. Wurz		(IN) 		G. Berger			(OUT)
ECHO   Prost #14 : 		J. Trulli	(IN) 		O. Panis			(OUT)
ECHO   Sauber #17 : 		N. Fontana	(IN)		N. Larini and G. Morbidelli 	(OUT)
ECHO   Minardi #21 : 	T. Marques	(IN)		J. Trulli 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Arrows : 	No Tobacco livery
ECHO   Williams : 	No Tobacco livery
ECHO   Ferrari : 	No Tobacco livery
ECHO   McLaren : 	No Tobacco livery
ECHO   Jordan : 	No Tobacco livery
ECHO   Prost : 		No Tobacco livery
ECHO   Tyrrell : 	Britain 'Xena' livery
ECHO   Minardi : 	No Tobacco livery
ECHO   Benetton : 	No Tobacco livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================		
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997_NT.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_07Britain.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 09 - Silverstone" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Silverstone

:1997_Hockenheim
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 GERMAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		J. Trulli	(IN) 		O. Panis			(OUT)
ECHO   Sauber #17 : 		N. Fontana	(IN)		N. Larini and G. Morbidelli 	(OUT)
ECHO   Minardi #21 : 	T. Marques	(IN)		J. Trulli 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Arrows : 	No Tobacco livery
ECHO   Williams : 	No Tobacco livery
ECHO   Ferrari : 	No Tobacco livery
ECHO   McLaren : 	No Tobacco livery
ECHO   Jordan : 	No Tobacco livery
ECHO   Prost : 		No Tobacco livery
ECHO   Minardi : 	No Tobacco livery
ECHO   Benetton : 	No Tobacco livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997_NT.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_08Germany.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 10 - Hockenheim" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Hockenheim

:1997_Hungaroring
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 HUNGARIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		J. Trulli	(IN) 		O. Panis			(OUT)
ECHO   Sauber #17 : 		G. Morbidelli	(IN)		N. Larini and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	T. Marques	(IN)		J. Trulli 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Late season "FedEx" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_09Hungary.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 11 - Hungaroring" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Hungaroring

:1997_Spa-Francorchamps
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 BELGIUM GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		J. Trulli	(IN) 		O. Panis			(OUT)
ECHO   Sauber #17 : 		G. Morbidelli	(IN)		N. Larini and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	T. Marques	(IN)		J. Trulli 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Late season "FedEx" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_09Hungary.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 12 - Spa-Francorchamps" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Spa-Francorchamps

:1997_Monza
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 ITALIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		J. Trulli	(IN) 		O. Panis			(OUT)
ECHO   Sauber #17 : 		G. Morbidelli	(IN)		N. Larini and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	T. Marques	(IN)		J. Trulli 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Late season "FedEx" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_09Hungary.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 13 - Monza" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Monza

:1997_A1Ring
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 AUSTRIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		J. Trulli	(IN) 		O. Panis			(OUT)
ECHO   Sauber #17 : 		G. Morbidelli	(IN)		N. Larini and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	T. Marques	(IN)		J. Trulli 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Late season "FedEx" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_09Hungary.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 14 - Estoril" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Estoril

:1997_Nurburgring
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 LUXEMBOURG GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		O. Panis	(IN) 		J. Trulli			(OUT)
ECHO   Sauber #17 : 		G. Morbidelli	(IN)		N. Larini and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	T. Marques	(IN)		J. Trulli 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Late season "FedEx" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================	
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_10Luxembourg.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 15 - Nurburgring" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Nurburgring

:1997_Suzuka
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 JAPANESE GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		O. Panis	(IN) 		J. Trulli			(OUT)
ECHO   Sauber #17 : 		G. Morbidelli	(IN)		N. Larini and N. Fontana 	(OUT)
ECHO   Minardi #21 : 	T. Marques	(IN)		J. Trulli 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Late season "FedEx" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================		
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_10Luxembourg.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml	
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 16 - Suzuka" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Suzuka

:1997_Jerez
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1997 EUROPEAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Benetton #8 : 	G. Berger	(IN) 		A. Wurz				(OUT)
ECHO   Prost #14 : 		O. Panis	(IN) 		J. Trulli			(OUT)
ECHO   Sauber #17 : 		N. Fontana	(IN)		N. Larini and G. Morbidelli 	(OUT)
ECHO   Minardi #21 : 	T. Marques	(IN)		J. Trulli 			(OUT)
ECHO   Lola #24 : 	V. Sospiri	(OUT)
ECHO   Lola #25 : 	R. Rosset	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Benetton: 	Late season "FedEx" livery
ECHO   Stewart : 	Late season livery
ECHO.
ECHO   =============================================================================================		
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_11Europe.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml	
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "Round 17 - Jerez" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1997 menu...
    goto :1997
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Jerez

:FICT
mode con cols=87 lines=25 >nul
cls
ECHO.
ECHO   ===================================================================
ECHO   		FICTIONAL F1 SEASONS '96-'97 SCENARIOS    
ECHO   ===================================================================
ECHO.
ECHO   1997 Scenarios:
ECHO   1) What if Hill remains at Williams?
ECHO   2) What if Senna survived Imola 1994? - Season 1997
ECHO   3) What if Pacific and Simtek merged into Lotus? - Season 1997
ECHO   4) What if Mansell joined Jordan?
ECHO.
ECHO   x. previous page
ECHO   ===================================================================================	
ECHO.
set /p choice=-  Select an option and press ENTER: 
if "%choice%"=="1" goto 1997_Hill
if "%choice%"=="2" goto 1997_Senna
if "%choice%"=="3" goto 1997_Lotus
if "%choice%"=="4" goto 1997_Mansell
if "%choice%"=="x" goto main_menu
ECHO "%choice%" is not valid, try again

:1997_Hill
mode con cols=104 lines=45 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO               F1 Season 1997 what if... Damon Hill remains at Williams
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   =============================================================================================
ECHO.
ECHO   Frank Williams infamously signed Heinz-Harald Frentzen to replace Damon Hill
ECHO   right as the Englishman won the World Championship for his team. That decision
ECHO   was taken after Hill went through a less than ideal 1995 season.
ECHO.   
ECHO   So, what if Damon Hill's 1995 season had been just a bit better, just enough
ECHO   to convince Frank Williams to wait until 1996 to make his decision on Hill's
ECHO   future in the team? By winning the 1996 championship, his future with
ECHO   Frank Williams' team is assured and Hill gets to defend his championship at Williams.
ECHO.   
ECHO   With Hill remaining at Williams, Frentzen also keeps his old seat at Sauber.
ECHO   This leaves the Arrows seat free, which is taken by Martin Brundle for the
ECHO   swan song of his career.
ECHO.   
ECHO   Can you give Damon Hill a second championship? Or do you want to defeat him
ECHO   as another driver?
ECHO.
ECHO   =============================================================================================	
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_HillWilliams.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "What if Damon Hill remained at Williams?" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to the Fictional Scenarios menu
    goto :FICT
)
:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Hill

:1997_Senna
mode con cols=104 lines=45 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO               F1 Season 1997 what if... Senna survived the 1994 San Marino GP
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   =============================================================================================
ECHO.
ECHO   Sequel to the 1996 version of this scenario.
ECHO.
ECHO   After three years at Williams, one of which was spent recovering from a terrible
ECHO   accident at the tragic 1994 San Marino Grand Prix, Ayrton Senna is ready to try
ECHO   something new. 1997 sees three new teams join the grid: Stewart, Lola, and Prost.
ECHO   The latter is ran by Senna's former rival and now friend Alain Prost.
ECHO.   
ECHO   Knowing he is nearing the end of his career, Senna shocks the Formula One paddock by
ECHO   joining Prost Grand Prix for 1997. His goal is simple: help his good friend Alain
ECHO   build up his team by bringing in his expertise and reputation to the new French outfit.
ECHO   It also helps that the former Equipe Ligier has been showing more and more potential
ECHO   in the last few years, and look ready to fight for wins. A driver of Senna's calibre
ECHO   could be enough to give it the last kick it needs to fight for the championship.
ECHO.   
ECHO   Will Senna's decision turns out beneficial for either party? Or will a bad season
ECHO   hurt the friendship between the former rivals?
ECHO.
ECHO   =============================================================================================	
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_Senna.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "What if Senna survives the 1994 San Marino GP?" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to the Fictional Scenarios menu
    goto :FICT
)
:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Senna

:1997_Lotus
mode con cols=104 lines=45 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO               F1 Season 1997 what if... Pacific and Simtek merged and reformed Lotus
ECHO   =============================================================================================
ECHO.
ECHO   Select 23 AI opponents
ECHO.
ECHO   =============================================================================================
ECHO.
ECHO   Sequel to the 1996 version of this scenario.
ECHO.
ECHO   At the end of the 1995 season, the former Pacific and Simtek teams merged to form
ECHO   the second incarnation of Team Lotus in an attempt to survive to the 1996 season.
ECHO   The gamble worked. Though nothing impressive took place, the 1996 season was relatively
ECHO   smooth sailing for Lotus.
ECHO.   
ECHO   However, a major sponsor pulled their support out after the 1996 season, while others
ECHO   reduced their involvement. Unless the team produces good, impressive performances for
ECHO   the 1997 season, it is unlikely they will survive to see the new regulations in 1998.
ECHO.   
ECHO   With Bertrand Gachot and Hideki Noda keeping their seats, can Lotus pull through
ECHO   and ensure their survival for the 1998 season?
ECHO.
ECHO   =============================================================================================	
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997_Lotus.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_11Europe.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_97_Lotus.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "What if Pacific and Simtek merged into Lotus?" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to the Fictional Scenarios menu
    goto :FICT
)
:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Lotus

:1997_Mansell
mode con cols=104 lines=45 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO               F1 Season 1997 what if... Nigel Mansell joined Jordan Grand Prix
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   =============================================================================================
ECHO.
ECHO   In December 1996, Nigel Mansell tested with the Jordan team. It was rumoured at
ECHO   the time that Mansell was considering a Formula One comeback with the Irish team.
ECHO   The last time the 1992 World Champion raced in Formula One was with the McLaren
ECHO   team in 1995 in what turned out to be a disastrous partnership. Did Mansell really
ECHO   believe it would be different with the Jordan team?
ECHO.   
ECHO   As it turns out, the test was never serious. It was a mere publicity stunt.
ECHO   But, what if it was serious?
ECHO.  
ECHO   After his 1996 test, Nigel Mansell is sufficiently impressed by the Jordan team
ECHO   to offer his services. Eddie Jordan signs the former World Champion on the spot.
ECHO   For 1997, Nigel Mansell will be leading Jordan Grand Prix into its next era:
ECHO   The era of snakes, hornets and sharks.
ECHO.   
ECHO   Can Nigel Mansell repair his reputation after his disastrous stint at McLaren?
ECHO   Or will his time as Jordan prove to be nothing different?
ECHO.
ECHO   =============================================================================================	
ECHO.
echo Do you want to install this scenario ?
echo (Y) YES
echo (N) NO
echo.
set /p confirm=Your choice: 

if /I "%confirm%"=="Y" (
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1997.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1997_Mansell.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1997 Season "What if Nigel Mansell joined Jordan?" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to the Fictional Scenarios menu
    goto :FICT
)
:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1997_Mansell

:end
pause