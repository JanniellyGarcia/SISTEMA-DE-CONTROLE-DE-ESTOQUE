using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    // Interface de Serviço de Empresa.
    public interface ICompanyService
    {
        IEnumerable<CompanyViewModel> GetCompany();
        public bool ValidationAddCompany(string name, int id);

    }
}
