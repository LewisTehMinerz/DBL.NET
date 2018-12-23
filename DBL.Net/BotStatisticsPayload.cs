using Newtonsoft.Json;

namespace DBL.Net
{
    /// <summary>
    /// A data class for <see cref="DBLAPI.PostStats(int, int, int, int, int)"/>.
    /// </summary>
    public class BotStatisticsPayload
    {
        /// <summary>
        /// The amount of servers the bot is in.
        /// </summary>
        [JsonProperty("server_count")]
        public int ServerCount;
        /// <summary>
        /// The amount of servers the bot is in per shard.
        /// </summary>
        [JsonProperty("shards")]
        public int[] Shards;
        /// <summary>
        /// The zero-indexed ID of the current shard posting.
        /// </summary>
        [JsonProperty("shard_id")]
        public int ShardId;
        /// <summary>
        /// The total amount of shards the bot has.
        /// </summary>
        [JsonProperty("shard_count")]
        public int ShardCount;
    }
}
