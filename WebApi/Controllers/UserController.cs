using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Validator;
using System;
using System.Threading.Tasks;
using WebApi.Configuration;
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
        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] User model)
        {


            var user = _userService.GetUserForLogin(model.Email, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            user.Password = "";

            return new
            {
                user = user,
                token = token
            };
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
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseUserService.Get());
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
