using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indiano.Models
{
    public class ParentTagModel
    {
        public string Name { get; set; }

        public List<TagModel> MyProperty { get; set; }
    }
}
