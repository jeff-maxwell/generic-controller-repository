using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Controllers
{
    [Route("api/[controller]")]
    public class SupplierController : Controller
    {
        ISupplier _SupplierService;
        public SupplierController(ISupplier SupplierService)
        {
            _SupplierService = SupplierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _SupplierService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var record = await _SupplierService.GetById(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Supplier record)
        {
            var newRecord = await _SupplierService.Add(record);

            return Ok(newRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Supplier record)
        {
            var updatedRecord = await _SupplierService.Update(record);

            return Ok(updatedRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _SupplierService.Delete(id);

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var result = await _SupplierService.Count();

            return Ok(result);
        }
    }
}