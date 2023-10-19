using BlockchainExplorer.Application.DTOs.Common;
using BlockchainExplorer.Domain.Enums;


namespace BlockchainExplorer.Application.DTOs
{
    public class AvailableBlockchainDto: BaseDto
    {
        public CoinType CoinType { get; set; }
        public BlockCypherResponseDto Response { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
