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
    public class CompanyService : ICompanyService
    {
        private readonly IBaseRepository<Company> _baseRepository;
        private ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        public CompanyService(IBaseRepository<Company> baseRepository, IMapper mapper, ICompanyRepository companyRepository)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
            _companyRepository = companyRepository;
        }
        public IEnumerable<CompanyViewModel> GetCompany()
        {
            var company = _companyRepository.GetCompany();
            return _mapper.Map<IEnumerable<CompanyViewModel>>(company);
        }

        public bool ValidationAddCompany(string name, int id)
        {
            var CheckByName = _companyRepository.GetCompanyByName(name.ToUpper());
            if (CheckByName == null || CheckByName.IdCompany == id) { return true; }
            return false;
        }
    }
}
