using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Validator;
using System;

namespace WebApi.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private IBaseService<Inventory> _baseInventoryService;
        private IInventoryService _inventoryService;
        private IInventoryRepository _inventoryRepository;

        public InventoryController(IBaseService<Inventory> baseInventoryService, IInventoryService inventoryService, IInventoryRepository inventoryRepository)
        {
            _baseInventoryService = baseInventoryService;
            _inventoryService = inventoryService;
            _inventoryRepository = inventoryRepository;
        }

        //Selecionar os estoque.
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _inventoryRepository.Get());
        }

        // Método de selecionar o estoque pelo seu id.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseInventoryService.GetById(id));
        }
        // Método de deletar um estoque pelo seu id.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseInventoryService.Delete(id);
                
                return true;
            });

            return new NoContentResult();
        }


        //Método de executar os outros métodos e retornar exceções.
        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
