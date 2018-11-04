﻿// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.I18nLanguage
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using Google.Apis.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api
{
  /// <summary>An i18nLanguage resource identifies a UI language currently supported by YouTube.</summary>
  public class I18nLanguage : IDirectResponseSchema
  {
    /// <summary>Etag of this resource.</summary>
    [JsonProperty("etag")]
    public virtual string ETag { get; set; }

    /// <summary>The ID that YouTube uses to uniquely identify the i18n language.</summary>
    [JsonProperty("id")]
    public virtual string Id { get; set; }

    /// <summary>Identifies what kind of resource this is. Value: the fixed string "youtube#i18nLanguage".</summary>
    [JsonProperty("kind")]
    public virtual string Kind { get; set; }

    /// <summary>The snippet object contains basic details about the i18n language, such as language code and human-
    /// readable name.</summary>
    [JsonProperty("snippet")]
    public virtual I18nLanguageSnippet Snippet { get; set; }
  }
}
