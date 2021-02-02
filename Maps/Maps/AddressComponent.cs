using System;
using System.Collections.Generic;
using System.Text;

namespace Maps
{
    public class AddressComponent
    {
        public string long_name { get; set; }

        public string short_name { get; set; }

        public IList<string> types { get; set; }
    }
}



//"address_components": [
//        {
//          "long_name": "277",
//          "short_name": "277",
//          "types": [ "street_number" ]
//        }