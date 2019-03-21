# Generic Controller/Repository

This project uses a generic controller and the repository pattern to cut down on duplication of code.

## Controllers

There is a Generic Controller that does the main API calls that most APIs provide like Get ALL, Get by ID, Add New, Update, Delete, Count.  The Generic Controller uses a Generic Repository pattern for each of the service calls allowing even more code reuse and reduction.  Then each individual controller inherits from the Generic Controller and can add other methods to that specific API if needed.

```c#
public class CustomerController : GenericController<Customer>
{
    IRepository<Customer> _repository;
    public CustomerController(IRepository<Customer> repository) : base(repository)
    {
        _repository = repository;
    }
}
```

```c#
public abstract class GenericController<TEntity> : Controller where TEntity : class, new()
{
    private IRepository<TEntity> _repository;

    public GenericController(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_repository.GetAll());
    }
}
```

**Example:**

GenericController has the following API calls:

- GET - /api/[TEntity] -> returns all [TEntity]
- GET - /api/[TEntity]/{id} -> returns [TEntity] record matching {id}
- GET - /api/[TEntity]/count -> returns number of [TEntity]
- POST - /api/[TEntity] -> creates a new [TEntity]
- PUT - /api/[TEntity]/{id} -> updates [TEntity] record matching {id}
- DELETE - /api/[TEntity]/{id} -> deletes [TEntity] record matching {id}

NOTE: [TEntity] is the Model passed into the Generic Controller to be used in the backend service calls.

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