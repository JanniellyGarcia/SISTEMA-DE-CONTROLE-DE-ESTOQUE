using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validator
{
    public class InventoryValidator : AbstractValidator<Inventory>
    {
        public InventoryValidator()
        {
            RuleFor(x => x.StartingQuantity)
                .NotEmpty().WithMessage("Por favor, insira a quantidade inicial.")
                .NotNull().WithMessage("Por favor, insira a quantidade.");
        }
    
    }
}
