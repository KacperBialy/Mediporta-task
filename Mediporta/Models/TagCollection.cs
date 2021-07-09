using System.Collections;
using System.Collections.Generic;

namespace Mediporta.Models
{

    public class TagCollection
    {
        public List<Tag> items { get; set; }
        public bool has_more { get; set; }
    }
}
