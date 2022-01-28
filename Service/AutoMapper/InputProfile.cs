using AutoMapper;
using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapper
{
    // Mapeamento de model e viewmodel
    public class InputProfile : Profile
    {
        public InputProfile()
        {
            CreateMap<InputViewModel, Input>().ReverseMap();
        }
    }
}
