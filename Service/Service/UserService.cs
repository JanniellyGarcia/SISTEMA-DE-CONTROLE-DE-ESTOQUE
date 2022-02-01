using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Service.Service
{
    // Service de usuário (regras de negócio)
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _baseRepository;
        private IUserRepository _userRepository;
        private readonly IMapper _mapper;   
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //Validação de usuário.
        private void Validate(User obj, AbstractValidator<User> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }

        //Gerar código MD5:
        public string GerarMD5(string valor)

        {


            MD5 md5Hasher = MD5.Create();


            byte[] valorCriptografado = md5Hasher.ComputeHash(Encoding.Default.GetBytes(valor));


            StringBuilder strBuilder = new StringBuilder();


            for (int i = 0; i < valorCriptografado.Length; i++)
            {
                strBuilder.Append(valorCriptografado[i].ToString("x2"));
            }


            return strBuilder.ToString();

        }
        // método de adicionar.
        public User Add<TValidator>(User obj) where TValidator : AbstractValidator<User>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            obj.Password = GerarMD5(obj.Password);
            _baseRepository.Insert(obj);
            return obj;
        }

        // método de listar.
        public IEnumerable<UserViewModel> GetUser()
        {
            var user = _userRepository.GetUser();
            return _mapper.Map<IEnumerable<UserViewModel>>(user); //mapeado objetos de model para viewmodel
        }

        // método de autenticação.
        public User GetUserForLogin(string email, string password)
        {  
            var obj = _userRepository.GetAllAuthentication(email, password);
            return obj;
            
        }
    }
}
