﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace discord_bot
{
    public struct ConfigJson
    {
        [JsonProperty("token")]
        public string  Token { get; private set; }
        [JsonProperty("prefix")]
        public string Prefix { get;private set; }
    }
}
