using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        IOrder _OrderService;
        public OrderController(IOrder OrderService)
        {
            _OrderService = OrderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _OrderService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var record = await _OrderService.GetById(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Order record)
        {
            var newRecord = await _OrderService.Add(record);

            return Ok(newRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Order record)
        {
            var updatedRecord = await _OrderService.Update(record);

            return Ok(updatedRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _OrderService.Delete(id);

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var result = await _OrderService.Count();

            return Ok(result);
        }
    }
}