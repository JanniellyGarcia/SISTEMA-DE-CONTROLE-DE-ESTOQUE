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
    public class InputController : ControllerBase   
    {
        private IBaseService<Input> _baseInputService;
        private IBaseService<Inventory> _baseInventoryService;
        private IInputService _inputService;
        private IInputRepository _inputRepository;  

        public InputController(IInputRepository inputRepository, IBaseService<Inventory> baseInventoryService,IBaseService<Input> baseInputService, IInputService inputService)
        {
            _inputRepository = inputRepository;
            _baseInventoryService = baseInventoryService;
            _baseInputService = baseInputService;
            _inputService = inputService;
           
        }

        // Criar a entrada.
        [HttpPost]
        [Route("CreateInput")]
        public IActionResult Create([FromBody] Input input)
        {
            var aux = _inputService.validationQuantity(input);
            if (input == null)
                return NotFound();

            if (aux == false)
            {
                return BadRequest("Erro ao Cadastrar a entrada! Quantidade impossível de ser cadastrada.");
            }
            else
            {
                if (_inputService.CheckWhenAddQuantityInInventory(input) == true)
                {
                    return Execute(() => _baseInputService.Add<InputValidator>(input).IdInput);
                }
                Inventory inventory = new Inventory()
                {
                    CompanyId = input.CompanyId,
                    ProductId = input.ProductId,
                    StartingQuantity = input.Quantity, 
                    TotalQuantity = input.Quantity,
                };
                Execute(() => _baseInputService.Add<InputValidator>(input).IdInput);
                return Execute(() => _baseInventoryService.Add<InventoryValidator>(inventory).IdInventory);


            }
        }

        //Selecionar as entradas
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _inputRepository.GetInput());
        }

        //Retorna o produto da entrada pelo nome.
        [HttpGet("get/{name}")]
        public IActionResult GetByNameProduct(string name)
        {
            if (name == null)
                return NotFound();

            return Execute(() => _inputService.GetProductByNameInInput(name.ToUpper())); 
        }

        // Método de selecionar uma entrada pelo seu id.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _inputRepository.GetInputById(id));
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
