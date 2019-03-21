using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        ICustomer _customerService;
        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var record = await _customerService.GetById(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Customer record)
        {
            var newRecord = await _customerService.Add(record);

            return Ok(newRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Customer record)
        {
            var updatedRecord = await _customerService.Update(record);

            return Ok(updatedRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _customerService.Delete(id);

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var result = await _customerService.Count();

            return Ok(result);
        }
    }
}