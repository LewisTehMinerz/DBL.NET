using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Linq;

using DBL.Net.Entities;
using System.Collections.Generic;
using System.Text;

namespace DBL.Net
{
    /// <summary>
    /// The DBL API.
    /// </summary>
    public class DBLAPI
    {
        // Variables for internal use.
        internal readonly HttpClient _client;
        internal readonly string _apiToken;
        internal readonly string dblApiUrl = "https://discordbots.org/api/";

        /// <summary>
        /// Creates a new instance of the DBL API.
        /// </summary>
        /// <param name="apiToken">The API token for the bot on DBL.</param>
        public DBLAPI(string apiToken)
        {
            _client = new HttpClient();
            _apiToken = apiToken;
            _client.BaseAddress = new Uri(dblApiUrl);
        }

        /// <summary>
        /// Internal function for making web requests to the API easier.
        /// </summary>
        /// <param name="endpoint">The endpoint to send the request to.</param>
        /// <param name="method">The method to use for the request.</param>
        /// <param name="queryString">The query string to add on to the request.</param>
        /// <typeparam name="T">The class to serialise the result from the request to.</typeparam>
        /// <returns>The class with serialised data.</returns>
        private async Task<T> MakeRequest<T>(string endpoint, HttpMethod method, Dictionary<string, object> queryString = null,
            BotStatisticsPayload botStatistics = null)
        {
            var formattedQs = "";
            var contentStr = "";
            if (queryString != null)
            {
                var keyValuePairs = queryString.Select(
                    x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value.ToString())}");
                formattedQs = $"?{string.Join("&", keyValuePairs)}";
            }

            if (botStatistics != null)
            {
                contentStr = JsonConvert.SerializeObject(botStatistics);
            }

            var result = await _client.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri(endpoint + formattedQs),
                Method = method,
                Headers =
                {
                    { HttpRequestHeader.Authorization.ToString(), _apiToken },
                    { HttpRequestHeader.Accept.ToString(), "application/json" }
                },
                Content = new StringContent(contentStr, Encoding.UTF8, "application/json")
            });

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                T serialized = JsonConvert.DeserializeObject<T>(content);
                return serialized;
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// Internal function for making web requests to the API easier, without a return type.
        /// </summary>
        /// <param name="endpoint">The endpoint to send the request to.</param>
        /// <param name="method">The method to use for the request.</param>
        /// <param name="queryString">The query string to add on to the request.</param>
        private async Task<bool> MakeRequest(string endpoint, HttpMethod method, Dictionary<string, object> queryString = null,
            BotStatisticsPayload botStatistics = null)
        {
            var formattedQs = "";
            var contentStr = "";
            if (queryString != null)
            {
                var keyValuePairs = queryString.Select(
                    x => $"{Uri.EscapeDataString(x.Key)}={Uri.EscapeDataString(x.Value.ToString())}");
                formattedQs = $"?{string.Join("&", keyValuePairs)}";
            }

            if (botStatistics != null)
            {
                contentStr = JsonConvert.SerializeObject(botStatistics);
            }

            var result = await _client.SendAsync(new HttpRequestMessage
            {
                RequestUri = new Uri(endpoint + formattedQs),
                Method = method,
                Headers =
                {
                    { HttpRequestHeader.Authorization.ToString(), _apiToken },
                    { HttpRequestHeader.Accept.ToString(), "application/json" }
                },
                Content = new StringContent(contentStr, Encoding.UTF8, "application/json")
            });

            return result.IsSuccessStatusCode;
        }

        /// <summary>
        /// Gets information about a user.
        /// </summary>
        /// <param name="id">The ID of the user you would like to retrieve.</param>
        /// <returns>A <see cref="User"/> object.</returns>
        public Task<User> GetUser(string id) => MakeRequest<User>("/users/" + id, HttpMethod.Get);

        /// <summary>
        /// Searches DBL for bots.
        /// </summary>
        /// <param name="limit">The amount of bots to return. The maximum value is 500.</param>
        /// <param name="offset">The amount of bots to skip.</param>
        /// <param name="search">A search string in the format of <code>field: value field2: value2</code>.</param>
        /// <param name="sort">The field to sort by. Prefix with <code>-</code> to reverse the order.</param>
        /// <param name="fields">A comma separated list of fields to show. This is all fields by default.</param>
        /// <returns>A <see cref="SearchResults"/> object.</returns>
        public Task<SearchResults> SearchBots(int limit = 50, int offset = 0, string search = "", string sort = "",
            string fields = "") => MakeRequest<SearchResults>("/bots/", HttpMethod.Get, queryString: new Dictionary<string, object>
            {
                { "limit", limit }, { "offset", offset }, { "search", search }, { "sort", sort }, { "fields", fields }
            });

        /// <summary>
        /// Gets information about a bot.
        /// </summary>
        /// <param name="id">The ID of the bot you would like to retrieve.</param>
        /// <returns>A <see cref="Bot"/> object.</returns>
        public Task<Bot> GetBot(string id) => MakeRequest<Bot>("/bots/" + id, HttpMethod.Get);

        /// <summary>
        /// Gets the users that have upvoted a bot.
        /// <b>If the bot you are looking up has over 1000 votes per month, you cannot use this endpoint.</b>
        /// </summary>
        /// <param name="id">The ID of the bot you would like to get the votes for.</param>
        /// <returns>An array of <see cref="User"/> objects.</returns>
        public Task<User[]> GetVotes(string id) => MakeRequest<User[]>("/bots/" + id + "/votes", HttpMethod.Get);

        /// <summary>
        /// Gets the statistics of a bot.
        /// </summary>
        /// <param name="id">The ID of the bot you would like to get the statistics for.</param>
        /// <returns>A <see cref="BotStatistics"/> object.</returns>
        public Task<BotStatistics> GetStats(string id) => MakeRequest<BotStatistics>("/bots/" + id + "/stats", HttpMethod.Get);

        /// <summary>
        /// Updates the statistics of a bot.
        /// </summary>
        /// <param name="id">The ID of the bot you would like to update the statistics for.</param>
        /// <param name="payload">A <see cref="BotStatisticsPayload"/> object.</param>
        /// <returns>Whether or not the statistics were successfully updated.</returns>
        public Task<bool> PostStats(string id, BotStatisticsPayload payload)
            => MakeRequest("/bots/" + id + "/stats", HttpMethod.Post, botStatistics: payload);
    }
}
