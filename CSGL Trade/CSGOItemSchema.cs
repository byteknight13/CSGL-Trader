﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSGL_Trade
{

    public partial class CSGOItemSchema
    {

        public CSGOItemSchema LoadNewInstance()
        {
            var sr = new System.IO.StreamReader(@"data\schema.txt");
            using (sr)
            {
                var json = sr.ReadToEnd();

                var jObj = JObject.Parse(json);

                return JsonConvert.DeserializeObject<CSGOItemSchema>(json);
            }
        }

        public class Result
        {

            [JsonProperty("skin_name/_text")]
            public string SkinNameText { get; set; }

            [JsonProperty("available")]
            public string Available { get; set; }

            [JsonProperty("tier")]
            public string Tier { get; set; }

            [JsonProperty("case")]
            public string Case { get; set; }

            [JsonProperty("skin_name")]
            public string SkinName { get; set; }

            [JsonProperty("image_link")]
            public string ImageLink { get; set; }

            [JsonProperty("collection/_text")]
            public string CollectionText { get; set; }

            [JsonProperty("inspect/_source")]
            public string InspectSource { get; set; }

            [JsonProperty("steammarket")]
            public string Steammarket { get; set; }

            [JsonProperty("collection")]
            public string Collection { get; set; }

            [JsonProperty("inspect/_text")]
            public string InspectText { get; set; }

            [JsonProperty("case/_alt")]
            public string CaseAlt { get; set; }

            [JsonProperty("inspect")]
            public string Inspect { get; set; }

            [JsonProperty("steammarket/_text")]
            public string SteammarketText { get; set; }
        }
    }

    public partial class CSGOItemSchema
    {
        public class Page
        {

            [JsonProperty("pageUrl")]
            public string PageUrl { get; set; }

            [JsonProperty("results")]
            public Result[] Results { get; set; }
        }
    }

    public partial class CSGOItemSchema
    {

        [JsonProperty("apiName")]
        public string ApiName { get; set; }

        [JsonProperty("apiGuid")]
        public string ApiGuid { get; set; }

        [JsonProperty("generatedAt")]
        public int GeneratedAt { get; set; }

        [JsonProperty("pages")]
        public Page[] Pages { get; set; }
    }

}
