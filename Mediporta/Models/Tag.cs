using System.Text.Json.Serialization;

namespace Mediporta.Models
{
    public class Tag
    {
        [JsonPropertyName("count")]
        public long Count { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
