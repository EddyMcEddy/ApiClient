using System.Text.Json.Serialization;

namespace ApiClient
{
    public class JokeItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("punchline")]
        public string PunchLine { get; set; }

        [JsonPropertyName("setup")]
        public string SetUp { get; set; }
    }
}