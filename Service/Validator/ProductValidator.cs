using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(c => c.NameProduct)
                .NotEmpty().WithMessage("Por favor, insira o nome do produto.")
                .NotNull().WithMessage("Por favor, insira o nome do produto.");
        }

    }
}
