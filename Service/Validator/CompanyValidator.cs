using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validator
{
    // Validação das propriedades de empresa.
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.NameCompany)
                .NotEmpty().WithMessage("Por favor, insira o nome da Empresa.")
                .NotNull().WithMessage("Por favor, insira o nome da Empresa.");
        }
    }
}
