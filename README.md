# DBL.NET [![](https://img.shields.io/nuget/v/DBL.Net.svg?style=for-the-badge)](https://www.nuget.org/packages/DBL.Net)
A .NET standard wrapper around the Discord Bot List API. Because the API methods are not `async`, you do *not* need to use these in `async` functions, and you may use the `.Wait()` method of the Task the methods return, however it is not recommended because of the possibility of deadlocks.

# Usage
Create a new instance of the API:
```cs
var dblApi = new DBLAPI("<DBL token here>");
```
Get a bot:
```cs
var bot = await dblApi.GetBot("<Bot ID here>");
```
This method returns a <a href="https://github.com/LewisTehMinerz/DBL.NET/blob/master/DBL.Net/Entities/Bot.cs">Bot</a> object.

Get a user:
```cs
var user = await dblApi.GetUser("<User ID here>");
```
This method returns a <a href="https://github.com/LewisTehMinerz/DBL.NET/blob/master/DBL.Net/Entities/User.cs">User</a> object.

Search for bots:
```cs
var searchResults = await dblApi.SearchBots(search: "<Search query here>");
```
This method returns a <a href="https://github.com/LewisTehMinerz/DBL.NET/blob/master/DBL.Net/Entities/SearchResults.cs">SearchResults</a> object.

Get the vote count for a bot:
```cs
var voteCount = await dblApi.GetVotes("<Bot ID here>");
```
This method returns a <a href="https://github.com/LewisTehMinerz/DBL.NET/blob/master/DBL.Net/Entities/User.cs">User</a> array of everyone who voted.

Get the statistics for a bot:
```cs
var statistics = await dblApi.GetStats("<Bot ID here>");
```
This method returns a <a href="https://github.com/LewisTehMinerz/DBL.NET/blob/master/DBL.Net/Entities/BotStatistics.cs">BotStatistics</a> object.

Update the statistics for a bot:
```cs
var success = await dblApi.PostStats("<Bot ID here>", new BotStatisticsPayload {
  Shards = {
    1337, 420, 69
  },
  ShardId = 0,
  ShardCount = 3
});
```
This method returns a boolean which is whether the statistics were sucessfully updated or not.
