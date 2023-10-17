using BlockchainExplorer.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.DTOs.Validators
{
    public class CoinTypeValidator : AbstractValidator<CoinType>
    {
        public CoinTypeValidator()
        {
            RuleFor(p => p.ToString())
                .NotEmpty().WithMessage("Coin Type should not be empty")
                .NotNull()
                .Must(x => x.Equals(CoinType.btc.ToString())
                || x.Equals(CoinType.eth.ToString()) || x.Equals(CoinType.dash.ToString())).WithMessage("Only bth, eth, dash are supported");
        }
    }
}
