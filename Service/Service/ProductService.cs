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
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _baseRepository;
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IBaseRepository<Product> baseRepository, IMapper mapper, IProductRepository productRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }
        public IEnumerable<ProductViewModel> GetProduct()
        {
            var product = _productRepository.GetProduct();
            return _mapper.Map<IEnumerable<ProductViewModel>>(product);

        }

        // Não será possível adicionar produtos com o menos nome a menos que o id seja iguail (facilitar a edição, pois nela, o id não muda).
        public bool ValidationAddProduct(string name, int id)
        {
           var CheckByName = _productRepository.GetProductByName(name.ToUpper());
           if (CheckByName == null || CheckByName.IdProduct == id){return true;}
           return false;
        }

        // Buscar um produto no banco pelo sua propriedade de nome.
        public Product GetProductByName(Product product)
        {
            var obj = _productRepository.GetProductByName(product.NameProduct.ToUpper());
            return obj;
        }
    }
}
