using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Validator;
using System;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OutputController : ControllerBase  
    {
        private IBaseService<Output> _baseOutputService;
        private IOutputService _outputService;
        private IOutputRepository _outputRepository;

        public OutputController(IBaseService<Output> baseOutputService, IOutputService outputService, IOutputRepository outputRepository)
        {
            _baseOutputService = baseOutputService;
            _outputService = outputService;
            _outputRepository = outputRepository;
        }

        // Criar as saídas.
        [HttpPost]
        [Route("CreateOutput")]
        public IActionResult Create([FromBody] Output output)
        {
            var validation = _outputService.OutputValidation(output);           
            if (output == null)
                return NotFound();

            if (validation != false )
            {
                return Execute(() => _baseOutputService.Add<OutputValidator>(output).IdOutput);
            }

            return BadRequest("Erro de quantidade! Verifique o estoque e tente novamente.");
        }

           
        //Selecionar as saídas
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseOutputService.Get());
        }

        // Método de selecionar uma entrada pelo seu id.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseOutputService.GetById(id));
        }

        // Método de selecionar uma entrada pelo seu nome.
        [HttpGet("get/{nome}")]
        public IActionResult GetProductByName(string name)
        {
            if (name == null)
                return NotFound();

            return Execute(() => _outputService.GetProductByNameInOutput(name));
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
