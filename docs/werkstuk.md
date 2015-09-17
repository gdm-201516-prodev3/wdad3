Werkstuk
=======================================

|Info|  |
|----|---|
|Olod|Web Design & Development IV (WDAD4)|
|Auteur(s)|Philippe De Pauw - Waterschoot|
|Opleiding|Bachelor in de Grafische en digitale media|
|Academiejaar|2015-16|

***

|Info|  |
|----|---|
|Werktitel|Let's|
|Subtitel|The World Bank Data Catalog|
|Milestone 1|**Week 4** Presentatie tussentijds productiedossier|
|Milestone 2|**Week 6** Presentatie visual designs|
|Milestone 3|**Week 11** Presentatie alpha versie|
|Deadline|**23-12-2015** Opleveren opdracht (Bitbucket)|
|Examen|Afgedrukt dossier, Poster, Bitbucket, Online werkende applicatie|

Omschrijving
------------

> Het werkstuk wordt op een Bitbucket-repository gepubliceerd dat toegankelijk is voor [Olivier Parent][https://bitbucket.org/olivierparent] en [Philippe De Pauw - Waterschoot][https://bitbucket.org/drdynscript].

> **Probleemstelling**
> Hoe kan een softwaresysteem ruilhandel stimuleren?

Ontwerp en ontwikkel **individueel** een databasegebaseerd softwaresysteem gemaakt met de technologieën die tijdens de colleges aan bod komen, en bestaat uit:
 1. *Frontoffice*
 2. *Backoffice* 

> LETS staat voor **"Local Exchange and Trading System"**. Vrij vertalen we dit wel eens als "lokaal uitwisselings systeem". Het ruilsysteem in deze vorm ontstond in een plaats in Canada waar op korte termijn de werkverschaffing en dus rechtstreeks de inkomsten van mensen wegtrok. Uit noodzaak gingen zij weer ruilen, maar dan wel op een eigentijdse manier. Nadien heeft het idee zich snel verspreid over de hele wereld.


Functionele specificaties
-------------------------


Technische specificaties
------------------------

###Versiebeheer

- Maak een Team aan op **Bitbucket** met als team id het academiejaar gevolgd door de groepsnummer, bv.: **2015-16_2MMPA-01**.
- Voeg vervolgens de groepsleden hieraan toe.
- Maak een groepsfoto en voeg deze toe als avatar van het team.
- Maak in dit team de volgende repositories aan:
    - **open_the_gates_for_data_app**. Bevat de applicatie volgens de opgelegde mappenstructuur.
    - **open_the_gates_for_data_docs**. Bevat productiedossier, screenshots, ... volgens de opgelegde structuur.

###Frontend

- Core technologies: HTML5, CSS3 en JavaScript
- Template engines: Jade, Haml, Swig of Handlebars
- Storage: JSON bestanden, localstorage en/of IndexedDB
- Bibliotheken: jQuery, underscore.js, lodash.js, crossroads.js, js-signals, Hasher.js, ...
- Andere bibliotheken worden hierin aangevuld tijdens het semester!
- Uitzonderingen mogelijk betreffende JavaScript bibliotheken mogelijk mits toelating!

> Webapplicatie moet responsive zijn! Het responsive framework alsook alle andere bestanden moeten zelf geïmplementeerd worden.

Mappen en bestanden
-------------------

- **lets_app** (folder)
    
    
- **lets_docs** (folder)
    - dossier.md
    - dossier.pdf
    - poster.pdf
    - presentatie.pdf
    - README.md (Bevat een synopsis van de applicatie + relatieve links naar de andere bestanden binnen deze folder)
    - screencast.mpeg
    - screenshot_320.png
    - screenshot_480.png
    - screenshot_640.png
    - screenshot_800.png
    - screenshot_960.png
    - screenshot_1024.png
    - screenshot_1280.png  
    - timesheet.xslx      


Timesheet
---------

> Klanten/werkgevers weten graag hoe lang je aan iets zal werken en hoe lang je er effectief aan gewerkt hebt. Een realistische inschatting maken van hoelang iets zal duren kan enkel op basis van (lange) werkervaring. Daarom is het belangrijk dat je nu al bijhoudt hoe lang iets duurt, zodat je deze skill leert. Dit is geen plezante bezigheid, maar maak er een gewoonte van om dit fequent bij te houden. Achteraf nog weten hoelang je aan iets gewerkt hebt is vaak nog lastiger.

Houd dagelijks een timesheet bij in Excel en post naar je Bitbucket-repository. Vermeld **per dag** de (deel)functionaliteit(en) waaraan je gewerkt hebt en hoe lang (de kleinste opdeling is een kwartier: 0,25 uur). 

### Voorbeeld

| Datum      |   Taak                        |         Tijd   |
|-----------:|:------------------------------|---------------:|
| 2015-09-22 |   Doctrinemigration voor user |     0,25 uur   |
| 2015-09-22 |   Registratieformulier        |     3,75 uur   |
| â€¦          |   â€¦                           |            â€¦   |
| 2015-12-21 | **Totaal**                    | **137,00 uur** |
  
    
Source Code Management
----------------------

### Branches

Gebruik git met de [Feature Branch Workflow](https://www.atlassian.com/git/tutorials/comparing-workflows/feature-branch-workflow).

Nieuwe branch per functionaliteit, nadat de functionaliteit klaar is voor productie (nadat alle testen succesvol verlopen zijn), dan wordt de branch in de master branch gemerged.

#### Commit Prefixes

| Prefix    | Verklaring                                                                         |
|:----------|:-----------------------------------------------------------------------------------|
| [FEATURE] | deelfunctionaliteit                                                                |
| [FIX]     | Bugfix                                                                             |
| [TASK]    | Bijv. refactoring (structuur, naamgeving aanpassen), updates van derden toepassen. |
| [WIP]     | *Work in Progress,* voor tussentijdse commits van iets wat nog niet af is.         |

### Voorbeeld

Branch `account-feature`:

 - [FEATURE] Add user registration form and save data to db
 - [TASK] Rename field `lastname` to `familyname` 
 
 Dossier
---------
>  - Moet geschreven worden in Markdown
>  - Ook PDF safe-for-web versie door export via In-Design. Het toevoegen van dit bestand aan de repo doe je pas in laatste instantie.

- Briefing
- Analyse
- Technische specificaties
- Functionele specificaties
- Persona's (+ scenario): Gebruiker (User) (3x)
- Indeëenborden + keuze uit ideëenborden resulterend in een Moodboard (sfeer die het visuele ontwerp moet uitstralen)
- Sitemap
- Wireframes
- Style Tiles (Minstens 2x en duid aan welke gekozen werd)
- Visual designs
- Screenshots eindresultaat
- Screenshots snippets HTML (1x), CSS (1x) en JavaScript (3x)
- Tijdsbesteding per student

Academische Poster
------------------

> **Afgedrukt op A2**, in te dienen op het mondeling examen.
> **Controleer extra goed op spellingsfouten!**

Een afgedrukte A2-poster die de presentatie moet ondersteunen. De academische poster moet een leek duidelijk maken wat het project was:

 - Synopsis
 - Doel van de opdracht
 - Resultaat (ondersteund met schermafbeeldingen)
 - Gebruikte technologieën (gebuik officiële logo's indien mogelijk, maar vermijd specifieke versienummers zodat het niet te snel verouderd overkomt)

> Niet vergeten te vermelden: voornaam, naam, naam van het opleidingsonderdeel, academiejaar, Bachelor in de grafische en digitale media, Multimediaproductie, proDEV, Arteveldehogeschool.
> Bijvoorbeeld:
> 
> Philippe De Pauw - Waterschoot
> New Media Design & Development III, Academiejaar 2015-16
> Bachelor in de grafische en digitale media, Multimediaproductie (proDEV)
> Arteveldehogeschool

Presentatie
-----------------

Tijdens de presentie toon je aan:

- dat de frontoffice en de backoffice correct werken;
- dat het project een geautomatiseerde workflow bevat;
- dat alle items op de checklist aanwezig zijn;
- of er eventuele extra's toegevoegd zijn.

Zorg voor een grafisch verzorgde presentatie en verzorgd taalgebruik. Gebruik PowerPoint (of alternatieven), screencasts en live demonstraties

> Indien je werkstuk delen of werk van andere studenten bevat, geef je dit duidelijk aan!
> **Controleer extra goed op spellingsfouten!**