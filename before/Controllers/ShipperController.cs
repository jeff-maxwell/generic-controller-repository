using GenericControllerRepository.Interfaces;
using GenericControllerRepository.Models;

namespace GenericControllerRepository.Controllers
{
    public class ShipperController : GenericController<Shipper>
    {
        IRepository<Shipper> _repository;
        public ShipperController(IRepository<Shipper> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}