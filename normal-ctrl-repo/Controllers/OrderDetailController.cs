using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegularControllerRepo.Interfaces;
using RegularControllerRepo.Models;

namespace RegularControllerRepo.Controllers
{
    [Route("api/[controller]")]
    public class OrderDetailController : Controller
    {
        IRepository<OrderDetail> _repoService;
        public OrderDetailController(IRepository<OrderDetail> repoService)
        {
            _repoService = repoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _repoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var record = await _repoService.GetById(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderDetail record)
        {
            var newRecord = await _repoService.Add(record);

            return Ok(newRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] OrderDetail record)
        {
            var updatedRecord = await _repoService.Update(record);

            return Ok(updatedRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repoService.Delete(id);

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var result = await _repoService.Count();

            return Ok(result);
        }
    }
}