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
    public class ProductController : ControllerBase
    {
        private IBaseService<Product> _baseProductService;
        private IProductService _productService;
        private IProductRepository _productRepository;  
       
        public ProductController(IBaseService<Product> baseProductService, IProductService productService, IProductRepository productRepository)
        {
            _baseProductService = baseProductService;
            _productService = productService;
            _productRepository = productRepository;
        }
        // Criar o produto
        [HttpPost]
        [Route("CreateProduct")]
        public IActionResult Create([FromBody] Product product)
        {
            var aux = _productService.ValidationAddProduct(product.NameProduct, product.IdProduct);
            if (product == null)
                return NotFound();

            if (aux == false)
            {
                return BadRequest("Erro ao Cadastrar produto! Verifique os campos preenchidos e tente novamente.");
            }
            else
            {
                return Execute(() => _baseProductService.Add<ProductValidator>(product).IdProduct);
            }

           
        }
        // Atualizar o produto
        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            var aux = _productService.ValidationAddProduct(product.NameProduct, product.IdProduct);
            if (product == null)
                return NotFound();

            if (aux == false)
            {
                return BadRequest("Erro ao Atualizar produto! Verifique os campos preenchidos e tente novamente.");
            }
            else
            {
                return Execute(() => _baseProductService.Update<ProductValidator>(product));
            }
        }


        // Método de deletar um produto pelo seu id.
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

        //Selecionar os produtos
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseProductService.Get());
        }

        //selecionar o produto pelo nome:
        [HttpGet("/{name}")]
        public IActionResult GetByName(string name)
        {
            if (name == null)
                return NotFound();

            return Execute(() => _productRepository.GetProductByName(name));
        }

        // Método de selecionar um produto pelo seu id.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseProductService.GetById(id));
        }
        
        //Método de executar os outros métodos e retornar o resultado.
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
