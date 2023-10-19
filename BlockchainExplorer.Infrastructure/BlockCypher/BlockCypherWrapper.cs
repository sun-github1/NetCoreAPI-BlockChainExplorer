using BlockchainExplorer.Application.Contracts.Infrastructure;
using System.Net.Http;
using BlockchainExplorer.Application.Models;
using BlockchainExplorer.Domain.Common;
using BlockchainExplorer.Domain.Enitites;
using BlockchainExplorer.Domain.Enums;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
                url)
            { };
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

                //mock responses
                //var responsemockclass = new BlockCypherResponse()
                //{
                //    name = coinType == CoinType.btc ? "BTC.main": (coinType == CoinType.eth ? "ETH.main" : "DASH.main"),
                //    hash = "00000000000000000003762b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03fdc",
                //    height = 81242,
                //    time = DateTime.UtcNow,
                //    latest_url = @"https://api.blockcypher.com/v1/btc/main/blocks/00000000000000000003762b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03fdc",
                //    previous_hash = "0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                //    previous_url = "https://api.blockcypher.com/v1/btc/main/blocks/0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                //    peer_count = 324,
                //    unconfirmed_count = 7234,
                //    high_fee_per_kb = 16971,
                //    medium_fee_per_kb = 9322,
                //    low_fee_per_kb = 6041,
                //    last_fork_height = 804900,
                //    last_fork_hash = "00000000000000000004c20bfe0ed1a9b714fbc07710531b8252dc998f9ccd67"
                //};
                var responsemockclass = new BlockCypherResponse()
                {
                    hash = "000000000000000000bf56ff4a81e399374a68344a64d6681039412de78366b8",
                    height = 360060,
                    high_fee_per_kb = 46086,
                    last_fork_hash = "00000000000000000aa6462fd9faf94712ce1b5a944dc666f491101c996beab9",
                    last_fork_height = 0,
                    latest_url = "",
                    low_fee_per_kb = 0,
                    medium_fee_per_kb = 29422,
                    name = coinType == CoinType.btc ? "BTC.main" : (coinType == CoinType.eth ? "ETH.main" : "DASH.main"),
                    peer_count = 239,
                    previous_hash = "000000000000000011c9511ae1265d34d3c16fff6e8f94380425833b3d0ae5d8",
                    previous_url = "https://api.blockcypher.com/v1/btc/main/blocks/000000000000000011c9511ae1265d34d3c16fff6e8f94380425833b3d0ae5d8",
                    time = new DateTime(2023, 10, 16),
                    unconfirmed_count = 617
                };

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
    }
}
