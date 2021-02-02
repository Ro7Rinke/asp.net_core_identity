using System;
using System.Collections.Generic;
using System.Text;

namespace Maps
{
    public class GeocodeResponse
    {
        public IList<Result> results { get; set; }

        public string status { get; set; }
    }
}
