ASP.NET5 Introduction
=====================

Installatie
-----------

###Microsoft Visual Code

**User Settings:**
```
{
	"editor.wrappingColumn": 80,
	"http.proxy": "http://proxy.arteveldehs.be:8080",
	"markdown.styles": []
}
```

###SQLite Software

- [SQLite browser](http://sqlitebrowser.org/)
- [SQLite expert](http://www.sqliteexpert.com/)

###Installatie van de .NET versiemanager (version manager)

[Install .NET on a MAC](http://docs.asp.net/en/latest/getting-started/installing-on-mac.html)

`curl -sSL https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.sh | DNX_BRANCH=dev sh && source ~/.dnx/dnvm/dnvm.sh`

[Install .NET on a WIN](http://docs.asp.net/en/latest/getting-started/installing-on-windows.html)

`@powershell -NoProfile -ExecutionPolicy unrestricted -Command "&{$Branch='dev';iex ((new-object net.webclient).DownloadString('https://raw.githubusercontent.com/aspnet/Home/dev/dnvminstall.ps1'))}"`

###Installatie van de .NET executieomgeving (execution environment)

**Installatie DNX voor .NET core:**

`dnvm upgrade -r coreclr`

**Installatie DNX voor mono (MAC):**

`dnvm upgrade -r mono`

**Oplijsten aanwezige executieomgevingen:**

`dnvm list`

```
D:\Hogeschool\2015-16\wdad3>dnvm list

Active Version           Runtime Architecture Location                     Alias
------ -------           ------- ------------ --------                     -----
       1.0.0-beta4       clr     x64          C:\Users\drdyn\.dnx\runtimes
       1.0.0-beta4       clr     x86          C:\Users\drdyn\.dnx\runtimes
       1.0.0-beta4       coreclr x64          C:\Users\drdyn\.dnx\runtimes
       1.0.0-beta4       coreclr x86          C:\Users\drdyn\.dnx\runtimes
       1.0.0-beta5       clr     x86          C:\Users\drdyn\.dnx\runtimes
       1.0.0-beta6-12189 clr     x86          C:\Users\drdyn\.dnx\runtimes default
  *    1.0.0-beta7       clr     x86          C:\Users\drdyn\.dnx\runtimes
```

**Weg met mono als default execution environment (MAC OSX)**

`dnvm use 1.0.0-beta7 -r coreclr -arch x86`

###Installatie npm

[Installatie op WIN](https://nodejs.org/dist/latest/node-v4.1.0-x64.msi)

`npm -g upgrade npm`

`npm -v`

###Installatie ASP.NET generator

`npm install -g generator-aspnet`

![CMD Generator-aspnet](images/genasp.net.png)

###Installatie bower, yo en Gulp

`npm install -g bower`

`npm install -g yo`

`npm install -g gulp`


Syllabus
--------
- [ASP.NET introductie]<http://docs.asp.net/en/latest/index.html>
