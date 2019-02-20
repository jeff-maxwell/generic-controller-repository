using GenericControllerRepository.Interfaces;
using GenericControllerRepository.Models;

namespace GenericControllerRepository.Controllers
{
    public class SupplierController : GenericController<Supplier>
    {
        IRepository<Supplier> _repository;
        public SupplierController(IRepository<Supplier> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}