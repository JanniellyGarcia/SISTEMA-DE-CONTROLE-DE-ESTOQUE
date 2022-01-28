using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    // Service de saída (regras de negócio)
    public class OutputService : IOutputService
    {
        private readonly IBaseRepository<Output> _baseRepository;
        private IOutputRepository _outputRepository;
        private IInventoryRepository _inventoryRepository;
        private readonly IMapper _mapper;
        private IProductRepository _productRepository;
        public OutputService( IProductRepository productRepository ,IInventoryRepository inventoryRepository,IBaseRepository<Output> baseRepository, IMapper mapper, IOutputRepository outputRepository)
        {
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _baseRepository = baseRepository;
            _mapper = mapper;
            _outputRepository = outputRepository;
        }
        // Método de listar.
        public IEnumerable<OutputViewModel> GetOutput()
        {
            var output = _outputRepository.GetOutput();
            return _mapper.Map<IEnumerable<OutputViewModel>>(output);
        }

        //Verifica se a quantidade do output é válida >0.
        public bool ValidationQuantity(Output output)
        {
            if (output.Quantity >= 0) { return true; } else { return false; }
        }

        // Verifica se a quantidade no estoque é suficiente para realizar uma saída.
        public bool ValidationQuantityInInventory(Output output)
        {
            bool aux = false;
            var obj = _inventoryRepository.GetInventory();
            foreach (var item in obj)
            {
                if (item.ProductId == output.ProductId && item.CompanyId == output.CompanyId)
                {
                    if (output.Quantity < item.TotalQuantity){return true;}
                }
            }
            return aux;
        }

        /* 
         A função abaixo realiza modificação na quantidade total de produtos de estoque:
           É verificado se o estoque com a empresa e produto existem,após isso,
            é feita a verificação se qual tipo de saída será feita(1-saída 2- Estorno) 
           e realiza a operação (+/-) baseada nisso. 
        */

        public bool OutputValidation(Output output)
        {
            var obj = _inventoryRepository.GetInventory();
            foreach (var item in obj)
            {
                if (item.ProductId == output.ProductId && item.CompanyId == output.CompanyId) // Verifica se existe o estoque.
                {
                    switch (output.OutputStatus)
                    {
                        case Output.OutputType.outputOk: // Caso seja saída.
                            if(ValidationQuantity(output) == true && ValidationQuantityInInventory(output) == true) // Validações de quantidade.
                            {
                                item.TotalQuantity -= output.Quantity; // Retira do estoque
                                return true;
                            }
                            break;
                        case Output.OutputType.reversal:  // Caso seja estorno.
                            if (ValidationQuantity(output) == true) // Validação de quantidade.
                            {
                                item.TotalQuantity += output.Quantity; // devolve ao estoque;
                                return true;
                            }
                            break;
                        default: 
                            return false;
                         
                    }
                }
                
            }
            return false;
        }
        
        // Método de buscar os produtos que saíram pelo seu nome.
        public Product GetProductByNameInOutput(string nameProduct)
        {
            var product = _productRepository.GetProductByName(nameProduct.ToUpper());
            var answer = _outputRepository.GetProductByIdInOutput(product.IdProduct);
            if (answer == null) { return null; } else { return product; }

        }
    }
}
