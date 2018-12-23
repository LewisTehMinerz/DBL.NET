using System;
using Newtonsoft.Json;
// ReSharper disable CommentTypo StringLiteralTypo

namespace DBL.Net.Entities
{
    /// <summary>
    /// A bot.
    /// </summary>
    public class Bot
    {
        // Non-optional fields.

        /// <summary>
        /// The ID of the bot.
        /// </summary>
        [JsonProperty("id")]
        public string Id;
        /// <summary>
        /// The username of the bot.
        /// </summary>
        [JsonProperty("username")]
        public string Username;
        /// <summary>
        /// The discriminator of the bot.
        /// </summary>
        [JsonProperty("discriminator")]
        public string Discriminator;
        /// <summary>
        /// The CDN hash of the bot's avatar if the bot has none.
        /// </summary>
        [JsonProperty("defAvatar")]
        public string DefaultAvatarHash;
        /// <summary>
        /// The library of the bot.
        /// </summary>
        [JsonProperty("lib")]
        public string Library;
        /// <summary>
        /// The prefix of the bot.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix;
        /// <summary>
        /// The short description of the bot.
        /// </summary>
        [JsonProperty("shortdesc")]
        public string ShortDescription;
        /// <summary>
        /// The tags of the bot.
        /// </summary>
        [JsonProperty("tags")]
        public string[] Tags;
        /// <summary>
        /// The owners of the bot.
        /// These are the IDs of the users. See <see cref="DBLAPI.GetUser(string)"/> about getting a user's information.
        /// </summary>
        [JsonProperty("owners")]
        public string[] Owners;
        /// <summary>
        /// The approval date of the bot.
        /// </summary>
        [JsonProperty("date")]
        public DateTime ApprovalDate;
        /// <summary>
        /// Whether or not the bot is certified.
        /// </summary>
        [JsonProperty("certifiedBot")]
        public bool IsCertified;
        /// <summary>
        /// The vote count of the bot.
        /// </summary>
        [JsonProperty("points")]
        public int Votes;

        // Optional fields.

        /// <summary>
        /// The avatar hash of the bot. Can be null.
        /// </summary>
        [JsonProperty("avatar")]
        public string AvatarHash;
        /// <summary>
        /// The long description of the bot. Can be null.
        /// </summary>
        [JsonProperty("longdesc")]
        public string LongDescription;
        /// <summary>
        /// The website of the bot. Can be null.
        /// </summary>
        [JsonProperty("website")]
        public string Website;
        /// <summary>
        /// The support server invite code of the bot. Can be null.
        /// </summary>
        [JsonProperty("support")]
        public string SupportInvite;
        /// <summary>
        /// The GitHub repository link of the bot. Can be null.
        /// </summary>
        [JsonProperty("github")]
        public string GitHub;
        /// <summary>
        /// The custom invite URL of the bot. Can be null.
        /// </summary>
        [JsonProperty("invite")]
        public string CustomInvite;
        /// <summary>
        /// The vanity URL of the bot. Can be null.
        /// </summary>
        [JsonProperty("vanity")]
        public string VanityUrl;
    }
}
