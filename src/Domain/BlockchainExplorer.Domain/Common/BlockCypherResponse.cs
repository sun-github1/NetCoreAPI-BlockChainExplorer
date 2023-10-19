using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlockchainExplorer.Domain.Common
{

    [NotMapped]
    public class BlockCypherResponse
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("height")]
        public int height { get; set; }
        [JsonProperty("hash")]
        public string hash { get; set; }
        [JsonProperty("time")]
        public DateTime time { get; set; }
        [JsonProperty("latest_url")]
        public string latest_url { get; set; }
        [JsonProperty("previous_hash")]
        public string previous_hash { get; set; }
        [JsonProperty("previous_url")]
        public string previous_url { get; set; }
        [JsonProperty("peer_count")]
        public int peer_count { get; set; }
        [JsonProperty("unconfirmed_count")]
        public int unconfirmed_count { get; set; }
        [JsonProperty("high_fee_per_kb")]
        public int high_fee_per_kb { get; set; }
        [JsonProperty("medium_fee_per_kb")]
        public int medium_fee_per_kb { get; set; }
        [JsonProperty("low_fee_per_kb")]
        public int low_fee_per_kb { get; set; }
        [JsonProperty("last_fork_height")]
        public int last_fork_height { get; set; }
        [JsonProperty("last_fork_hash")]
        public string last_fork_hash { get; set; }
    }
}
