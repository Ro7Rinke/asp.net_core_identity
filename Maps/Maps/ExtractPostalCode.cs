using System;
using System.Collections.Generic;
using System.Text;

namespace Maps
{
    public class ExtractPostalCode
    {
        public static string Extract(GeocodeResponse georesp)
        {
            if (georesp.results != null)
                foreach (Result result in georesp.results)
                    if (result.address_components != null)
                        foreach (AddressComponent addressComponent in result.address_components)
                            if (addressComponent.types != null)
                                foreach (string type in addressComponent.types)
                                    if (type == "postal_code")
                                        return addressComponent.long_name;
            return "";
        }

        public static string Extract(Result result)
        {
            if (result.address_components != null)
                foreach (AddressComponent addressComponent in result.address_components)
                    if (addressComponent.types != null)
                        foreach (string type in addressComponent.types)
                            if (type == "postal_code")
                                return addressComponent.long_name;
            return "";
        }

        public static string Extract(AddressComponent addressComponent)
        {
            if (addressComponent.types != null)
                foreach (string type in addressComponent.types)
                    if (type == "postal_code")
                        return addressComponent.long_name;
            return "";
        }
    }
}
