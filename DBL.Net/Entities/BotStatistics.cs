using Newtonsoft.Json;

namespace DBL.Net.Entities
{
    /// <summary>
    /// A bot statistics object.
    /// </summary>
    public class BotStatistics
    {
        /// <summary>
        /// The amount of servers the bot is in.
        /// </summary>
        [JsonProperty("server_count")]
        public int ServerCount;
        /// <summary>
        /// The amount of servers the bot is in per shard. Always present, however can be empty.
        /// </summary>
        [JsonProperty("shards")]
        public int[] ServersPerShard;
        /// <summary>
        /// The amount of shards the bot has.
        /// </summary>
        [JsonProperty("shard_count")]
        public int ShardCount;
    }
}
