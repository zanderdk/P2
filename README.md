På denne CD findes:

* Rapport_a405A.pdf Rapporten på elektronisk form
* Program/ Kildekoden til programmet
* Program Installer/ Eksekverbar programfil
* Interviews/ Transskribering af interviews og lydfiler

Programmet
==========
Dette er løsningen til vores P2 2. semesters projekt, der omhandler administrering af havne. Løsningen er programmet LOBOP, et ressourceplanlægningsprogram til at holde styr på elementer i en havn. I programmet kan man tilføje medlemmer, gæster og deres både. Disse information vil blive gemt i en LocalDB database.  Programmet er kun testet på Windows 7 og 8.

Gruppe: A405a (SW2A405a@student.aau.dk)
* Mikkel Lægteskov Sø Madsen
* Kasper Kohsel Terndrup
* Frederik Højholt Andersen
* Alexander Dalsgaard Krog
* Simon Vandel Sillesen

Vejleder: Brian Nielsen

Kompilering
-----------
* Projektets kildekode ligger i "Program" mappen
* Projekt filen "Program/p2 projekt/p2 projekt/p2 projekt.csproj" åbnes i Visual Studio. Dette er kun testet i Visual Studio 2013.
* Visual Studio kan nu bygge løsningen "p2 projekt"

Installation
------------

* I "Program Installer" mappen køres "setup" filen.

Kørsel
------
Programmet autogenererer 7 hardcodede medlemmer, med medlemsnumre fra 1 til 7, og 13 medlemmer med tilfældige personlige informationer. Bruger nummer 3 har rettigheder til alting og er godt til at afprøve programmet med. Der kan logges ind med medlemslogin, eller ved indtastning af medlemsnummeret i chip-tekstfeltet. Alle kodeord på de 7 hardcordede medlemmer er "testpass".