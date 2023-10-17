using BlockchainExplorer.Application.Contracts.Persistence;
using BlockchainExplorer.Domain.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockchainExplorer.Application.DTOs.Validators
{
    public class HashIdValidator : AbstractValidator<string>
    {
        private readonly IBlockChainRepository _blockChainRepository;
        public HashIdValidator(IBlockChainRepository blockChainRepository) {

            _blockChainRepository = blockChainRepository;
            RuleFor(p => p)
                   .NotEmpty().WithMessage("HashId should not be empty")
                   .NotNull()
                   .MustAsync(async (id, token) => {
                       var hashExists = await _blockChainRepository.GetAsync(i=>i.HashId==id);
                       return hashExists!=null;
                   })
                .WithMessage("BlockChain does not exist with this hashid.");
        }
    }
}
