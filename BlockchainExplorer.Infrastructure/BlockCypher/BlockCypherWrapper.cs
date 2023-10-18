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

namespace BlockchainExplorer.Infrastructure.BlockCypher
{
    public class BlockCypherWrapper : IBlockCypherWrapper
    {
        private BlockCypherSettings _blockCypherSettings { get; }
        private readonly IHttpClientFactory _httpClientFactory;
        public BlockCypherWrapper(IOptions<BlockCypherSettings> blockCypherSettings,
            IHttpClientFactory httpClientFactory)
        {
            _blockCypherSettings = blockCypherSettings.Value;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<BlockCypherResponse> GetAvaialableBlockChainFromBlockCypherAPI(CoinType coinType)
        {
            var httpClient = _httpClientFactory.CreateClient();//https://api.blockcypher.com/v1
            string url = $"{_blockCypherSettings.BaseUrl}/{coinType.ToString()}/main?token={_blockCypherSettings.Token}";

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                url){};
            //var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            //if (httpResponseMessage.IsSuccessStatusCode)
            //{
            //using var contentStream =
            //    await httpResponseMessage.Content.ReadAsStreamAsync();
            //var response = await JsonSerializer.DeserializeAsync
            //        <BlockCypherResponse>(contentStream);
            var responsemockclass = new BlockCypherResponse()
            {
                name = "BTC.main",
                hash = "00000000000000000003762b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03fdc",
                height = 81242,
                time = DateTime.UtcNow,
                latest_url = @"https://api.blockcypher.com/v1/btc/main/blocks/00000000000000000003762b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03fdc",
                previous_hash = "0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                previous_url = "https://api.blockcypher.com/v1/btc/main/blocks/0000000000000000000221a3a70b2d9184cc13734f0589f8f5119edee6dabec2",
                peer_count = 324,
                unconfirmed_count = 7234,
                high_fee_per_kb = 16971,
                medium_fee_per_kb = 9322,
                low_fee_per_kb = 6041,
                last_fork_height = 804900,
                last_fork_hash = "00000000000000000004c20bfe0ed1a9b714fbc07710531b8252dc998f9ccd67"
            };

            string jsonString = JsonConvert.SerializeObject(responsemockclass);
            // convert string to stream
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
            MemoryStream stream = new MemoryStream(byteArray);
            var response = JsonConvert.DeserializeObject
                    <BlockCypherResponse>(jsonString);
            //var newblockChain = new AvailableBlockchain
            //{
            //    CoinType = coinType,
            //    CreatedAt = DateTime.UtcNow,
            //    HashId = response.hash,
            //    Response = response
            //};
            //var result = await _unitOfWork.BlockChain.AddAsync(newblockChain);
            //_unitOfWork.Save();

            return response;
            //}
            //return null;
        }
    }
}
