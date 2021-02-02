using System;
using System.Collections.Generic;
using System.Text;

namespace Maps
{
    public class Geometry
    {
        public LatLng location { get; set; }

        public Viewport viewport { get; set; }

        public string location_type { get; set; }
    }
}
