/*
 * Copyright 2015 Google Inc. All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 *
 */

using System.IO;
using System.Linq;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace Google.Apis.YouTube.Samples.Search
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
  /// YouTube Data API v3 sample: search by keyword.
  /// Relies on the Google APIs Client Library for .NET, v1.7.0 or higher.
  /// See https://code.google.com/p/google-api-dotnet-client/wiki/GettingStarted
  ///
  /// Set ApiKey to the API key value from the APIs & auth > Registered apps tab of
  ///   https://cloud.google.com/console
  /// Please ensure that you have enabled the YouTube Data API for your project.
  /// </summary>
  internal class Search
  {
    [STAThread]
    static void Main()
    {
      Console.WriteLine("YouTube Data API: Search");
      Console.WriteLine("========================");

      try
      {
        new Search().Run().Wait();
      }
      catch (AggregateException ex)
      {
        foreach (var e in ex.InnerExceptions)
        {
          Console.WriteLine("Error: " + e.Message);
        }
      }

      Console.WriteLine("Press any key to continue...");
      Console.ReadKey();
    }

    private async Task Run()
    {
      var apiKey = File.ReadLines("google_api_key.txt").First();
      var youtubeService = new YouTubeService(new BaseClientService.Initializer
                                                  {
        ApiKey = apiKey,
        ApplicationName = GetType().ToString()
      });

      var searchListRequest = youtubeService.Search.List("snippet");
      searchListRequest.Q = "Google"; // Replace with your search term.
      searchListRequest.MaxResults = 50;

      // Call the search.list method to retrieve results matching the specified query term.
      var searchListResponse = await searchListRequest.ExecuteAsync();

      List<string> videos = new List<string>();
      List<string> channels = new List<string>();
      List<string> playlists = new List<string>();

      // Add each result to the appropriate list, and then display the lists of
      // matching videos, channels, and playlists.
      foreach (var searchResult in searchListResponse.Items)
      {
        switch (searchResult.Id.Kind)
        {
          case "youtube#video":
            videos.Add($"{searchResult.Snippet.Title} ({searchResult.Id.VideoId})");
            break;

          case "youtube#channel":
            channels.Add($"{searchResult.Snippet.Title} ({searchResult.Id.ChannelId})");
            break;

          case "youtube#playlist":
            playlists.Add($"{searchResult.Snippet.Title} ({searchResult.Id.PlaylistId})");
            break;
        }
      }

      Console.WriteLine("Videos:\n{0}\n", string.Join("\n", videos));
      Console.WriteLine("Channels:\n{0}\n", string.Join("\n", channels));
      Console.WriteLine("Playlists:\n{0}\n", string.Join("\n", playlists));
    }
  }
}
