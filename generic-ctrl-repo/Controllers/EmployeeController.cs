using GenericControllerRepository.Interfaces;
using GenericControllerRepository.Models;

namespace GenericControllerRepository.Controllers
{
    public class EmployeeController : GenericController<Employee>
    {
        IRepository<Employee> _repository;
        public EmployeeController(IRepository<Employee> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}