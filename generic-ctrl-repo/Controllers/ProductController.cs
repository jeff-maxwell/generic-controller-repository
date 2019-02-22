using GenericControllerRepository.Interfaces;
using GenericControllerRepository.Models;

namespace GenericControllerRepository.Controllers
{
    public class ProductController : GenericController<Product>
    {
        IRepository<Product> _repository;
        public ProductController(IRepository<Product> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}