using BlockchainExplorer.Application.DTOs;

namespace BlockchainExplorer.Application.Responses
{
    public class GetAvailableBlockchainHistoryResponse : BaseCommandResponse
    {
        public List<AvailableBlockchainDto> Data { get; set; }
    }
}
