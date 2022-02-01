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
    // Service de Entrada (regras de negócio)
    public class InputService : IInputService 
    {
        private readonly IBaseRepository<Input> _baseRepository;
        private IInputRepository _inputRepository;
        private readonly IMapper _mapper;
        private ICompanyRepository _companyRepository;
        private IProductRepository _productRepository;
        private IInventoryRepository _inventoryRepository;
        public InputService(IInventoryRepository inventoryRepository, IProductRepository productRepository, ICompanyRepository companyRepository, IBaseRepository<Input> baseRepository, IMapper mapper, IInputRepository inputRepository)
        {
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
            _companyRepository = companyRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
            _inputRepository = inputRepository;
        }
        // Método de listar.
        public IEnumerable<InputViewModel> GetInputs()
        {
            var input = _inputRepository.GetInput();
            return _mapper.Map<IEnumerable<InputViewModel>>(input);
        }

        // Só podemos cadastrar entradas com valores maiores que zero.
        public bool validationQuantity(Input input)
        {
            if (input.Quantity > 0) { return true; } else { return false; }   
        }

        // Verifica se o produto que se deseja inserir já existe no estoque, se sim, a quantidade será atualizada, se não, será criado um novo estoque.
        public bool CheckWhenAddQuantityInInventory(Input input)
        {
            var inventory = _inventoryRepository.Get();
            foreach (var item in inventory)
            {
                if (item.ProductId == input.ProductId && item.CompanyId == input.CompanyId)
                {
                    item.TotalQuantity += input.Quantity;    
                    return true;
                }
            }

            return false;   
        }

        // Retorna o produto da entrada pelo nome.
        public Product GetProductByNameInInput(string nameProduct)
        {
            var product = _productRepository.GetProductByName(nameProduct.ToUpper());
            var answer = _inputRepository.GetProductByIdInInput(product.IdProduct);
            if (answer == null) { return null; } else { return product; }  
           
        }
    }
}
