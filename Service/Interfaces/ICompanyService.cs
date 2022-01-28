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
        // Chamada para o método de listar as empresas.
        IEnumerable<CompanyViewModel> GetCompany();

        // Chamada para o método de validar a empresa (Não pode existir duas empresas com o mesmo nome.)
        public bool ValidationAddCompany(string name, int id);

    }
}
