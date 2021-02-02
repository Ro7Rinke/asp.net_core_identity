using System;
using System.IO;
using System.Text.Json;

namespace Maps
{
    //ray : -22.551476151406902, -47.4341736
    //eu ; -21.9743783494791, -46.76374677428059
    class Program
    {
        static void Main(string[] args)
        {
            double latitudeStart = -21.9743783494791;

            double longitudeStart = -46.76374677428059;

            double latitudeEnd = -22.551476151406902;

            double longitudeEnd = -47.4341736;

            Console.Write("Kilometers: ");
            Console.WriteLine(Coordinates.Distance(latitudeStart, longitudeStart, latitudeEnd, longitudeEnd, Coordinates._kilometers));

            Console.Write("Nautical Miles: ");
            Console.WriteLine(Coordinates.Distance(latitudeStart, longitudeStart, latitudeEnd, longitudeEnd, Coordinates._nauticalMiles));

            Console.Write("Miles: ");
            Console.WriteLine(Coordinates.Distance(latitudeStart, longitudeStart, latitudeEnd, longitudeEnd));

            return;
            string path = "C:/Users/Desenvolvimento/Documents/asp.net_core_identity/Node/geocoderesponse.json";
            string jsonString = File.ReadAllText(path);
            GeocodeResponse georesp = JsonSerializer.Deserialize<GeocodeResponse>(jsonString);
            string postalCode = ExtractPostalCode.Extract(georesp);
            Console.WriteLine(postalCode);
        }

        
    }
}



