using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mediporta.Models
{
    public class IndexViewModel
    {
        public List<Tag> Tags { get; set; }
        public List<double> TagProportions { get; set; }

        public IndexViewModel(List<Tag> tags, List<double> tagProportions)
        {
            Tags = tags;
            TagProportions = tagProportions;
        }
    }
}
