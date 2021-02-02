using System;
using System.IO;
using System.Text.Json;

namespace Maps
{
    class Program
    {
        static void Main(string[] args)
        {

            Coordinate start = new Coordinate(-21.978968, -46.810287);

            Coordinate end = new Coordinate(-22.978968, -47.810287);

            Console.Write("Kilometers: ");
            Console.WriteLine(CoordinatesCalc.Distance(start, end, CoordinatesCalc._kilometers));

            Console.Write("Nautical Miles: ");
            Console.WriteLine(CoordinatesCalc.Distance(start, end, CoordinatesCalc._nauticalMiles));

            Console.Write("Miles: ");
            Console.WriteLine(CoordinatesCalc.Distance(start, end));

            return;
            string path = "C:/Users/Desenvolvimento/Documents/asp.net_core_identity/Node/geocoderesponse.json";
            string jsonString = File.ReadAllText(path);
            GeocodeResponse georesp = JsonSerializer.Deserialize<GeocodeResponse>(jsonString);
            string postalCode = ExtractPostalCode.Extract(georesp);
            Console.WriteLine(postalCode);
        }

        
    }
}



