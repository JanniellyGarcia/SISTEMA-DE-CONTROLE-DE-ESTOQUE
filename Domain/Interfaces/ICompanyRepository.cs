using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    // Interface do Repositório de Empresa.
    public interface ICompanyRepository
    {
        //listar todas as empresas
        IEnumerable<Company> GetCompany();

        //retornar a empresa pelo seu id
        Company GetCompanyById(int id); 

        //retornar a empresa pelo seu nome.
        Company GetCompanyByName(string name);


    }
}
