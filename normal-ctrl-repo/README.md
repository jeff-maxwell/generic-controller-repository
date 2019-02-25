# Regular Controller/Repostory

This project has a Controller for each object and uses the Repostiory Pattern to allow generic service calls to the backend with Models that represent the data objects in the database.

There are a lot of examples using this pattern like this example from Microsoft [Design the infrastructure persistence layer](https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)

## Controllers

There is a Controller created for each Object to be returned from the database.

**Example:**

EmployeeController has the following API calls:

- GET - /api/employee -> returns all Employees
- GET - /api/employee/{id} -> returns Employee record matching {id}
- GET - /api/employee/count -> returns number of Employees
- POST - /api/employee -> creates a new Employee
- PUT - /api/employee/{id} -> updates Employee record matching {id}
- DELETE - /api/employee/{id} -> deletes Employee record matching {id}

Each of these calls a generic repository for the backend services

## Models

Models represent the objects (tables) from the database.

## Repository/Interface

The generic repository takes in the object (Employee, Customer, Product...) and makes the approrpiate calls to the backend.

```c#
public class Repository<T> : IRepository<T> where T : BaseModel
....
public async Task<IEnumerable<T>> GetAll()
{
    return await _context.Set<T>().ToListAsync<T>();
}
```

The Repository<T> allows an object to be passed in and the appropriate action can be taken on that object.

**Create an instance of the Repostory for Employee**

```c#
IRepository<Employee> _repoService;
```