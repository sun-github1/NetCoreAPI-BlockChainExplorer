using BlockchainExplorer.Application.Contracts.Infrastructure;
using BlockchainExplorer.Application.Models;
using BlockchainExplorer.Domain.Common;
using BlockchainExplorer.Domain.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace BlockchainExplorer.Infrastructure.BlockCypher
{
    public class BlockCypherWrapper : IBlockCypherWrapper
    {
        private BlockCypherSettings _blockCypherSettings { get; }
        private ILogger<BlockCypherWrapper> _logger { get; }
        private readonly IHttpClientFactory _httpClientFactory;

        public BlockCypherWrapper(IOptions<BlockCypherSettings> blockCypherSettings,
            IHttpClientFactory httpClientFactory,
            ILogger<BlockCypherWrapper> logger)
        {
            _blockCypherSettings = blockCypherSettings.Value;
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<BlockCypherResponse> GetAvaialableBlockChainFromBlockCypherAPI(CoinType coinType)
        {
            var httpClient = _httpClientFactory.CreateClient();
            string url = $"{_blockCypherSettings.BaseUrl}/{coinType.ToString()}/main?token={_blockCypherSettings.Token}";

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                url)  { };
            try
            {
                //To UnComent BlockCypher if API works
                //var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
                //if (httpResponseMessage.IsSuccessStatusCode)
                //{
                //using var contentStream =
                //    await httpResponseMessage.Content.ReadAsStreamAsync();
                //var response = await JsonSerializer.DeserializeAsync
                //        <BlockCypherResponse>(contentStream);

                //mock response for now
                var responsemockclass = GenerateMockBlockCypherResponse(coinType);

                string jsonString = JsonConvert.SerializeObject(responsemockclass);
                _logger.LogInformation("jsonString is "+ jsonString);
                // convert string to stream
                byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
                MemoryStream stream = new MemoryStream(byteArray);
                var response = JsonConvert.DeserializeObject
                        <BlockCypherResponse>(jsonString);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while calling blockCypher API");
                throw;
            }
        }

        private BlockCypherResponse GenerateMockBlockCypherResponse(CoinType coinType)
        {
            string mockhash = GenerateMockHash(coinType);
            return new BlockCypherResponse()
            {
                hash = mockhash,
                height = 360060,
                high_fee_per_kb = 46086,
                last_fork_hash = "00000000000000000aa6462fd9faf94712ce1b5a944dc666f491101c996beab9",
                last_fork_height = 0,
                latest_url = "",
                low_fee_per_kb = 0,
                medium_fee_per_kb = 29422,
                name = coinType == CoinType.btc ? "BTC.main" : (coinType == CoinType.eth ? "ETH.main" : "DASH.main"),
                peer_count = 239,
                previous_hash = mockhash.Replace('2','3'),
                previous_url = $"https://api.blockcypher.com/v1/btc/main/blocks/{mockhash.Replace('2', '3')}",
                time = new DateTime(2023, 10, 16),
                unconfirmed_count = 617
            };
        }

        private string GenerateMockHash(CoinType coinType)
        {
            string hash = "000000000000000000bf56ff4a81e399374a68344a64d6681039412de78366b8";
            switch(coinType)
            {
                case CoinType.btc:
                    hash = "000000000000000000bt96ff4a81e647824a234177a64d6681039412de1579";
                    break;
                case CoinType.eth:
                    hash = "000000000000000000et85ff4a81e28467a29716a64d6681039412de3647";
                    break;
                case CoinType.dash:
                    hash = "000000000000000000da28ff4a81e69741a79654a64d6681039412de3647";
                    break;
            }
            return hash+coinType.ToString();
        
        }
    }
}
