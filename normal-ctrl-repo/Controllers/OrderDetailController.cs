using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Controllers
{
    [Route("api/[controller]")]
    public class OrderDetailController : Controller
    {
        IOrderDetail _OrderDetailService;
        public OrderDetailController(IOrderDetail OrderDetailService)
        {
            _OrderDetailService = OrderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _OrderDetailService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var record = await _OrderDetailService.GetById(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] OrderDetail record)
        {
            var newRecord = await _OrderDetailService.Add(record);

            return Ok(newRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] OrderDetail record)
        {
            var updatedRecord = await _OrderDetailService.Update(record);

            return Ok(updatedRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _OrderDetailService.Delete(id);

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var result = await _OrderDetailService.Count();

            return Ok(result);
        }
    }
}