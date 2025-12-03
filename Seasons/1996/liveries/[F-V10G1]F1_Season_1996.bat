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
ECHO  	1) F1 Season 1996
ECHO  	2) Fictional Scenarios
ECHO. 
ECHO 	x) Exit
ECHO. 
ECHO   =================================
ECHO. 
set /p choice=-  Select an option and press ENTER: 

if "%choice%"=="1"  (
echo You chose F1 Season 1996  
goto 1996
)
if "%choice%"=="2"  (
echo You chose the fictional scenarios 
goto FICT
)
if "%choice%"=="x" exit

:1996
mode con cols=87 lines=28 >nul
cls
ECHO.
ECHO   ===================================================================
ECHO   			F1 CHAMPIONSHIP SEASON 1996    
ECHO   ===================================================================
ECHO.
ECHO   1) 1996 Australian Grand Prix		Melbourne
ECHO   2) 1996 Brazilian Grand Prix		Interlagos
ECHO   3) 1996 Argentinian Grand Prix	Buenos Aires
ECHO   4) 1996 European Grand Prix		Nurburgring
ECHO   5) 1996 San Marino Grand Prix  	Imola
ECHO   6) 1996 Monaco Grand Prix  		Monaco
ECHO   7) 1996 Spanish Grand Prix		Barcelona
ECHO   8) 1996 Canadian Grand Prix		Montreal
ECHO   9) 1996 French Grand Prix		Magny-Cours
ECHO   10) 1996 British Grand Prix  		Silverstone
ECHO   11) 1996 German Grand Prix  		Hockenheim
ECHO   12) 1996 Hungarian Grand Prix		Hungaroring
ECHO   13) 1996 Belgian Grand Prix  		Spa-Francorchamps
ECHO   14) 1996 Italian Grand Prix  		Monza
ECHO   15) 1996 Portuguese Grand Prix	Estoril
ECHO   16) 1996 Japanese Grand Prix 		Suzuka
ECHO.
ECHO   x. previous page
ECHO   ===================================================================================	
ECHO.
set /p choice=-  Select an option and press ENTER: 
if "%choice%"=="1" goto 1996_Melbourne
if "%choice%"=="2" goto 1996_Interlagos
if "%choice%"=="3" goto 1996_BuenosAires
if "%choice%"=="4" goto 1996_Nurburgring
if "%choice%"=="5" goto 1996_Imola
if "%choice%"=="6" goto 1996_Monaco
if "%choice%"=="7" goto 1996_Barcelona
if "%choice%"=="8" goto 1996_Montreal
if "%choice%"=="9" goto 1996_Magny-Cours
if "%choice%"=="10" goto 1996_Silverstone
if "%choice%"=="11" goto 1996_Hockenheim
if "%choice%"=="12" goto 1996_Hungaroring
if "%choice%"=="13" goto 1996_Spa-Francorchamps
if "%choice%"=="14" goto 1996_Monza
if "%choice%"=="15" goto 1996_Estoril
if "%choice%"=="16" goto 1996_Suzuka
if "%choice%"=="x" goto main_menu
ECHO "%choice%" is not valid, try again

:1996_Melbourne
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 AUSTRALIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Fisichella	(IN) 		T. Marques and G. Lavaggi	(OUT)
ECHO   Forti #22 : 		L. Badoer	(IN)
ECHO   Forti #23 : 		A. Montermini	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Melbourne 'Power Horse' livery
ECHO   Arrows : 	Early season 'Footwork' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_01Australia.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_01Australia.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Forti.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 01 - Melbourne" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Melbourne

:1996_Interlagos
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 BRAZILIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	T. Marques	(IN) 		G. Fisichella and G. Lavaggi	(OUT)
ECHO   Forti #22 : 		L. Badoer	(IN)
ECHO   Forti #23 : 		A. Montermini	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Early season 'Footwork' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_02Brazil.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_02Brazil.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Forti.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 02 - Interlagos" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Interlagos

:1996_BuenosAires
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 ARGENTINIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	T. Marques	(IN) 		G. Fisichella and G. Lavaggi	(OUT)
ECHO   Forti #22 : 		L. Badoer	(IN)
ECHO   Forti #23 : 		A. Montermini	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Early season 'Footwork' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_02Brazil.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_02Brazil.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Forti.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 03 - Buenos Aires" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_BuenosAires

:1996_Nurburgring
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 EUROPEAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Fisichella	(IN) 		T. Marques and G. Lavaggi	(OUT)
ECHO   Forti #22 : 		L. Badoer	(IN)
ECHO   Forti #23 : 		A. Montermini	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	No tobacco livery
ECHO   Arrows : 	Early season 'Footwork' livery
ECHO   Ferrari : 	No tobacco livery
ECHO   Benetton : 	No tobacco livery
ECHO   Williams : 	No tobacco livery
ECHO   McLaren : 	No tobacco livery
ECHO   Tyrrell : 	No tobacco livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_04Europe.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_03Europe.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Forti.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 04 - Nurburgring" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Nurburgring

:1996_Imola
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 SAN MARINO GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Fisichella	(IN) 		T. Marques and G. Lavaggi	(OUT)
ECHO   Forti #22 : 		L. Badoer	(IN)
ECHO   Forti #23 : 		A. Montermini	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Late season 'Arrows' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_02Brazil.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_04SanMarino.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Forti.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 05 - Imola" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Imola

:1996_Monaco
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 MONACO GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Fisichella	(IN) 		T. Marques and G. Lavaggi	(OUT)
ECHO   Forti #22 : 		L. Badoer	(IN)
ECHO   Forti #23 : 		A. Montermini	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Late season 'Arrows' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_05Monaco.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_04SanMarino.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Forti.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 06 - Monaco" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Monaco

:1996_Barcelona
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 SPANISH GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Fisichella	(IN) 		T. Marques and G. Lavaggi	(OUT)
ECHO   Forti #22 : 		L. Badoer	(IN)
ECHO   Forti #23 : 		A. Montermini	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Late season 'Arrows' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_07Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_05Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Forti.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 07 - Barcelona" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Barcelona

:1996_Montreal
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 CANADIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Fisichella	(IN) 		T. Marques and G. Lavaggi	(OUT)
ECHO   Forti #22 : 		L. Badoer	(IN)
ECHO   Forti #23 : 		A. Montermini	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Late season 'Arrows' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_07Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_05Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Forti.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 08 - Montreal" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Montreal

:1996_Magny-Cours
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 FRENCH GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Fisichella	(IN) 		T. Marques and G. Lavaggi	(OUT)
ECHO   Forti #22 : 		L. Badoer	(IN)
ECHO   Forti #23 : 		A. Montermini	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	France 'No tobacco' livery
ECHO   Arrows : 	Late season 'Arrows' livery
ECHO   Ferrari : 	France 'No tobacco' livery
ECHO   Benetton : 	France 'No tobacco' livery
ECHO   Williams : 	France 'No tobacco' livery
ECHO   McLaren : 	France 'No tobacco' livery
ECHO   Tyrrell : 	France 'No tobacco' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_09France.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_06France.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Forti.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 09 - Magny-Cours" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Magny-Cours

:1996_Silverstone
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 BRITISH GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Fisichella	(IN) 		T. Marques and G. Lavaggi	(OUT)
ECHO   Forti #22 : 		L. Badoer	(IN)
ECHO   Forti #23 : 		A. Montermini	(IN)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	No tobacco livery
ECHO   Arrows : 	Late season 'Arrows' livery
ECHO   Ferrari : 	No tobacco livery
ECHO   Benetton : 	No tobacco livery
ECHO   Williams : 	No tobacco livery
ECHO   McLaren : 	Britain 'No tobacco' livery
ECHO   Tyrrell : 	No tobacco livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_10Britain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_07Britain.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Forti.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 10 - Silverstone" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Silverstone

:1996_Hockenheim
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 GERMAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 19 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Lavaggi	(IN) 		T. Marques and G. Fisichella	(OUT)
ECHO   Forti #22 : 		L. Badoer	(OUT)
ECHO   Forti #23 : 		A. Montermini	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	No tobacco livery
ECHO   Arrows : 	Late season 'Arrows' livery
ECHO   Ferrari : 	No tobacco livery
ECHO   Benetton : 	No tobacco livery
ECHO   Williams : 	No tobacco livery
ECHO   McLaren : 	No tobacco livery
ECHO   Tyrrell : 	No tobacco livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_11Germany.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_08Germany.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 11 - Hockenheim" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Hockenheim

:1996_Hungaroring
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 HUNGARIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 19 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Lavaggi	(IN) 		T. Marques and G. Fisichella	(OUT)
ECHO   Forti #22 : 		L. Badoer	(OUT)
ECHO   Forti #23 : 		A. Montermini	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Late season 'Arrows' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_07Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_09Hungary.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 12 - Hungaroring" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Hungaroring

:1996_Spa-Francorchamps
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 BELGIUM GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 19 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Lavaggi	(IN) 		T. Marques and G. Fisichella	(OUT)
ECHO   Forti #22 : 		L. Badoer	(OUT)
ECHO   Forti #23 : 		A. Montermini	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Late season 'Arrows' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_07Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_09Hungary.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 13 - Spa-Francorchamps" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Spa-Francorchamps

:1996_Monza
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 ITALIAN GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 19 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Lavaggi	(IN) 		T. Marques and G. Fisichella	(OUT)
ECHO   Forti #22 : 		L. Badoer	(OUT)
ECHO   Forti #23 : 		A. Montermini	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Late season 'Arrows' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_07Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_09Hungary.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 14 - Monza" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Monza

:1996_Estoril
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 PORTUGUESE GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 19 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Lavaggi	(IN) 		T. Marques and G. Fisichella	(OUT)
ECHO   Forti #22 : 		L. Badoer	(OUT)
ECHO   Forti #23 : 		A. Montermini	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Late season 'Arrows' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_07Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_09Hungary.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 15 - Estoril" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Estoril

:1996_Suzuka
mode con cols=104 lines=52 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO              			1996 JAPANESE GRAND PRIX 
ECHO   =============================================================================================
ECHO.
ECHO   Select 19 AI opponents
ECHO.
ECHO   === Driver changes ==========================================================================
ECHO.
ECHO   Minardi #21 : 	G. Lavaggi	(IN) 		T. Marques and G. Fisichella	(OUT)
ECHO   Forti #22 : 		L. Badoer	(OUT)
ECHO   Forti #23 : 		A. Montermini	(OUT)
ECHO.
ECHO   === Special liveries ========================================================================
ECHO.
ECHO   Ligier : 	Early season 'Classic' livery
ECHO   Arrows : 	Late season 'Arrows' livery
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_07Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_09Hungary.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml	
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "Round 16 - Suzuka" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to F1 Season 1996 menu...
    goto :1996
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Suzuka

:FICT
mode con cols=87 lines=25 >nul
cls
ECHO.
ECHO   ===================================================================
ECHO   		FICTIONAL F1 SEASONS '96-'97 SCENARIOS    
ECHO   ===================================================================
ECHO.
ECHO   1996 Scenarios:
ECHO   1) What if Dome joined as the 12th team?
ECHO   2) What if Senna survived Imola 1994? - Season 1996
ECHO   3) What if Pacific and Simtek merged into Lotus? - Season 1996
ECHO   4) 1990s Legends
ECHO.
ECHO   x. previous page
ECHO   ===================================================================================	
ECHO.
set /p choice=-  Select an option and press ENTER: 
if "%choice%"=="1" goto 1996_Dome
if "%choice%"=="2" goto 1996_Senna
if "%choice%"=="3" goto 1996_Lotus
if "%choice%"=="4" goto 1996_Legends
if "%choice%"=="x" goto main_menu
ECHO "%choice%" is not valid, try again

:1996_Dome
mode con cols=104 lines=32 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO               F1 Season 1996 what if... Dome joins as the 12th team
ECHO   =============================================================================================
ECHO.
ECHO   Select 23 AI opponents
ECHO.
ECHO   =============================================================================================
ECHO.
ECHO   In 1995, the Japanese Formula 3000 constructor Dome began plans
ECHO   to enter Formula One as a fully fledged constructor. Designed to use a
ECHO   Mugen-Honda engine, the F105 first saw the track in early 1996. With
ECHO   drivers Marco Apicella, Naoki Hattori and Shinji Nakano behind the wheel,
ECHO   Dome spent the span of the 1996 season testing and improving their car
ECHO   with the goal of entering Formula One in 1997. Unfortunately, funding
ECHO   dried up and the small Japanese constructor was forced to abandon their plans.
ECHO.
ECHO   What if, instead of spending the year testing the car in private tests, Dome
ECHO   decided to enter the Championship in 1996 before their funding ran out?
ECHO   How well would they have done competing against the other teams? Will they
ECHO   make a mark for themselves? Or will they exit the sport at the end of the
ECHO   season with their tail under their legs?
ECHO.
ECHO   Take over the seat of Shinji Nakano or Naoki Hattori, and rewrite history in Dome's favour.
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_07Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_05Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Dome.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "What if Dome joins as the 12th team?" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to the Fictional Scenarios menu
    goto :FICT
)

:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Dome

:1996_Senna
mode con cols=104 lines=45 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO               F1 Season 1996 what if... Senna survived the 1994 San Marino GP
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   =============================================================================================
ECHO.
ECHO   At the 1994 San Marino Grand Prix, the Formula One world tragically lost its
ECHO   biggest star when Ayrton Senna had a fatal accident and became the second fatality that weekend.
ECHO   In death, Senna left his fans wondering what would have happened to him if he
ECHO   survived that terrible weekend. Where would his career have gone?
ECHO.
ECHO   So, what if Ayrton Senna survived the 1994 San Marino Grand Prix and continued
ECHO   to race afterwards? Senna still crashes at Imola, but he survives with a broken
ECHO   leg. Missing most of the rest of the 1994 season, the Brazilian champion
ECHO   returns to his Williams seat in 1995.
ECHO.
ECHO   The year is now 1996, and Senna is seeking his next World Championship crown.
ECHO   With Schumacher moving to the struggling Ferrari and Benetton trying to adapt
ECHO   without their superstar, the way is wide open for Senna to take an easy championship
ECHO   win. However, his teammate is waiting in the wing, seeking to emulate his late father
ECHO   and take a crown of his own. Can Ayrton Senna successfully remain on top and win
ECHO   another championship? Will Damon Hill finally beat Goliath and win the 1996 World
ECHO   Championship? Or perhaps a wildcard will spoil the party for the Williams team and
ECHO   get themselves into serious contention?
ECHO.
ECHO   Take over your prefered driver (or drive as yourself) and explore this fascinating
ECHO   fictional scenario featuring one of the sport's biggest legends.
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_07Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_Senna.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "What if Senna survived Imola 1994? - Season 1996" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to the Fictional Scenarios menu
    goto :FICT
)
:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Senna

:1996_Lotus
mode con cols=104 lines=45 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO               F1 Season 1996 what if... Pacific and Simtek merged and reformed Lotus
ECHO   =============================================================================================
ECHO.
ECHO   Select 23 AI opponents
ECHO.
ECHO   =============================================================================================
ECHO.
ECHO   In 1994, Pacific and Simtek entered the Formula One World Championship.
ECHO   Like every other team and driver before them, they had ambitions of making it to
ECHO   the top of the sport. Unfortunately, from the very beginning, both teams were
ECHO   outclassed by the rest of the grid. Haunted by the tragic death of Simtek's
ECHO   Roland Ratzenberger and their poor performances, both teams struggled coming into 1995.
ECHO   By the time 1996 began, both teams were gone, relegated to the history books.
ECHO.
ECHO   So, what if, to ensure their survival, Pacific and Simtek merged to form one singular
ECHO   team? With Pacific having the rights to use the name, the new team rebrands themselves
ECHO   under the Team Lotus name. Pacific's Bertrand Gachot and Simtek's Hideki Noda become
ECHO   the drivers of the new Lotus incarnation.
ECHO.
ECHO   Can this new Team Lotus learn of the fates of its predecessors and solidify its place
ECHO   into Formula One? Or will it be remembered as a failed, desperate attempt by two
ECHO   backmarker teams to remain on the grid?
ECHO.
ECHO   Sit behind the wheel of a Lotus and try bringing fame to the famous name once more.
ECHO   Or, observe Lotus from the safety of another team as the remnants of Pacific and
ECHO   Simtek attempt to survive yet another season.
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_07Spain.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_Lotus.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_Lotus.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "What if Pacific and Simtek merged into Lotus? - Season 1996" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to the Fictional Scenarios menu
    goto :FICT
)
:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Lotus

:1996_Legends
mode con cols=104 lines=45 >nul
cls
ECHO.
ECHO   =============================================================================================
ECHO               F1 Season 1996 : 1990s Legends Racing Together
ECHO   =============================================================================================
ECHO.
ECHO   Select 21 AI opponents
ECHO.
ECHO   =============================================================================================
ECHO.
ECHO   After surviving the 1994 San Marino Grand Prix, Ayrton Senna finishes the 1995
ECHO   season with Williams before moving to Ferrari to partner Michael Schumacher.
ECHO   His seat is taken by the 1995 CART Champion Jacques Villeneuve, with Damon Hill
ECHO   as his teammate. Meanwhile, Alain Prost returns from his second retirement and join
ECHO   McLaren once again to drive alongside Mika Hakkinen. Finally, the 1992 World Champion
ECHO   Nigel Mansell decide to give Formula One one last chance and join Jordan Grand Prix
ECHO   to partner Rubens Barrichello.
ECHO.   
ECHO   A not very realistic but fun scenario where seven past and future World Champions
ECHO   are on the same grid together. Only one can be on top. Will it be you?
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
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12_1996_Legends.xml .\Vehicles\Textures\CustomLiveries\Overrides\mclaren_mp4_12\mclaren_mp4_12.xml
	DEL .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	COPY .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1_1996_Legends.xml .\Vehicles\Textures\CustomLiveries\Overrides\formula_v10_g1\formula_v10_g1.xml
	DEL .\UserData\CustomAIDrivers\F-V10_Gen1.xml
	COPY .\UserData\CustomAIDrivers\F-V10_Gen1_96_97.xml .\UserData\CustomAIDrivers\F-V10_Gen1.xml
    echo F1 1996 Season "1990s Legends" XML files installed.
    goto end
)

if /I "%confirm%"=="N" (
    echo Back to the Fictional Scenarios menu
    goto :FICT
)
:: Si la saisie est invalide
echo Choix invalide. Veuillez recommencer.
goto :1996_Legends

:end
pause