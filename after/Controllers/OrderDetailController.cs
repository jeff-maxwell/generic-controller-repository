using GenericControllerRepository.Interfaces;
using GenericControllerRepository.Models;

namespace GenericControllerRepository.Controllers
{
    public class OrderDetailController : GenericController<OrderDetail>
    {
        IRepository<OrderDetail> _repository;
        public OrderDetailController(IRepository<OrderDetail> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}