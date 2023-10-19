using BlockchainExplorer.Domain.Enums;
using FluentValidation;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.DTOs.Validators
{
    public class CoinTypeValidator : AbstractValidator<string>
    {
        public CoinTypeValidator()
        {
            RuleFor(p => p.ToString())
                .NotEmpty().WithMessage("Coin Type should not be empty")
                .NotNull().WithMessage("Coin Type should not be null or empty")
                .MaximumLength(4).WithMessage("Coin Type can be max of 4 characters")
                .MinimumLength(3).WithMessage("Coin Type should be min of of 3 characters")
                .Must(x=> Enum.TryParse(x, true, out CoinType resultCointType)==true).WithMessage("Only btc, eth, dash coin types are supported");
        }
    }
}
