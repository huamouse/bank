﻿using System.Text.Json.Serialization;

namespace Icbc
{
    public class IcbcResponse
    {
        [JsonPropertyName("return_code")]
        public int ReturnCode { get; set; }

        [JsonPropertyName("return_msg")]
        public string ReturnMsg { get; set; }
    }
}
