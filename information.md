
## Was ist OData / History

* Open Data Protocol (OData)
* Gestartet von Microsoft im 2007 1.0
* Version 4 wurde von OASIS Standardtisiert

* Bildet Best-Pracitices von REST ab
* CRUD (Create, Read, Update, Delete) Funktionalität unter REST-konformen Protocol
* Verwendete STandards HTTP, JSON, XML 


## Bei OData gibt es ebenfalls die typischen Endpunkte

* POST   /odata/Addresses - Erstellen/Create
* GET    /odata/Addresses - Lesen/Read
* PATCH  /odata/Addresses - Schreiben/Update einzelner Eigenschaften
* PUT    /odata/Addresses - Schreiben/Update vollständiges Object
* DELETE /odata/Addresses - Löschen/Delete

## Aufbau OData

* Metadata - Aufbau des Datenmodels
* Datensets und Relationen zwischen einzelnen Datensets
* Abfragen und Transformation der Ergebnisse
* Bearbeitung der Daten - Erstellen, Ändern und Löschen
* Operationen für benutzerdefiniert Logik

### Datenmodel

* EDM - Entity Data Model 
  * Enthält alle Informationen zu Datensets, Relationen, Operationen, usw.
  * Vergleich zu EntityFramework Mapper
* EntitySet => Endpunkt einer Entität
* EntityType => Entität
* Complex Types => Prinzip Entitäten ohne Schlüssel 
* Enumerationen
* Operationen
* Annotations



## Lesende Operationen / OData Abfragen

* Es gibt unterschiedliche Operationen die verwendet werden können, wenn Daten abgefragt werden
  * $filter - Filter
    * http://localhost:5000/odata/Patient?$filter=Name eq Hans
    * http://localhost:5000/odata/Patient?$filter=startswith(Name, 'An')
  * $orderby - Sortierung
    * http://localhost:5000/odata/Patient?$orderby=Name
  * $expand - Erweiterung/Join
    * http://localhost:5000/odata/Patient?$expand=Case
  * $count - Zählen
    * http://localhost:5000/odata/Patient?$count
  * $select - Eigenschaften-weise Einschränkung
    * http://localhost:5000/odata/Patient?$select=Name
  * $top, $skip - Pagination
    * http://localhost:5000/odata/Patient?$top=100&$skip=0
    * http://localhost:5000/odata/Patient?$top=100&$skip=100
    * http://localhost:5000/odata/Patient?$top=100&$skip=200
  * and more

* 



### $filter
### $orderby
### $top $skip
### $expand


## Libraries

### Server libraries

* Microsoft.AspNetCore.OData


### Client libraries

* Microsoft.OData.Client
* Microsoft.OData.Core 
* Microsoft.OData.Edm
* CodeGenerator



## WORKSHOP: Creating a OData Service



### ASP.NET Core Project

* New project "ASP.NET Core WebApi"
* ProjectName Nexus.Odata.Service
* .NET Core 3.1 


### ASP.NET Core OData Library

* Microsoft.AspNetCore.OData 7.5.12
* Microsoft.EntityFrameworkCore.Sqlite 5.0.11

* [EVENTL.] Microsoft.AspNetCore.OData.Versioning
* [EVENTL.] Microsoft.AspNetCore.OData.Versioning.ApiExplorer

### Provide Entities

* Copy/Paste the Entities

### Flavor Startup.cs

* services.AddOData()
* OData EndPoints -> EdmModel etc

### Adding EFCore

* Create a DB Context
* Check if everything is running


### Creating the OData Controller

* Write the GET Function / Test it
* Write the POST Function / Test it
* CopyPaste the Rest


## WORKSHOP: Using the API via URLs

* Insomnia

## WORKSHOP: Using the API via Client

* MS Client


## WORKSHOP: Ausblick in OData Service / Client 

* Achtung: WorkInProgress
* Neue Entität anlegen
* IService erweitern Validierung eventl. Berechtigungen
* CustomFunction
