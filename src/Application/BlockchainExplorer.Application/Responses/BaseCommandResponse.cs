namespace BlockchainExplorer.Application.Responses
{
    public class BaseCommandResponse
    {
        public bool Success { get; set; } = true;
        public List<string> Errors { get; set; }
    }
}
