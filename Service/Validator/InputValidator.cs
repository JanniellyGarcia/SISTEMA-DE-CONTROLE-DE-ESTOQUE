using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validator
{
    // Validação das propriedades de saída.
    public class InputValidator : AbstractValidator<Input>
    {
        public InputValidator()
        {
            RuleFor(c => c.Quantity)
               .NotEmpty().WithMessage("Por favor, insira uma quantidade válida.")
               .NotNull().WithMessage("Por favor, insira uma quantidade válida.");
        }
    }
}


