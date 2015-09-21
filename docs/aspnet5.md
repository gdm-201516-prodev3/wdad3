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