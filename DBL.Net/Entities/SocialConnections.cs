using Newtonsoft.Json;
// ReSharper disable IdentifierTypo CommentTypo StringLiteralTypo

namespace DBL.Net.Entities
{
    /// <summary>
    /// Social connections of a <see cref="User"/>.
    /// </summary>
    public class SocialConnections
    {
        /// <summary>
        /// The YouTube channel ID of the user. Can be null.
        /// </summary>
        [JsonProperty("youtube")]
        public string YouTube;
        /// <summary>
        /// The Reddit username of the user. Can be null.
        /// </summary>
        [JsonProperty("reddit")]
        public string Reddit;
        /// <summary>
        /// The Twitter username of the user. Can be null.
        /// </summary>
        [JsonProperty("twitter")]
        public string Twitter;
        /// <summary>
        /// The Instagram username of the user. Can be null.
        /// </summary>
        [JsonProperty("instagram")]
        public string Instagram;
        /// <summary>
        /// The GitHub username of the user. Can be null.
        /// </summary>
        [JsonProperty("github")]
        public string GitHub;
    }
}