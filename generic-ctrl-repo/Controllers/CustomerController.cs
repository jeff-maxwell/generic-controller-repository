using GenericControllerRepository.Interfaces;
using GenericControllerRepository.Models;

namespace GenericControllerRepository.Controllers
{
    public class CustomerController : GenericController<Customer>
    {
        IRepository<Customer> _repository;
        public CustomerController(IRepository<Customer> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}