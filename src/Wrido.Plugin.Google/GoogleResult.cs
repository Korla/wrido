﻿using System;
using System.Net;
using Wrido.Core.Queries;
using Wrido.Resources;

namespace Wrido.Plugin.Google
{
  public class GoogleResult : QueryResult
  {
    private static readonly ImageResource Logo = new ImageResource
    {
      Uri = new Uri("/resources/wrido/plugin/google/resources/google.png", UriKind.Relative),
      Alt = "Google",
      Key = ResourceKeys.Icon
    };

    public Uri Uri { get; set; }

    public static GoogleResult Fallback => new GoogleResult
    {
      Title = "Open Google in browser",
      Description = "https://www.google.com",
      Uri = new Uri("https://www.google.com"),
      Resources = new []{ Logo }
    };

    public static GoogleResult SearchResult(string query)
    {
      var googleUrl = new Uri($"http://www.google.com/search?q={WebUtility.UrlEncode(query)}");
      return new GoogleResult
      {
        Title = $"Search Google for '{query}'",
        Description = googleUrl.AbsoluteUri,
        Uri = googleUrl,
        Resources = new[] { Logo }
      };
    }
  }
}
