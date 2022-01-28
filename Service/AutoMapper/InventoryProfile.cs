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
    public class InventoryProfile : Profile
    {

        public InventoryProfile()
        {

            CreateMap<InventoryViewModel, Inventory>().ReverseMap();
        }
    }
}
