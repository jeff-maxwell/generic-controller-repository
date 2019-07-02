using System;
using System.Threading.Tasks;
using GenericControllerRepository.Interfaces;
using GenericControllerRepository.Models;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace GenericControllerRepository.Controllers
{

    [Route("api/[controller]")]
    public abstract class GenericController<TEntity> : Controller where TEntity : class, new()
    {
        private IRepository<TEntity> _repository;

        public GenericController(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var record = _repository.GetById(id);
            if (record == null)
                return NotFound();

            return Ok(record);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TEntity record)
        {
            var newRecord = await _repository.Add(record);

            return Ok(newRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TEntity record)
        {
            var updatedRecord = await _repository.Update(record);

            return Ok(updatedRecord);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _repository.Delete(id);

            return Ok(result);
        }
    }
}