# Regular Controller/Service

This project is the typical project that is broken into Controller, Services (via Interfaces) with Models that represent the data objects in the database.

There are a lot of examples using this pattern like this example from Microsoft in 2009 [Validating with a Service Layer](https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-cs)

## Controllers

There is a Controller created for each Object to be returned from the database.

**Example:**
EmployeeController has the following API calls:
GET - /api/employee -> returns all Employees
GET - /api/employee/{id} -> returns Employee record matching {id}
GET - /api/employee/count -> returns number of Employees
POST - /api/employee -> creates a new Employee
PUT - /api/employee/{id} -> updates Employee record matching {id}
DELETE - /api/employee/{id} -> deletes Employee record matching {id}

## Models

Models represent the objects (tables) from the database.

## Services/Interfaces

Services contain the calls to the database to retreive the records.  They implement an Interface to force the service to implement all of the methods/functions and make it easier for testing.