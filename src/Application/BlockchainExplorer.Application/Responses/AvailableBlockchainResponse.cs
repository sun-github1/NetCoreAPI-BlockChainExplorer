using BlockchainExplorer.Application.DTOs;

namespace BlockchainExplorer.Application.Responses
{
    public class AvailableBlockchainResponse: BaseCommandResponse
    {
        public AvailableBlockchainDto Data { get; set; }
    }
}
