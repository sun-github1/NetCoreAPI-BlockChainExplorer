using BlockchainExplorer.Domain.Common;
using BlockchainExplorer.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace BlockchainExplorer.Domain.Enitites
{
    public class AvailableBlockchain: BaseEntity
    {
        [Required]
        public string HashId { get; set; }
        [Required]
        public CoinType CoinType { get; set; }
        public BlockCypherResponse Response { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
