﻿// Generated by Xamasoft JSON Class Generator
// http://www.xamasoft.com/json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CSGL_Trader
{

    public partial class SteamMarketHistory
    {
        public class History2
        {

            [JsonProperty("time")]
            public object Time { get; set; }
            [JsonProperty("price")]
            public int Price { get; set; }

            [JsonProperty("sold")]
            public int Sold { get; set; }
        }
    }

    public partial class SteamMarketHistory
    {

        [JsonProperty("history")]
        public History2[] History { get; set; }
    }

}
