ASP.NET5
========


Microsoft Visual Code
---------------------

**User Settings:**
```
{
	"editor.wrappingColumn": 80,
	"http.proxy": "http://proxy.arteveldehs.be:8080",
	"markdown.styles": []
}
```


Installatie van de .NET versiemanager (version manager)
-------------------------------------------------------

[Install .NET on a MAC](http://docs.asp.net/en/latest/getting-started/installing-on-mac.html)

`curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh`

[Install .NET on a WIN](http://docs.asp.net/en/latest/getting-started/installing-on-windows.html)

`@powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"`

Installatie van de .NET executieomgeving (execution environment)
----------------------------------------------------------------

**Installatie DNX voor .NET core:**

`dnvm upgrade -r coreclr`

**Installatie DNX voor mono (MAC):**

`dnvm upgrade -r mono`

**Oplijsten aanwezige executieomgevingen:**

`dnvm list`

Installatie npm
---------------

[Installatie op WIN](https://nodejs.org/dist/latest/node-v4.1.0-x64.msi)

`npm -g upgrade npm`

`npm -v`

Installatie ASP.NET generator
-----------------------------

`npm install -g generator-aspnet`

![CMD Generator-aspnet](images/genasp.net.png)

Installatie bower, yo en Gulp
-----------------------------

`npm install -g bower`

`npm install -g yo`

`npm install -g gulp`

Weg met mono als default execution environment
----------------------------------------------

`dnvm use 1.0.0-beta7 -r coreclr -arch x86`

Build
-----

**Import remote packages**:
`dnu restore App.Models`

**Build**:
`dnu build App.Models`

Entity Framework
----------------

**Startup.cs**:

* Noodzalijk om migrations uit te voeren.
* Meestal aanwezig in een Web API of Web MVC project.
* Plaats van de **SQLite database**: bij voorkeur in een aparte folder op de server, bv. D:\data\libraries.sqlite, omdat we werken met verschillende project folders.
* Vermits EntityFramework 7 in beta is worden vele Database providers nog niet ondersteund, zoals: MySQL, PotsgresQL, MongoDB, ... . Enkel SQL Server en SQLite worden ondersteund op 28-09-2015. Wanneer de provider PostgreSQL binnenkort gereleased wordt zullen we overstappen naar deze Database provider. 
* In dit voorbeeld plaatsen we de `libraries.sqlite` databank in een `data` folder onder de root van het `App.Web` project.
* In de `Startup.cs` klasse uit het `App.Web` project halen we het absolut pad op naar deze databank via:
	```
	string path = appEnv.ApplicationBasePath.Substring(0, appEnv.ApplicationBasePath.LastIndexOf('\\'));      
    Configuration["Data:DefaultConnection:ConnectionString"] = $@"Data Source={path}/App.Web/data/libraries.sqlite";
	```

**Add new migrations**:  

* `dnx -p App.Data ef migrations add Initial -s App.Web`

**Update the database by executing migration code**:  

* `dnx -p App.Data ef database update -s App.Web`

Stappenplan: Repo, DI, Controller, View
---------------------------------------
1) Maak de interface aan voor het specifiek Model in het project App.Data
	> `IFAQRepo.cs`  
	> Voorzie in deze interface de noodzakelijke methoden!
2) Maak de corresponderende Repo aan die deze bovenvermelde interface beschrijft
	> `FAQRepo.cs`
3) Vermeld deze klassen als scope om DI op te lossen in de `Startup.cs` van het project `App.Web`
	> `services.AddScoped<IFAQRepo, FAQRepo>();`
4) Maak een instantie van de `IFAQRepo` aan, via services, in de `CommonController`
5) Maak een nieuwe controller aan met de naam `FAQController` en pas overerving toe van de `CommonController`
6) In de index actie method schrijven we de volgende code:

```
		public IActionResult Index()
        {
            var models = _faqRepo.GetFAQs();
            return View(models);
        }
```

7) Maak de corresponderende view aan voor deze actiemethode voor `FAQController`

`Views > FAQ > Index.cshtml`