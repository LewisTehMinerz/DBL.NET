using System;
using Newtonsoft.Json;

namespace DBL.Net.Entities
{
    /// <summary>
    /// Search results from the <code>/bots/</code> endpoint.
    /// </summary>
    public class SearchResults
    {
        /// <summary>
        /// The matching bots from the query.
        /// </summary>
        [JsonProperty("results")]
        public Bot[] Bots;
        /// <summary>
        /// The limit used.
        /// </summary>
        [JsonProperty("limit")]
        public int Limit;
        /// <summary>
        /// The offset used.
        /// </summary>
        [JsonProperty("offset")]
        public int Offset;
        /// <summary>
        /// The length of the results array. Not recommended for use, use <code>Bots.Length</code>.
        /// </summary>
        [JsonProperty("count")]
        [Obsolete("Use Bots.Length.")]
        public int Amount;
        /// <summary>
        /// The total number of bots matching your search. Not recommended for use, use <code>Bots.Length</code>.
        /// </summary>
        [JsonProperty("total")]
        [Obsolete("Use Bots.Length.")]
        public int Total;
    }
}
