using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Validator;
using System;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebApi.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IBaseService<User> _baseUserService;
        private IUserService _userService;
        public UserController(IBaseService<User> baseUserService, IUserService userService)
        {
            _userService = userService;
            _baseUserService = baseUserService;
        }
        // Criar o usuário
        [HttpPost]
        [Route("CreateUser")]
        public IActionResult Create([FromBody] User user)
        {
            if (user == null)
                return NotFound();


            return Execute(() => _baseUserService.Add<UserValidator>(user).Id);
        }

        // Atualizar o usuário
        [HttpPut]
        public IActionResult Update([FromBody] User user)
        {
            if (user == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<UserValidator>(user));
        }


        // Método de deletar um usuário pelo seu id.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseUserService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        //Selecionar usuário
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseUserService.Get());
        }

        // Método de selecionar um usuário pelo seu id.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseUserService.GetById(id));
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
