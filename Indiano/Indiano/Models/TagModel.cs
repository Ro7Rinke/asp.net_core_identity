using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indiano.Models
{
    public class TagModel
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public List<TagModel> Children { get; set; }
    }
}
