using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Indiano.Models
{
    public class DataModel
    {
        public DataModel(XDocument xml)
        {

        }

        public string Name { get; set; }

        public string Type { get; set; }


    }
}
