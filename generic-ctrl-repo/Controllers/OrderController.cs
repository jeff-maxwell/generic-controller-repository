using GenericControllerRepository.Interfaces;
using GenericControllerRepository.Models;

namespace GenericControllerRepository.Controllers
{
    public class OrderController : GenericController<Order>
    {
        IRepository<Order> _repository;
        public OrderController(IRepository<Order> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}