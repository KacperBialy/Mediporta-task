using System.Collections;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mediporta.Models
{

    public class TagCollection
    {

        [JsonPropertyName("items")]
        public List<Tag> Items { get; set; }
        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }
    }
}
