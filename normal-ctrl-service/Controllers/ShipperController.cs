using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegularService.Interfaces;
using RegularService.Models;

namespace RegularService.Controllers
{
    [Route("api/[controller]")]
    public class ShipperController : Controller
    {
        IShipper _ShipperService;
        public ShipperController(IShipper ShipperService)
        {
            _ShipperService = ShipperService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _ShipperService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var record = await _ShipperService.GetById(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Shipper record)
        {
            var newRecord = await _ShipperService.Add(record);

            return Ok(newRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Shipper record)
        {
            var updatedRecord = await _ShipperService.Update(record);

            return Ok(updatedRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _ShipperService.Delete(id);

            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> Count()
        {
            var result = await _ShipperService.Count();

            return Ok(result);
        }
    }
}