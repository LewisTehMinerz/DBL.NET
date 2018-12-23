using Newtonsoft.Json;

namespace DBL.Net.Entities
{
    /// <summary>
    /// A user.
    /// </summary>
    public class User
    {
        // Non-optional fields

        /// <summary>
        /// The ID of the user.
        /// </summary>
        [JsonProperty("id")]
        public string Id;
        /// <summary>
        /// The username of the user.
        /// </summary>
        [JsonProperty("username")]
        public string Username;
        /// <summary>
        /// The discriminator of the user.
        /// </summary>
        [JsonProperty("discriminator")]
        public string Discriminator;
        /// <summary>
        /// The CDN hash of the user's avatar if the user has none.
        /// </summary>
        [JsonProperty("defAvatar")]
        public string DefaultAvatarHash;
        /// <summary>
        /// Whether or not the user is a certified developer.
        /// </summary>
        [JsonProperty("certifiedDev")]
        public bool IsCertified;
        /// <summary>
        /// Whether or not the user is a moderator.
        /// </summary>
        [JsonProperty("mod")]
        public bool IsMod;
        /// <summary>
        /// Whether or not the user is a web moderator.
        /// </summary>
        [JsonProperty("webMod")]
        public bool IsWebMod;
        /// <summary>
        /// Whether or not the user is an administrator.
        /// </summary>
        [JsonProperty("admin")]
        public bool IsAdmin;

        // Optional fields

        /// <summary>
        /// The avatar hash of the user. Can be null.
        /// </summary>
        [JsonProperty("avatar")]
        public string AvatarHash;
        /// <summary>
        /// The bio of the user. Can be null.
        /// </summary>
        [JsonProperty("bio")]
        public string Bio;
        /// <summary>
        /// The banner URL of the user. Can be null.
        /// </summary>
        [JsonProperty("banner")]
        public string BannerUrl;
        /// <summary>
        /// The social connections of the user. Can be null. See <see cref="SocialConnections"/> for information about fields.
        /// </summary>
        [JsonProperty("social")]
        public SocialConnections Social;
        /// <summary>
        /// The hex color on the user's profile. Can be null.
        /// </summary>
        [JsonProperty("color")]
        public string Color;
    }
}
