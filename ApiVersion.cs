using System;
using System.Text.Json.Serialization;

namespace WebApiVersioning
{
    public class ApiVersion
    {
        [JsonIgnore]
        public Version MaxVersion { get; set; }

        [JsonPropertyName("MaxVersion")]
        public string MaxVersionString => MaxVersion.ToString();

        [JsonIgnore]
        public Version MinVersion { get; set; }

        [JsonPropertyName("MinVersion")]
        public string MinVersionString => MinVersion.ToString();

        public string Route { get; set; }
    }
}