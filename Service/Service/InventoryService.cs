using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Service.Interfaces;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    // Service de Estoque (regras de negócio)
    public class InventoryService : IInventoryService
    {
        private IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
   
        public InventoryService(IInventoryRepository inventoryRepository, IProductRepository productRepository, ICompanyRepository companyRepository, IBaseRepository<Inventory> baseRepository, IMapper mapper, IInputRepository inputRepository)
        {
            _inventoryRepository = inventoryRepository;    
            _mapper = mapper;
        }
        // Método de listar.
        public IEnumerable<InventoryViewModel> GetInventories()
        {

            var inventory = _inventoryRepository.Get();
            return _mapper.Map<IEnumerable<InventoryViewModel>>(inventory);
        }

     
    }
}
