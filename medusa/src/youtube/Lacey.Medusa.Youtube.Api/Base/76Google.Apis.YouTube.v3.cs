// Decompiled with JetBrains decompiler
// Type: Google.Apis.YouTube.v3.Data.ContentRating
// Assembly: Google.Apis.YouTube.v3, Version=1.36.1.1226, Culture=neutral, PublicKeyToken=4b01fa6e34db77ab
// MVID: E56916E5-79D6-4645-883A-B3D57DB2C10C
// Assembly location: C:\Users\Lacey\AppData\Local\Temp\Jylyxot\d3b8721247\lib\netstandard2.0\Google.Apis.YouTube.v3.dll

using System.Collections.Generic;
using Lacey.Medusa.Common.Api.Base.Requests;
using Newtonsoft.Json;

namespace Lacey.Medusa.Youtube.Api.Base
{
  /// <summary>Ratings schemes. The country-specific ratings are mostly for movies and shows. NEXT_ID: 71</summary>
  internal class ContentRating : IDirectResponseSchema
  {
    /// <summary>The video's Australian Classification Board (ACB) or Australian Communications and Media Authority
    /// (ACMA) rating. ACMA ratings are used to classify children's television programming.</summary>
    [JsonProperty("acbRating")]
    public virtual string AcbRating { get; set; }

    /// <summary>The video's rating from Italy's Autorità per le Garanzie nelle Comunicazioni (AGCOM).</summary>
    [JsonProperty("agcomRating")]
    public virtual string AgcomRating { get; set; }

    /// <summary>The video's Anatel (Asociación Nacional de Televisión) rating for Chilean television.</summary>
    [JsonProperty("anatelRating")]
    public virtual string AnatelRating { get; set; }

    /// <summary>The video's British Board of Film Classification (BBFC) rating.</summary>
    [JsonProperty("bbfcRating")]
    public virtual string BbfcRating { get; set; }

    /// <summary>The video's rating from Thailand's Board of Film and Video Censors.</summary>
    [JsonProperty("bfvcRating")]
    public virtual string BfvcRating { get; set; }

    /// <summary>The video's rating from the Austrian Board of Media Classification (Bundesministerium für
    /// Unterricht, Kunst und Kultur).</summary>
    [JsonProperty("bmukkRating")]
    public virtual string BmukkRating { get; set; }

    /// <summary>Rating system for Canadian TV - Canadian TV Classification System The video's rating from the
    /// Canadian Radio-Television and Telecommunications Commission (CRTC) for Canadian English-language broadcasts.
    /// For more information, see the Canadian Broadcast Standards Council website.</summary>
    [JsonProperty("catvRating")]
    public virtual string CatvRating { get; set; }

    /// <summary>The video's rating from the Canadian Radio-Television and Telecommunications Commission (CRTC) for
    /// Canadian French-language broadcasts. For more information, see the Canadian Broadcast Standards Council
    /// website.</summary>
    [JsonProperty("catvfrRating")]
    public virtual string CatvfrRating { get; set; }

    /// <summary>The video's Central Board of Film Certification (CBFC - India) rating.</summary>
    [JsonProperty("cbfcRating")]
    public virtual string CbfcRating { get; set; }

    /// <summary>The video's Consejo de Calificación Cinematográfica (Chile) rating.</summary>
    [JsonProperty("cccRating")]
    public virtual string CccRating { get; set; }

    /// <summary>The video's rating from Portugal's Comissão de Classificação de Espect´culos.</summary>
    [JsonProperty("cceRating")]
    public virtual string CceRating { get; set; }

    /// <summary>The video's rating in Switzerland.</summary>
    [JsonProperty("chfilmRating")]
    public virtual string ChfilmRating { get; set; }

    /// <summary>The video's Canadian Home Video Rating System (CHVRS) rating.</summary>
    [JsonProperty("chvrsRating")]
    public virtual string ChvrsRating { get; set; }

    /// <summary>The video's rating from the Commission de Contrôle des Films (Belgium).</summary>
    [JsonProperty("cicfRating")]
    public virtual string CicfRating { get; set; }

    /// <summary>The video's rating from Romania's CONSILIUL NATIONAL AL AUDIOVIZUALULUI (CNA).</summary>
    [JsonProperty("cnaRating")]
    public virtual string CnaRating { get; set; }

    /// <summary>Rating system in France - Commission de classification cinematographique</summary>
    [JsonProperty("cncRating")]
    public virtual string CncRating { get; set; }

    /// <summary>The video's rating from France's Conseil supérieur de l?audiovisuel, which rates broadcast
    /// content.</summary>
    [JsonProperty("csaRating")]
    public virtual string CsaRating { get; set; }

    /// <summary>The video's rating from Luxembourg's Commission de surveillance de la classification des films
    /// (CSCF).</summary>
    [JsonProperty("cscfRating")]
    public virtual string CscfRating { get; set; }

    /// <summary>The video's rating in the Czech Republic.</summary>
    [JsonProperty("czfilmRating")]
    public virtual string CzfilmRating { get; set; }

    /// <summary>The video's Departamento de Justiça, Classificação, Qualificação e Títulos (DJCQT - Brazil)
    /// rating.</summary>
    [JsonProperty("djctqRating")]
    public virtual string DjctqRating { get; set; }

    /// <summary>Reasons that explain why the video received its DJCQT (Brazil) rating.</summary>
    [JsonProperty("djctqRatingReasons")]
    public virtual IList<string> DjctqRatingReasons { get; set; }

    /// <summary>Rating system in Turkey - Evaluation and Classification Board of the Ministry of Culture and
    /// Tourism</summary>
    [JsonProperty("ecbmctRating")]
    public virtual string EcbmctRating { get; set; }

    /// <summary>The video's rating in Estonia.</summary>
    [JsonProperty("eefilmRating")]
    public virtual string EefilmRating { get; set; }

    /// <summary>The video's rating in Egypt.</summary>
    [JsonProperty("egfilmRating")]
    public virtual string EgfilmRating { get; set; }

    /// <summary>The video's Eirin (映倫) rating. Eirin is the Japanese rating system.</summary>
    [JsonProperty("eirinRating")]
    public virtual string EirinRating { get; set; }

    /// <summary>The video's rating from Malaysia's Film Censorship Board.</summary>
    [JsonProperty("fcbmRating")]
    public virtual string FcbmRating { get; set; }

    /// <summary>The video's rating from Hong Kong's Office for Film, Newspaper and Article
    /// Administration.</summary>
    [JsonProperty("fcoRating")]
    public virtual string FcoRating { get; set; }

    /// <summary>This property has been deprecated. Use the contentDetails.contentRating.cncRating
    /// instead.</summary>
    [JsonProperty("fmocRating")]
    public virtual string FmocRating { get; set; }

    /// <summary>The video's rating from South Africa's Film and Publication Board.</summary>
    [JsonProperty("fpbRating")]
    public virtual string FpbRating { get; set; }

    /// <summary>Reasons that explain why the video received its FPB (South Africa) rating.</summary>
    [JsonProperty("fpbRatingReasons")]
    public virtual IList<string> FpbRatingReasons { get; set; }

    /// <summary>The video's Freiwillige Selbstkontrolle der Filmwirtschaft (FSK - Germany) rating.</summary>
    [JsonProperty("fskRating")]
    public virtual string FskRating { get; set; }

    /// <summary>The video's rating in Greece.</summary>
    [JsonProperty("grfilmRating")]
    public virtual string GrfilmRating { get; set; }

    /// <summary>The video's Instituto de la Cinematografía y de las Artes Audiovisuales (ICAA - Spain)
    /// rating.</summary>
    [JsonProperty("icaaRating")]
    public virtual string IcaaRating { get; set; }

    /// <summary>The video's Irish Film Classification Office (IFCO - Ireland) rating. See the IFCO website for more
    /// information.</summary>
    [JsonProperty("ifcoRating")]
    public virtual string IfcoRating { get; set; }

    /// <summary>The video's rating in Israel.</summary>
    [JsonProperty("ilfilmRating")]
    public virtual string IlfilmRating { get; set; }

    /// <summary>The video's INCAA (Instituto Nacional de Cine y Artes Audiovisuales - Argentina) rating.</summary>
    [JsonProperty("incaaRating")]
    public virtual string IncaaRating { get; set; }

    /// <summary>The video's rating from the Kenya Film Classification Board.</summary>
    [JsonProperty("kfcbRating")]
    public virtual string KfcbRating { get; set; }

    /// <summary>voor de Classificatie van Audiovisuele Media (Netherlands).</summary>
    [JsonProperty("kijkwijzerRating")]
    public virtual string KijkwijzerRating { get; set; }

    /// <summary>The video's Korea Media Rating Board (영상물등급위원회) rating. The KMRB rates videos in South
    /// Korea.</summary>
    [JsonProperty("kmrbRating")]
    public virtual string KmrbRating { get; set; }

    /// <summary>The video's rating from Indonesia's Lembaga Sensor Film.</summary>
    [JsonProperty("lsfRating")]
    public virtual string LsfRating { get; set; }

    /// <summary>The video's rating from Malta's Film Age-Classification Board.</summary>
    [JsonProperty("mccaaRating")]
    public virtual string MccaaRating { get; set; }

    /// <summary>The video's rating from the Danish Film Institute's (Det Danske Filminstitut) Media Council for
    /// Children and Young People.</summary>
    [JsonProperty("mccypRating")]
    public virtual string MccypRating { get; set; }

    /// <summary>The video's rating system for Vietnam - MCST</summary>
    [JsonProperty("mcstRating")]
    public virtual string McstRating { get; set; }

    /// <summary>The video's rating from Singapore's Media Development Authority (MDA) and, specifically, it's Board
    /// of Film Censors (BFC).</summary>
    [JsonProperty("mdaRating")]
    public virtual string MdaRating { get; set; }

    /// <summary>The video's rating from Medietilsynet, the Norwegian Media Authority.</summary>
    [JsonProperty("medietilsynetRating")]
    public virtual string MedietilsynetRating { get; set; }

    /// <summary>The video's rating from Finland's Kansallinen Audiovisuaalinen Instituutti (National Audiovisual
    /// Institute).</summary>
    [JsonProperty("mekuRating")]
    public virtual string MekuRating { get; set; }

    /// <summary>The rating system for MENA countries, a clone of MPAA. It is needed to</summary>
    [JsonProperty("menaMpaaRating")]
    public virtual string MenaMpaaRating { get; set; }

    /// <summary>The video's rating from the Ministero dei Beni e delle Attività Culturali e del Turismo
    /// (Italy).</summary>
    [JsonProperty("mibacRating")]
    public virtual string MibacRating { get; set; }

    /// <summary>The video's Ministerio de Cultura (Colombia) rating.</summary>
    [JsonProperty("mocRating")]
    public virtual string MocRating { get; set; }

    /// <summary>The video's rating from Taiwan's Ministry of Culture (文化部).</summary>
    [JsonProperty("moctwRating")]
    public virtual string MoctwRating { get; set; }

    /// <summary>The video's Motion Picture Association of America (MPAA) rating.</summary>
    [JsonProperty("mpaaRating")]
    public virtual string MpaaRating { get; set; }

    /// <summary>The rating system for trailer, DVD, and Ad in the US. See
    /// http://movielabs.com/md/ratings/v2.3/html/US_MPAAT_Ratings.html.</summary>
    [JsonProperty("mpaatRating")]
    public virtual string MpaatRating { get; set; }

    /// <summary>The video's rating from the Movie and Television Review and Classification Board
    /// (Philippines).</summary>
    [JsonProperty("mtrcbRating")]
    public virtual string MtrcbRating { get; set; }

    /// <summary>The video's rating from the Maldives National Bureau of Classification.</summary>
    [JsonProperty("nbcRating")]
    public virtual string NbcRating { get; set; }

    /// <summary>The video's rating in Poland.</summary>
    [JsonProperty("nbcplRating")]
    public virtual string NbcplRating { get; set; }

    /// <summary>The video's rating from the Bulgarian National Film Center.</summary>
    [JsonProperty("nfrcRating")]
    public virtual string NfrcRating { get; set; }

    /// <summary>The video's rating from Nigeria's National Film and Video Censors Board.</summary>
    [JsonProperty("nfvcbRating")]
    public virtual string NfvcbRating { get; set; }

    /// <summary>The video's rating from the Nacionãlais Kino centrs (National Film Centre of Latvia).</summary>
    [JsonProperty("nkclvRating")]
    public virtual string NkclvRating { get; set; }

    /// <summary>The video's Office of Film and Literature Classification (OFLC - New Zealand) rating.</summary>
    [JsonProperty("oflcRating")]
    public virtual string OflcRating { get; set; }

    /// <summary>The video's rating in Peru.</summary>
    [JsonProperty("pefilmRating")]
    public virtual string PefilmRating { get; set; }

    /// <summary>The video's rating from the Hungarian Nemzeti Filmiroda, the Rating Committee of the National
    /// Office of Film.</summary>
    [JsonProperty("rcnofRating")]
    public virtual string RcnofRating { get; set; }

    /// <summary>The video's rating in Venezuela.</summary>
    [JsonProperty("resorteviolenciaRating")]
    public virtual string ResorteviolenciaRating { get; set; }

    /// <summary>The video's General Directorate of Radio, Television and Cinematography (Mexico) rating.</summary>
    [JsonProperty("rtcRating")]
    public virtual string RtcRating { get; set; }

    /// <summary>The video's rating from Ireland's Raidió Teilifís Éireann.</summary>
    [JsonProperty("rteRating")]
    public virtual string RteRating { get; set; }

    /// <summary>The video's National Film Registry of the Russian Federation (MKRF - Russia) rating.</summary>
    [JsonProperty("russiaRating")]
    public virtual string RussiaRating { get; set; }

    /// <summary>The video's rating in Slovakia.</summary>
    [JsonProperty("skfilmRating")]
    public virtual string SkfilmRating { get; set; }

    /// <summary>The video's rating in Iceland.</summary>
    [JsonProperty("smaisRating")]
    public virtual string SmaisRating { get; set; }

    /// <summary>The video's rating from Statens medieråd (Sweden's National Media Council).</summary>
    [JsonProperty("smsaRating")]
    public virtual string SmsaRating { get; set; }

    /// <summary>The video's TV Parental Guidelines (TVPG) rating.</summary>
    [JsonProperty("tvpgRating")]
    public virtual string TvpgRating { get; set; }

    /// <summary>A rating that YouTube uses to identify age-restricted content.</summary>
    [JsonProperty("ytRating")]
    public virtual string YtRating { get; set; }

    /// <summary>The ETag of the item.</summary>
    public virtual string ETag { get; set; }
  }
}
