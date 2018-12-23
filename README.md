# DBL.NET
A .NET standard wrapper around the Discord Bot List API.

# Usage
Create a new instance of the API:
```cs
var dblApi = new DBLAPI("<DBL token here>");
```
Get a bot:
```cs
var bot = dblApi.GetBot("<Bot ID here>");
```
This method returns a <a href="https://github.com/LewisTehMinerz/DBL.NET/blob/master/DBL.Net/Entities/Bot.cs">Bot</a> object.

Get a user:
```cs
var user = dblApi.GetUser("<User ID here>");
```
This method returns a <a href="https://github.com/LewisTehMinerz/DBL.NET/blob/master/DBL.Net/Entities/User.cs">User</a> object.

Search for bots:
```cs
var searchResults = dblApi.SearchBots(search: "<Search query here>");
```
This method returns a <a href="https://github.com/LewisTehMinerz/DBL.NET/blob/master/DBL.Net/Entities/SearchResults.cs">SearchResults</a> object.

Get the vote count for a bot:
```cs
var voteCount = dblApi.GetVotes("<Bot ID here>");
```
This method returns a <a href="https://github.com/LewisTehMinerz/DBL.NET/blob/master/DBL.Net/Entities/User.cs">User</a> array of everyone who voted.

Get the statistics for a bot:
```cs
var statistics = dblApi.GetStats("<Bot ID here>");
```
This method returns a <a href="https://github.com/LewisTehMinerz/DBL.NET/blob/master/DBL.Net/Entities/BotStatistics.cs">BotStatistics</a> object.

Update the statistics for a bot:
```cs
var success = dblApi.PostStats("<Bot ID here>", new BotStatisticsPayload {
  Shards = {
    1337, 420, 69
  },
  ShardId = 0,
  ShardCount = 3
});
```
This method returns a boolean which is whether the statistics were sucessfully updated or not.
