using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Validator;
using System;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IBaseService<Company> _baseProductService;
        private ICompanyService _companytService;
        private ICompanyRepository _companytRepository;

        public CompanyController(IBaseService<Company> baseProductService, ICompanyService companytService, ICompanyRepository companytRepository)
        {
            _baseProductService = baseProductService;
            _companytService = companytService;
            _companytRepository = companytRepository;
        }

        // Criar  a Empresa
        [HttpPost]
        [Route("CreateCompany")]
        public IActionResult Create([FromBody] Company company)
        {
            var aux = _companytService.ValidationAddCompany(company.NameCompany, company.IdCompany);
            if (company == null)
                return NotFound();

            if (aux == false)
            {
                return BadRequest("Erro ao Cadastrar produto! Verifique os campos preenchidos e tente novamente.");
            }
            else
            {
                return Execute(() => _baseProductService.Add<CompanyValidator>(company).IdCompany);
            }

        }

        // Método de deletar a Empresa pelo seu id.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseProductService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        //Selecionar as Empresa
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseProductService.Get());
        }

        //selecionar aempresa pelo nome:
        [HttpGet("get/{nameCompany}")]
        public IActionResult GetCompanyByName(string nameCompany)
        {
            if (nameCompany == null)
                return NotFound();

            return Execute(() => _companytRepository.GetCompanyByName(nameCompany.ToUpper()));
        }

        // Método de selecionar a Empresa pelo seu id.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseProductService.GetById(id));
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
