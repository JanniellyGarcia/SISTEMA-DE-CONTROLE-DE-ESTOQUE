using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validator
{
    public class OutputValidator : AbstractValidator<Output>
    {
        public OutputValidator()
        {
            RuleFor(x=>x.OutputStatus)
                .NotEmpty().WithMessage("Por favor, insira o tipo de saída.")
                .NotNull().WithMessage("Por favor, insira o tipo de saída.");
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Por favor, insira a quantidade.")
                .NotNull().WithMessage("Por favor, insira a quantidade.");
        }
    }
}
